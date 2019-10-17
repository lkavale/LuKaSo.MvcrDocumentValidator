using System;
using System.Globalization;
using System.Xml.Serialization;

namespace LuKaSo.MvcrDocumentValidator.ResponceXml
{
    [XmlType(AnonymousType = true), XmlRoot(ElementName = "doklady_neplatne", Namespace = "", IsNullable = false)]
    public class InvalidDocument
    {
        [XmlElement(ElementName = "dotaz")]
        public InvalidDocumentRequest Request { get; set; }

        [XmlElement(ElementName = "odpoved")]
        public InvalidDocumentResponce Responce { get; set; }

        [XmlElement(ElementName = "chyba")]
        public InvalidDocumentError Error { get; set; }


        [XmlIgnore]
        public DateTime LastChange { get; set; }

        [XmlAttribute(AttributeName = "posl_zmena")]
        public string LastChangeXml
        {
            get { return LastChange.ToString("d.M.yyyy"); }
            set { LastChange = DateTime.ParseExact(value, "d.M.yyyy", CultureInfo.InvariantCulture); }
        }

        [XmlAttribute(AttributeName = "pristi_zmeny")]
        public string NextChanges { get; set; }
    }
}
