using LuKaSo.MvcrDocumentValidator.Documents;
using System.Text.RegularExpressions;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// Občanské průkazy bez série (novější typ)
    /// Číslo dokladu je tvořeno devíti číslicemi, první z nich nesmí být nula. Doklad nemá sérii.
    /// </summary>
    public class NewIdentityCardValidator : IDocumentValidator
    {
        public DocumentTypeRequest Type => DocumentTypeRequest.IdentityCard;

        public bool Validate(string id)
        {
            return Regex.IsMatch(id, "[1-9]{0,1}[0-9]{0,8}");
        }
    }
}
