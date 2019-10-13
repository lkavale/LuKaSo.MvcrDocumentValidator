﻿using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using System.Text.RegularExpressions;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// cestovní pasy vydávané centrálně - „fialový pas“
    /// Číslo dokladu je tvořeno osmi číslicemi, první z nich nesmí být nula.Doklad nemá sérii.Každé dva centrálně vydané cestovní pasy mají vždy různá čísla.Může se však vyskytnout dvojice pasů vydaných centrálně a regionálně se stejným číslem.
    /// </summary>
    public class PurplePassportValidator : IDocumentValidator
    {
        /// <summary>
        /// Document type
        /// </summary>
        public DocumentType Type => DocumentType.PurplePassport;

        /// <summary>
        /// Resolve document id, if match document id specification
        /// </summary>
        /// <param name="id">Dcument id</param>
        /// <returns>Is resolved</returns>
        public bool Resolve(string id)
        {
            return Regex.IsMatch(id, "^[1-9]{0,1}[0-9]{0,7}$");
        }
    }
}
