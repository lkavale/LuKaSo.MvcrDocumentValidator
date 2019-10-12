namespace LuKaSo.MvcrDocumentValidator.ClientApp
{
    partial class ValidatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _client.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxDocumentId = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lblDocumentIdText = new System.Windows.Forms.Label();
            this.lblDocument = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.pgrValidating = new System.Windows.Forms.ProgressBar();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lblDocumentIdText2 = new System.Windows.Forms.Label();
            this.lblDocumentId = new System.Windows.Forms.Label();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxDocumentId
            // 
            this.tbxDocumentId.Location = new System.Drawing.Point(219, 43);
            this.tbxDocumentId.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tbxDocumentId.Name = "tbxDocumentId";
            this.tbxDocumentId.Size = new System.Drawing.Size(305, 36);
            this.tbxDocumentId.TabIndex = 0;
            this.tbxDocumentId.TextChanged += new System.EventHandler(this.tbxDocumentId_TextChanged);
            // 
            // btnValidate
            // 
            this.btnValidate.Enabled = false;
            this.btnValidate.Location = new System.Drawing.Point(538, 35);
            this.btnValidate.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(163, 51);
            this.btnValidate.TabIndex = 1;
            this.btnValidate.Text = "Ověřit";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.BtnValidate_Click);
            // 
            // lblDocumentIdText
            // 
            this.lblDocumentIdText.AutoSize = true;
            this.lblDocumentIdText.Location = new System.Drawing.Point(10, 46);
            this.lblDocumentIdText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDocumentIdText.Name = "lblDocumentIdText";
            this.lblDocumentIdText.Size = new System.Drawing.Size(195, 29);
            this.lblDocumentIdText.TabIndex = 2;
            this.lblDocumentIdText.Text = "Číslo dokumentu:";
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(10, 82);
            this.lblDocument.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(186, 29);
            this.lblDocument.TabIndex = 3;
            this.lblDocument.Text = "Typ dokumentu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Typ dokumentu:";
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Location = new System.Drawing.Point(10, 123);
            this.lblStatusText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(193, 29);
            this.lblStatusText.TabIndex = 5;
            this.lblStatusText.Text = "Stav dokumentu:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(252, 123);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 29);
            this.lblStatus.TabIndex = 6;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.lblDocumentIdText);
            this.gbInput.Controls.Add(this.tbxDocumentId);
            this.gbInput.Controls.Add(this.btnValidate);
            this.gbInput.Location = new System.Drawing.Point(12, 16);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(948, 106);
            this.gbInput.TabIndex = 7;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Vstup";
            // 
            // pgrValidating
            // 
            this.pgrValidating.Location = new System.Drawing.Point(0, 0);
            this.pgrValidating.Name = "pgrValidating";
            this.pgrValidating.Size = new System.Drawing.Size(970, 10);
            this.pgrValidating.TabIndex = 8;
            this.pgrValidating.Visible = false;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.lblDocumentId);
            this.gbOutput.Controls.Add(this.lblDocumentIdText2);
            this.gbOutput.Controls.Add(this.lblDocument);
            this.gbOutput.Controls.Add(this.label2);
            this.gbOutput.Controls.Add(this.lblStatusText);
            this.gbOutput.Controls.Add(this.lblStatus);
            this.gbOutput.Location = new System.Drawing.Point(12, 128);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(948, 322);
            this.gbOutput.TabIndex = 9;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Výstup";
            // 
            // lblDocumentIdText2
            // 
            this.lblDocumentIdText2.AutoSize = true;
            this.lblDocumentIdText2.Location = new System.Drawing.Point(10, 41);
            this.lblDocumentIdText2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDocumentIdText2.Name = "lblDocumentIdText2";
            this.lblDocumentIdText2.Size = new System.Drawing.Size(195, 29);
            this.lblDocumentIdText2.TabIndex = 7;
            this.lblDocumentIdText2.Text = "Číslo dokumentu:";
            // 
            // lblDocumentId
            // 
            this.lblDocumentId.AutoSize = true;
            this.lblDocumentId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDocumentId.Location = new System.Drawing.Point(252, 41);
            this.lblDocumentId.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblDocumentId.Name = "lblDocumentId";
            this.lblDocumentId.Size = new System.Drawing.Size(0, 29);
            this.lblDocumentId.TabIndex = 8;
            // 
            // ValidatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 460);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.pgrValidating);
            this.Controls.Add(this.gbInput);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "ValidatorForm";
            this.Text = "Ověřní dokumentu u MVČR";
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDocumentId;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label lblDocumentIdText;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.ProgressBar pgrValidating;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label lblDocumentId;
        private System.Windows.Forms.Label lblDocumentIdText2;
    }
}