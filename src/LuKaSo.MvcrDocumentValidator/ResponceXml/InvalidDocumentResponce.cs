using System;
using System.Globalization;
using System.Xml.Serialization;

namespace LuKaSo.MvcrDocumentValidator.ResponceXml
{
    [XmlType(AnonymousType = true), XmlRoot(ElementName = "odpoved")]
    public class InvalidDocumentResponce
    {
        [XmlIgnore]
        public DateTime Actualized { get; set; }

        [XmlAttribute(AttributeName = "aktualizovano")]
        public string ActualizedXml
        {
            get { return Actualized.ToString("d.M.yyyy"); }
            set { Actualized = DateTime.ParseExact(value, "d.M.yyyy", CultureInfo.InvariantCulture); }
        }

        [XmlIgnore]
        public bool Evidented { get; set; }

        [XmlAttribute(AttributeName = "evidovano")]
        public string EvidentedXml
        {
            get { return Evidented ? "ano" : "ne"; }
            set { Evidented = value == "ano"; }
        }

        [XmlIgnore]
        public DateTime EvidentedFrom { get; set; }

        [XmlAttribute(AttributeName = "evidovano_od")]
        public string EvidentedFromXml
        {
            get { return EvidentedFrom.ToString("d.M.yyyy"); }
            set { EvidentedFrom = DateTime.ParseExact(value, "d.M.yyyy", CultureInfo.InvariantCulture); }
        }
    }
}
