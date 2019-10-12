using LuKaSo.MvcrDocumentValidator.Documents;
using LuKaSo.MvcrDocumentValidator.ResponceXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuKaSo.MvcrDocumentValidator.ClientApp
{
    public partial class ValidatorForm : Form
    {
        private readonly MvcrDocumentValidatorClient _client;

        private bool _isRunning = false;

        public ValidatorForm()
        {
            InitializeComponent();
            _client = new MvcrDocumentValidatorClient(new HttpClient());
        }

        private async void BtnValidate_Click(object sender, EventArgs e)
        {
            ShowProgress();

            var responces = (await CheckAll()).ToList();

            var errors = responces.Where(r => r.Error != null)
                .Select(r => r.Error);

            var isEvidented = responces.Any(r => r.Responce != null && r.Responce.Evidented);
            lblStatus.Text = isEvidented ? "V evidenci" : "Není v evidenci";

            HideProgress();
        }

        private async Task<IEnumerable<InvalidDocument>> CheckAll()
        {
            var tasks = Enum.GetValues(typeof(DocumentTypeRequest))
                .Cast<DocumentTypeRequest>()
                .Select(t => _client.Valide(tbxDocumentId.Text, t));

            return await Task.WhenAll(tasks);
        }

        private void tbxDocumentId_TextChanged(object sender, EventArgs e)
        {
            btnValidate.Enabled = tbxDocumentId.Text.Count() >= 7;
        }

        private void ShowProgress()
        {
            pgrValidating.Value = 0;
            pgrValidating.Visible = true;
            _isRunning = true;
            RunProgress();
        }

        private void HideProgress()
        {
            pgrValidating.Visible = false;
            _isRunning = false;
        }

        private void RunProgress()
        {
            Task.Run(async() =>
            {
                var i = 0;

                while (_isRunning)
                {
                    i++;
                    await Task.Delay(50);
                    Invoke((Action)delegate ()
                    {
                        pgrValidating.Value = i;
                    });
                    if (i == 100)
                    {
                        i = 0;
                    }
                }
            });
        }
    }
}
