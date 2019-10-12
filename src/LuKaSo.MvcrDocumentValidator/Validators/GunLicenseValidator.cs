using LuKaSo.MvcrDocumentValidator.Documents;
using System.Text.RegularExpressions;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// zbrojní průkazy / zbrojní licence
    /// Číslo dokladu je tvořeno dvoumístným znakem série a šestimístným číslem, které může začínat i nulou.
    /// </summary>
    public class GunLicense : IDocumentValidator
    {
        public DocumentTypeRequest Type => DocumentTypeRequest.GunLicense;

        public bool Validate(string id)
        {
            return Regex.IsMatch(id, "[1-9]{0,1}[0-9]{0,6}");
        }
    }
}
