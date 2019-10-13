using LuKaSo.MvcrDocumentValidator.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace LuKaSo.MvcrDocumentValidator.IntegrationTests
{
    /// <summary>
    /// Passport integration test
    /// </summary>
    [TestClass]
    class PurplePassportTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("39477983", DocumentTypeRequest.PurplePassport).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("39477953", DocumentTypeRequest.PurplePassport).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
            }
        }
    }
}
