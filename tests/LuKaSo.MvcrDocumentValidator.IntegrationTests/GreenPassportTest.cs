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
                var responce = client.ValideAsync("42540025", DocumentTypeRequest.GeenPassport).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.GeenPassport, client.ResolveTypes("42540025").First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new GreenPassportValidator() }))
            {
                var responce = client.ValideAsync("42340025", DocumentTypeRequest.GeenPassport).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.GeenPassport, client.ResolveTypes("42340025").First());
            }
        }
    }
}
