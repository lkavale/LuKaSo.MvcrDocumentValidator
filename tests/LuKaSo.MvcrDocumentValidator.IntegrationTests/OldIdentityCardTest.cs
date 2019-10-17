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
    /// Old ID card integration test
    /// </summary>
    [TestClass]
    public class OldIdentityCardTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new OldIdentityCardValidator() }))
            {
                var id = "AA321305";
                var responce = client.ValideAsync(id, DocumentTypeRequest.IdentityCard).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(id, $"{responce.Request.Serie}{responce.Request.Number}");

                Assert.AreEqual(DocumentType.IdentityCardOld, client.ResolveTypes(id).First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new OldIdentityCardValidator() }))
            {
                var id = "AA325305";
                var responce = client.ValideAsync(id, DocumentTypeRequest.IdentityCard).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(id, $"{responce.Request.Serie}{responce.Request.Number}");

                Assert.AreEqual(DocumentType.IdentityCardOld, client.ResolveTypes(id).First());
            }
        }
    }
}
