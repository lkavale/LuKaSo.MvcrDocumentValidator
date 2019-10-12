using LuKaSo.MvcrDocumentValidator.Documents;
using System;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    /// <summary>
    /// občanské průkazy se sérii(starší typ)
    /// Číslo dokladu je tvořeno šesti číslicemi, může začínat nulou.Série je tvořena dvěma písmeny (bez háčku a čárek). Některé občanské však průkazy mohou mít sérii tvořenou dvěma písmeny a dvěma číslicemi(například AB01). Na velikosti písmen nezáleží.
    /// </summary>
    public class OldIdentityCardValidator : IDocumentValidator
    {
        public DocumentTypeRequest Type => throw new NotImplementedException();

        public bool Validate(string id)
        {
            throw new NotImplementedException();
        }
    }
}
