using LuKaSo.MvcrDocumentValidator.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace LuKaSo.MvcrDocumentValidator.IntegrationTests
{
    [TestClass]
    public class GunLicenceTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("AL363692", DocumentTypeRequest.GunLicense).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient))
            {
                var responce = client.Valide("AL163692", DocumentTypeRequest.GunLicense).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
            }
        }
    }
}
