using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.UnitTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LuKaSo.MvcrDocumentValidator.UnitTests
{
    [TestClass]
    public class ExampleSerializerTests
    {
        [TestMethod]
        public void TestInEvidence()
        {
            using (FileStream stream = File.OpenRead("InEvidence.xml"))
            using (var client = new MvcrDocumentValidatorTestClient())
            {
                var document = client.Serialize(stream);

                Assert.AreEqual(new DateTime(2019, 1, 1), document.LastChange);
                Assert.AreEqual("1.1.2019", document.LastChangeXml);
                Assert.AreEqual("stručné upozornění", document.NextChanges);

                Assert.AreEqual(DocumentType.IdentityCardNew, document.Request.Type);
                Assert.AreEqual("OP", document.Request.TypeXml);
                Assert.AreEqual("113346738", document.Request.Number);
                Assert.AreEqual("", document.Request.Serie);

                Assert.AreEqual(new DateTime(2019, 1, 2), document.Responce.Actualized);
                Assert.AreEqual("2.1.2019", document.Responce.ActualizedXml);
                Assert.IsTrue(document.Responce.Evidented);
                Assert.AreEqual("ano", document.Responce.EvidentedXml);
                Assert.AreEqual(new DateTime(2019, 1, 1), document.Responce.EvidentedFrom);
                Assert.AreEqual("1.1.2019", document.Responce.EvidentedFromXml);

                Assert.IsNull(document.Error);
            }
        }

        [TestMethod]
        public void TestNotInEvidence()
        {
            using (FileStream stream = File.OpenRead("NotInEvidence.xml"))
            using (var client = new MvcrDocumentValidatorTestClient())
            {
                var document = client.Serialize(stream);

                Assert.AreEqual(new DateTime(2019, 1, 1), document.LastChange);
                Assert.AreEqual("1.1.2019", document.LastChangeXml);
                Assert.AreEqual("stručné upozornění", document.NextChanges);

                Assert.AreEqual(DocumentType.IdentityCardNew, document.Request.Type);
                Assert.AreEqual("OP", document.Request.TypeXml);
                Assert.AreEqual("113346738", document.Request.Number);
                Assert.AreEqual("", document.Request.Serie);

                Assert.AreEqual(new DateTime(2019, 1, 2), document.Responce.Actualized);
                Assert.AreEqual("2.1.2019", document.Responce.ActualizedXml);
                Assert.IsFalse(document.Responce.Evidented);
                Assert.AreEqual("ne", document.Responce.EvidentedXml);
                Assert.AreEqual(new DateTime(2019, 1, 1), document.Responce.EvidentedFrom);
                Assert.AreEqual("1.1.2019", document.Responce.EvidentedFromXml);

                Assert.IsNull(document.Error);
            }
        }

        [TestMethod]
        public void TestError()
        {
            using (FileStream stream = File.OpenRead("Error.xml"))
            using (var client = new MvcrDocumentValidatorTestClient())
            {
                var document = client.Serialize(stream);

                Assert.AreEqual(new DateTime(2019, 1, 1), document.LastChange);
                Assert.AreEqual("1.1.2019", document.LastChangeXml);
                Assert.AreEqual("stručné upozornění", document.NextChanges);

                Assert.IsTrue(document.Error.BadRequest);
                Assert.AreEqual("ano", document.Error.BadRequestXml);
                Assert.AreEqual("text chyby", document.Error.Value);
            }
        }
    }
}
