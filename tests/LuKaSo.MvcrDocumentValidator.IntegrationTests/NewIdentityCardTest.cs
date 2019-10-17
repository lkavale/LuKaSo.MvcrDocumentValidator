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
    /// New ID card integration test
    /// </summary>
    [TestClass]
    public class NewIdentityCardTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new NewIdentityCardValidator() }))
            {
                var responce = client.ValideAsync("113367896", DocumentTypeRequest.IdentityCard).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.IdentityCardNew, client.ResolveTypes("113367896").First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new NewIdentityCardValidator() }))
            {
                var responce = client.ValideAsync("114343325", DocumentTypeRequest.IdentityCard).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.IdentityCardNew, client.ResolveTypes("114343325").First());
            }
        }
    }
}
