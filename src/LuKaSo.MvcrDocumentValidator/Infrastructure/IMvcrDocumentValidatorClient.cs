using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.ResponceXml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuKaSo.MvcrDocumentValidator.Infrastructure
{
    /// <summary>
    /// Document validator client
    /// </summary>
    public interface IMvcrDocumentValidatorClient
    {
        /// <summary>
        /// Check document validity
        /// </summary>
        /// <param name="documentId">Document id</param>
        /// <param name="type">Type of document</param>
        /// <returns>Document information</returns>
        Task<InvalidDocument> ValideAsync(string documentId, DocumentTypeRequest type);

        /// <summary>
        /// Resolve type of document
        /// </summary>
        /// <param name="documentId">Document id</param>
        /// <returns>Resolved types</returns>
        IEnumerable<DocumentType> ResolveType(string documentId);
    }
}
