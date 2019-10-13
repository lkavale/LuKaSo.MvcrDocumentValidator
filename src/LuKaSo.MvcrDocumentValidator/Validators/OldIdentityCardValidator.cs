using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using System.Text.RegularExpressions;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// občanské průkazy se sérii(starší typ)
    /// Číslo dokladu je tvořeno šesti číslicemi, může začínat nulou.Série je tvořena dvěma písmeny (bez háčku a čárek). Některé občanské však průkazy mohou mít sérii tvořenou dvěma písmeny a dvěma číslicemi(například AB01). Na velikosti písmen nezáleží.
    /// </summary>
    public class OldIdentityCardValidator : IDocumentValidator
    {
        /// <summary>
        /// Document type
        /// </summary>
        public DocumentType Type => DocumentType.IdentityCardOld;

        /// <summary>
        /// Resolve document id, if match document id specification
        /// </summary>
        /// <param name="id">Dcument id</param>
        /// <returns>Is resolved</returns>
        public bool Resolve(string id)
        {
            return Regex.IsMatch(id, "^[A-Z]{2}([0-9]{2})?[0-9]{0,6}$");
        }
    }
}
