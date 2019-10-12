using System;
using System.Collections.Generic;
using System.Text;
using LuKaSo.MvcrDocumentValidator.Documents;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// cestovní pasy vydávané centrálně - „fialový pas“
    /// Číslo dokladu je tvořeno osmi číslicemi, první z nich nesmí být nula.Doklad nemá sérii.Každé dva centrálně vydané cestovní pasy mají vždy různá čísla.Může se však vyskytnout dvojice pasů vydaných centrálně a regionálně se stejným číslem.
    /// </summary>
    public class PurplePassportValidator : IDocumentValidator
    {
        public DocumentTypeRequest Type => throw new NotImplementedException();

        public bool Validate(string id)
        {
            throw new NotImplementedException();
        }
    }
}
