using LuKaSo.MvcrDocumentValidator.Documents;

namespace LuKaSo.MvcrDocumentValidator.Infrastructure
{
    /// <summary>
    /// Document type resolver
    /// </summary>
    public interface IDocumentValidator
    {
        /// <summary>
        /// Document type
        /// </summary>
        DocumentType Type { get; }

        /// <summary>
        /// Resolve document id, if match document id specification
        /// </summary>
        /// <param name="id">Dcument id</param>
        /// <returns>Is resolved</returns>
        bool Resolve(string id);
    }
}
