using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Extensions;
using LuKaSo.MvcrDocumentValidator.Logging;
using LuKaSo.MvcrDocumentValidator.ResponceXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LuKaSo.MvcrDocumentValidator
{
    public class MvcrDocumentValidatorClient : IDisposable
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
        /// Logger
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// MVCR document validator
        /// </summary>
        /// <param name="client">Client</param>
        public MvcrDocumentValidatorClient(HttpClient client)
        {
            _client = client;
            _log = LogProvider.For<MvcrDocumentValidatorClient>();
        }

        ~MvcrDocumentValidatorClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// Check validity
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<InvalidDocument> Valide(string documentId, DocumentTypeRequest type)
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
                var document = await GetRequest<InvalidDocument>(address).ConfigureAwait(false);
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
        /// <returns></returns>
        protected async Task<T> GetRequest<T>(Uri address) where T : class
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
        /// <returns></returns>
        protected T SerializeResponce<T>(Stream stream) where T : class
        {
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
