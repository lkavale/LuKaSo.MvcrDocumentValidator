using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using LuKaSo.MvcrDocumentValidator.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace LuKaSo.MvcrDocumentValidator.IntegrationTests
{
    /// <summary>
    /// Gun licence integration test
    /// </summary>
    [TestClass]
    public class GunLicenceTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new GunLicenseValidator() }))
            {
                var responce = client.ValideAsync("AL363692", DocumentTypeRequest.GunLicense).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.GunLicense, client.ResolveTypes("AL363692").First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new GunLicenseValidator() }))
            {
                var responce = client.ValideAsync("AL163692", DocumentTypeRequest.GunLicense).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.GunLicense, client.ResolveTypes("AL163692").First());
            }
        }
    }
}
