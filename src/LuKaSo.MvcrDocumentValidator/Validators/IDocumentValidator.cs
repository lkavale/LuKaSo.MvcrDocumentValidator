using LuKaSo.MvcrDocumentValidator.Documents;

namespace LuKaSo.MvcrDocumentValidator.Validators
{
    public interface IDocumentValidator
    {
        /// <summary>
        /// Document type
        /// </summary>
        DocumentTypeRequest Type { get; }

        /// <summary>
        /// Validate document id, if match document id specification
        /// </summary>
        /// <param name="id">Dcument id</param>
        /// <returns></returns>
        bool Validate(string id);
    }
}
