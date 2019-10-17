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
    /// Passport integration test
    /// </summary>
    [TestClass]
    public class PurplePassportTest
    {
        [TestMethod]
        public void InEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new PurplePassportValidator() }))
            {
                var id = "39477983";
                var responce = client.ValideAsync(id, DocumentTypeRequest.PurplePassport).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(id, responce.Request.Number);
                Assert.AreEqual("-", responce.Request.Serie);

                Assert.AreEqual(DocumentType.PurplePassport, client.ResolveTypes(id).First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new PurplePassportValidator() }))
            {
                var id = "39477953";
                var responce = client.ValideAsync(id, DocumentTypeRequest.PurplePassport).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(id, responce.Request.Number);
                Assert.AreEqual("-", responce.Request.Serie);

                Assert.AreEqual(DocumentType.PurplePassport, client.ResolveTypes(id).First());
            }
        }
    }
}
