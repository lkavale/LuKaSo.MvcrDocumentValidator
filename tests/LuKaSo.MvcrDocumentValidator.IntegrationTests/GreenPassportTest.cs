using LuKaSo.MvcrDocumentValidator.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace LuKaSo.MvcrDocumentValidator.IntegrationTests
{
    /// <summary>
    /// Green passport integration test
    /// </summary>
    [TestClass]
    public class GreenPassportTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("42540025", DocumentTypeRequest.GeenPassport).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("42340025", DocumentTypeRequest.GeenPassport).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
            }
        }
    }
}
