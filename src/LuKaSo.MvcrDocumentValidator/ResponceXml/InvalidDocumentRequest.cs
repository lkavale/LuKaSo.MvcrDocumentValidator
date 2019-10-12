using LuKaSo.MvcrDocumentValidator.Documents;
using System;
using System.Xml.Serialization;

namespace LuKaSo.MvcrDocumentValidator.ResponceXml
{
    [XmlType(AnonymousType = true), XmlRoot(ElementName = "dotaz")]
    public class InvalidDocumentRequest
    {
        [XmlIgnore]
        public DocumentType Type { get; set; }

        [XmlAttribute(AttributeName = "typ")]
        public string TypeXml
        {
            get { return DocumentTypeToString(Type); }
            set
            {
                Type = StringToDocumentType(value);
            }
        }

        [XmlAttribute(AttributeName = "cislo")]
        public string Number { get; set; }

        [XmlAttribute(AttributeName = "serie")]
        public string Serie { get; set; }

        private string DocumentTypeToString(DocumentType type)
        {
            switch (type)
            {
                case DocumentType.IdentityCardNew:
                    return "OP";
                case DocumentType.IdentityCardOld:
                    return "OPs";
                case DocumentType.GeenPassport:
                    return "CDr";
                case DocumentType.PurplePassport:
                    return "CD";
                case DocumentType.OtherPassport:
                    return "CDj";
                case DocumentType.GunLicense:
                    return "ZP";
            }

            throw new ArgumentException($"Unresolved type of document {type.ToString()}", nameof(type));
        }

        private DocumentType StringToDocumentType(string type)
        {
            switch (type)
            {
                case "OP":
                    return DocumentType.IdentityCardNew;
                case "OPs":
                    return DocumentType.IdentityCardOld;
                case "CDr":
                    return DocumentType.GeenPassport;
                case "CD":
                    return DocumentType.PurplePassport;
                case "CDj":
                    return DocumentType.OtherPassport;
                case "ZP":
                    return DocumentType.GunLicense;
            }

            throw new ArgumentException($"Unresolved type of document {type}", nameof(type));
        }
    }
}
