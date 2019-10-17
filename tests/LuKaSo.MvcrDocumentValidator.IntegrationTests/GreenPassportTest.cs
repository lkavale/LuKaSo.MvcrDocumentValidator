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
    /// Green passport integration test
    /// </summary>
    [TestClass]
    public class GreenPassportTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new GreenPassportValidator() }))
            {
                var id = "42540025";
                var responce = client.ValideAsync(id, DocumentTypeRequest.GeenPassport).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(id, responce.Request.Number);
                Assert.AreEqual("-", responce.Request.Serie);

                Assert.AreEqual(DocumentType.GeenPassport, client.ResolveTypes(id).First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new GreenPassportValidator() }))
            {
                var id = "42340025";
                var responce = client.ValideAsync(id, DocumentTypeRequest.GeenPassport).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(id, responce.Request.Number);
                Assert.AreEqual("-", responce.Request.Serie);

                Assert.AreEqual(DocumentType.GeenPassport, client.ResolveTypes(id).First());
            }
        }
    }
}
