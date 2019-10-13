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
                var responce = client.ValideAsync("39477983", DocumentTypeRequest.PurplePassport).GetAwaiter().GetResult();

                Assert.IsTrue(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.PurplePassport, client.ResolveTypes("39477983").First());
            }
        }

        [TestMethod]
        public void NotInEvidence()
        {
            using (var httpClient = new HttpClient())
            using (var client = new MvcrDocumentValidatorClient(httpClient, new List<IDocumentValidator>() { new PurplePassportValidator() }))
            {
                var responce = client.ValideAsync("39477953", DocumentTypeRequest.PurplePassport).GetAwaiter().GetResult();

                Assert.IsFalse(responce.Responce.Evidented);
                Assert.AreEqual(DocumentType.PurplePassport, client.ResolveTypes("39477953").First());
            }
        }
    }
}
