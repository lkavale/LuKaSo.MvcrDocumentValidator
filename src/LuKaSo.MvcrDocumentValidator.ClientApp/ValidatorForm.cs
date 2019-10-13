using LuKaSo.MvcrDocumentValidator.ClientApp.Logging;
using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.Infrastructure;
using LuKaSo.MvcrDocumentValidator.ResponceXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuKaSo.MvcrDocumentValidator.ClientApp
{
    /// <summary>
    /// Application main form
    /// </summary>
    public partial class ValidatorForm : Form
    {
        /// <summary>
        /// Document validator client
        /// </summary>
        private readonly IMvcrDocumentValidatorClient _client;

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// Is in progress
        /// </summary>
        private bool _isRunning = false;

        public ValidatorForm(IMvcrDocumentValidatorClient client)
        {
            InitializeComponent();
            _client = client;
            _log = LogProvider.For<ValidatorForm>();
        }

        /// <summary>
        /// Document textbox changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbxDocumentId_TextChanged(object sender, EventArgs e)
        {
            // Document id must have at least 7 chars
            BtnValidate.Enabled = TbxDocumentId.Text.Count() >= 7;
        }

        /// <summary>
        /// Validate document id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnValidate_Click(object sender, EventArgs e)
        {
            var documentId = TbxDocumentId.Text;

            _log.Debug($"Validation of document {documentId} started.");

            ClearOutput();
            ShowProgress();
            RunProgress();

            try
            {
                var responces = (await CheckAllAsync(documentId)).ToList();
                var errors = responces.Where(r => r.Error != null).Select(r => r.Error);

                if (errors.Any())
                {
                    _log.Error($"Validation of document id {documentId} failed with {string.Join(", ", errors.Select(er => er.Value))}");
                    MessageBox.Show("Během kontroly čísla dokladu došlo k chybě komunikace.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var evidentedDocument = responces.FirstOrDefault(r => r.Responce != null && r.Responce.Evidented);
                FillData(documentId, evidentedDocument != null, evidentedDocument != null ? (DocumentType?)evidentedDocument.Request.Type : null);
            }
            catch (Exception ex)
            {
                _log.ErrorException($"Validation of document id {documentId} failed", ex);
                MessageBox.Show("Během kontroly čísla dokladu došlo k chybě. \r\nZkontrolujte síťové připojení a opakujte svůj dotaz.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HideProgress();

            _log.Debug($"Validation of document {documentId} finished.");
        }

        /// <summary>
        /// Run endless progressbar
        /// </summary>
        private void RunProgress()
        {
            Task.Run(async () =>
            {
                var i = 0;

                while (_isRunning)
                {
                    i = i > 100 ? 0 : i + 1;
                    Invoke((Action)delegate { pgrValidating.Value = i; });
                    await Task.Delay(50);
                }
            });
        }

        /// <summary>
        /// Perform validation
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        private async Task<IEnumerable<InvalidDocument>> CheckAllAsync(string documentId)
        {
            var tasks = Enum.GetValues(typeof(DocumentTypeRequest))
                .Cast<DocumentTypeRequest>()
                .Select(t => _client.ValideAsync(documentId, t));

            return await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Show progress
        /// </summary>
        private void ShowProgress()
        {
            pgrValidating.Value = 0;
            pgrValidating.Visible = true;
            _isRunning = true;
        }

        /// <summary>
        /// Hide progress
        /// </summary>
        private void HideProgress()
        {
            pgrValidating.Visible = false;
            _isRunning = false;
        }

        /// <summary>
        /// Fill output
        /// </summary>
        /// <param name="documentId">Document id</param>
        /// <param name="inEvidence">Is document in evidence</param>
        /// <param name="resolvedDocumentType">Resolved document type</param>
        private void FillData(string documentId, bool inEvidence, DocumentType? resolvedDocumentType)
        {
            LblDocumentId.Text = documentId;
            LblDocumentStatus.Text = inEvidence ? $"V evidenci neplatných dokumentů ({StringifyResolvedDocumentType((DocumentType)resolvedDocumentType)})" : "Není v evidenci neplatných dokumentů";
            LblDocumentType.Text = StringifyResolvedDocumentTypes(documentId);
        }

        /// <summary>
        /// Clear output
        /// </summary>
        private void ClearOutput()
        {
            TbxDocumentId.Text = "";
            LblDocumentId.Text = "";
            LblDocumentStatus.Text = "";
            LblDocumentType.Text = "";
        }

        /// <summary>
        /// Resolved document types to user friendly text
        /// </summary>
        /// <param name="documentId">Document id</param>
        /// <returns>Text</returns>
        private string StringifyResolvedDocumentTypes(string documentId)
        {
            var types = _client.ResolveTypes(documentId)
                .Select(t => StringifyResolvedDocumentType(t));

            return string.Join(", ", types);
        }

        /// <summary>
        /// Document type to user friendly text
        /// </summary>
        /// <param name="documentType">Document type</param>
        /// <returns>Text</returns>
        private string StringifyResolvedDocumentType(DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.IdentityCardNew:
                    return "Občanský průkaz (nový)";
                case DocumentType.IdentityCardOld:
                    return "Občanský průkaz (starý)";
                case DocumentType.GunLicense:
                    return "Zbrojní průkaz";
                case DocumentType.GeenPassport:
                    return "Pas (zelený)";
                case DocumentType.PurplePassport:
                    return "Pas (fialový)";
                case DocumentType.OtherPassport:
                    return "Pas (jiný)";
            }

            return $"Nerozpoznaný typ ({documentType.ToString()})";
        }
    }
}
