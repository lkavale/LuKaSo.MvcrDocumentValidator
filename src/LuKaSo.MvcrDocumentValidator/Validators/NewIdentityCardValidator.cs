using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using System.Text.RegularExpressions;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// Občanské průkazy bez série (novější typ)
    /// Číslo dokladu je tvořeno devíti číslicemi, první z nich nesmí být nula. Doklad nemá sérii.
    /// </summary>
    public class NewIdentityCardValidator : IDocumentValidator
    {
        /// <summary>
        /// Document type
        /// </summary>
        public DocumentType Type => DocumentType.IdentityCardNew;

        /// <summary>
        /// Resolve document id, if match document id specification
        /// </summary>
        /// <param name="id">Dcument id</param>
        /// <returns>Is resolved</returns>
        public bool Resolve(string id)
        {
            return Regex.IsMatch(id, "[1-9]{0,1}[0-9]{0,8}");
        }
    }
}
