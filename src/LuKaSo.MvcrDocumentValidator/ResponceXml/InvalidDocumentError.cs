using System.Xml.Serialization;

namespace LuKaSo.MvcrDocumentValidator.ResponceXml
{
    [XmlType(AnonymousType = true), XmlRoot(ElementName = "chyba")]
    public class InvalidDocumentError
    {
        [XmlIgnore]
        public bool BadRequest { get; set; }

        [XmlAttribute(AttributeName = "spatny_dotaz")]
        public string BadRequestXml
        {
            get { return BadRequest ? "ano" : "ne"; }
            set { BadRequest = value == "ano"; }
        }


        [XmlText()]
        public string Value { get; set; }
    }
}
