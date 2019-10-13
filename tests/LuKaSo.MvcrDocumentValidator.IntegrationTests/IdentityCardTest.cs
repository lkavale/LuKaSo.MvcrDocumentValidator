using LuKaSo.MvcrDocumentValidator.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace LuKaSo.MvcrDocumentValidator.IntegrationTests
{
    /// <summary>
    /// ID card integration test
    /// </summary>
    [TestClass]
    public class IdentityCardTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("113347325", DocumentTypeRequest.IdentityCard).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("114343325", DocumentTypeRequest.IdentityCard).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
            }
        }
    }
}
