using LuKaSo.MvcrDocumentValidator.Infrastructure;
using LuKaSo.MvcrDocumentValidator.ResponceXml;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace LuKaSo.MvcrDocumentValidator.UnitTests.Common
{
    /// <summary>
    /// Test client to access internals for test
    /// </summary>
    public class MvcrDocumentValidatorTestClient : MvcrDocumentValidatorClient
    {
        public MvcrDocumentValidatorTestClient() : base(new HttpClient(), new List<IDocumentValidator>())
        {
        }

        /// <summary>
        /// Access internal serialization
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Document data</returns>
        public InvalidDocument Serialize(Stream stream)
        {
            return SerializeResponce<InvalidDocument>(stream);
        }
    }
}
