using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using System.Text.RegularExpressions;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// zbrojní průkazy / zbrojní licence
    /// Číslo dokladu je tvořeno dvoumístným znakem série a šestimístným číslem, které může začínat i nulou.
    /// </summary>
    public class GunLicenseValidator : IDocumentValidator
    {
        /// <summary>
        /// Document type
        /// </summary>
        public DocumentType Type => DocumentType.GunLicense;

        /// <summary>
        /// Resolve document id, if match document id specification
        /// </summary>
        /// <param name="id">Dcument id</param>
        /// <returns>Is resolved</returns>
        public bool Resolve(string id)
        {
            return Regex.IsMatch(id, "^[A-Z]{2}[0-9]{0,6}$", RegexOptions.IgnoreCase);
        }
    }
}
