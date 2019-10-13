using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Extensions;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using LuKaSo.MvcrDocumentValidator.Logging;
using LuKaSo.MvcrDocumentValidator.ResponceXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LuKaSo.MvcrDocumentValidator
{
    public class MvcrDocumentValidatorClient : IMvcrDocumentValidatorClient, IDisposable
    {
        /// <summary>
        /// Service address
        /// </summary>
        private readonly Uri _serviceAddress = new Uri("https://aplikace.mvcr.cz/neplatne-doklady/doklady.aspx");

        /// <summary>
        /// Http client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Document types resolvers
        /// </summary>
        private readonly IEnumerable<IDocumentValidator> _documentTypeResolvers;

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// MVCR document validator
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="documentTypeResolvers">Document type resolvers</param>
        public MvcrDocumentValidatorClient(HttpClient client, IEnumerable<IDocumentValidator> documentTypeResolvers)
        {
            client = client ?? throw new ArgumentNullException(nameof(client));
            documentTypeResolvers = documentTypeResolvers ?? throw new ArgumentNullException(nameof(documentTypeResolvers));

            _client = client;
            _documentTypeResolvers = documentTypeResolvers;
            _log = LogProvider.For<MvcrDocumentValidatorClient>();
        }

        ~MvcrDocumentValidatorClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// Resolve type of document
        /// </summary>
        /// <param name="documentId">Document id</param>
        /// <returns>Resolved types</returns>
        public IEnumerable<DocumentType> ResolveTypes(string documentId)
        {
            return _documentTypeResolvers.Where(r => r.Resolve(documentId))
                .Select(r => r.Type);
        }

        /// <summary>
        /// Check document validity
        /// </summary>
        /// <param name="documentId">Document id</param>
        /// <param name="type">Type of document</param>
        /// <returns>Document information</returns>
        public async Task<InvalidDocument> ValideAsync(string documentId, DocumentTypeRequest type)
        {
            _log.Debug($"Start validation of document id {documentId} as {type.ToString()}");

            var queryParams = new Dictionary<string, string>()
            {
                { "dotaz", documentId },
                { "doklad", ((int)type).ToString() }
            };
            var address = _serviceAddress.AttachQueryParameters(queryParams);

            try
            {
                var document = await GetRequestAsync<InvalidDocument>(address).ConfigureAwait(false);
                _log.Debug($"End validation of document id {documentId} as {type.ToString()}");

                return document;
            }
            catch (Exception ex)
            {
                _log.Error(ex, $"Validation of document id {documentId} as {type.ToString()}");
                throw;
            }
        }

        /// <summary>
        /// Make get request
        /// </summary>
        /// <typeparam name="T">Get request to type</typeparam>
        /// <param name="address">Address</param>
        /// <returns>Responce</returns>
        protected async Task<T> GetRequestAsync<T>(Uri address) where T : class
        {
            using (var responce = await _client.GetAsync(address).ConfigureAwait(false))
            using (var stream = await responce.Content.ReadAsStreamAsync().ConfigureAwait(false))
            {
                return SerializeResponce<T>(stream);
            }
        }

        /// <summary>
        /// Serialize stream
        /// </summary>
        /// <typeparam name="T">Serialize to type</typeparam>
        /// <param name="stream">Stream</param>
        /// <returns>Serialized output</returns>
        protected T SerializeResponce<T>(Stream stream) where T : class
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));

            var serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(stream) as T;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
            }
        }
    }
}
