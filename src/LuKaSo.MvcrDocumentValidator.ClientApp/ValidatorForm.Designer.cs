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
            this.TbxDocumentId = new System.Windows.Forms.TextBox();
            this.BtnValidate = new System.Windows.Forms.Button();
            this.LblDocumentIdText = new System.Windows.Forms.Label();
            this.LblDocumentTypeText = new System.Windows.Forms.Label();
            this.LblDocumentType = new System.Windows.Forms.Label();
            this.LblDocumentStatusText = new System.Windows.Forms.Label();
            this.LblDocumentStatus = new System.Windows.Forms.Label();
            this.GbInput = new System.Windows.Forms.GroupBox();
            this.pgrValidating = new System.Windows.Forms.ProgressBar();
            this.GbOutput = new System.Windows.Forms.GroupBox();
            this.LblDocumentId = new System.Windows.Forms.Label();
            this.LblDocumentIdText2 = new System.Windows.Forms.Label();
            this.GbInput.SuspendLayout();
            this.GbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbxDocumentId
            // 
            this.TbxDocumentId.Location = new System.Drawing.Point(219, 43);
            this.TbxDocumentId.Margin = new System.Windows.Forms.Padding(7);
            this.TbxDocumentId.Name = "TbxDocumentId";
            this.TbxDocumentId.Size = new System.Drawing.Size(305, 36);
            this.TbxDocumentId.TabIndex = 0;
            this.TbxDocumentId.TextChanged += new System.EventHandler(this.TbxDocumentId_TextChanged);
            // 
            // BtnValidate
            // 
            this.BtnValidate.Enabled = false;
            this.BtnValidate.Location = new System.Drawing.Point(538, 35);
            this.BtnValidate.Margin = new System.Windows.Forms.Padding(7);
            this.BtnValidate.Name = "BtnValidate";
            this.BtnValidate.Size = new System.Drawing.Size(163, 51);
            this.BtnValidate.TabIndex = 1;
            this.BtnValidate.Text = "Ověřit";
            this.BtnValidate.UseVisualStyleBackColor = true;
            this.BtnValidate.Click += new System.EventHandler(this.BtnValidate_Click);
            // 
            // LblDocumentIdText
            // 
            this.LblDocumentIdText.AutoSize = true;
            this.LblDocumentIdText.Location = new System.Drawing.Point(10, 46);
            this.LblDocumentIdText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentIdText.Name = "LblDocumentIdText";
            this.LblDocumentIdText.Size = new System.Drawing.Size(195, 29);
            this.LblDocumentIdText.TabIndex = 2;
            this.LblDocumentIdText.Text = "Číslo dokumentu:";
            // 
            // LblDocumentTypeText
            // 
            this.LblDocumentTypeText.AutoSize = true;
            this.LblDocumentTypeText.Location = new System.Drawing.Point(10, 82);
            this.LblDocumentTypeText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentTypeText.Name = "LblDocumentTypeText";
            this.LblDocumentTypeText.Size = new System.Drawing.Size(186, 29);
            this.LblDocumentTypeText.TabIndex = 3;
            this.LblDocumentTypeText.Text = "Typ dokumentu:";
            // 
            // LblDocumentType
            // 
            this.LblDocumentType.AutoSize = true;
            this.LblDocumentType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LblDocumentType.Location = new System.Drawing.Point(252, 82);
            this.LblDocumentType.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentType.Name = "LblDocumentType";
            this.LblDocumentType.Size = new System.Drawing.Size(0, 29);
            this.LblDocumentType.TabIndex = 4;
            // 
            // LblDocumentStatusText
            // 
            this.LblDocumentStatusText.AutoSize = true;
            this.LblDocumentStatusText.Location = new System.Drawing.Point(10, 123);
            this.LblDocumentStatusText.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentStatusText.Name = "LblDocumentStatusText";
            this.LblDocumentStatusText.Size = new System.Drawing.Size(193, 29);
            this.LblDocumentStatusText.TabIndex = 5;
            this.LblDocumentStatusText.Text = "Stav dokumentu:";
            // 
            // LblDocumentStatus
            // 
            this.LblDocumentStatus.AutoSize = true;
            this.LblDocumentStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LblDocumentStatus.Location = new System.Drawing.Point(252, 123);
            this.LblDocumentStatus.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentStatus.Name = "LblDocumentStatus";
            this.LblDocumentStatus.Size = new System.Drawing.Size(0, 29);
            this.LblDocumentStatus.TabIndex = 6;
            // 
            // GbInput
            // 
            this.GbInput.Controls.Add(this.LblDocumentIdText);
            this.GbInput.Controls.Add(this.TbxDocumentId);
            this.GbInput.Controls.Add(this.BtnValidate);
            this.GbInput.Location = new System.Drawing.Point(12, 16);
            this.GbInput.Name = "GbInput";
            this.GbInput.Size = new System.Drawing.Size(948, 106);
            this.GbInput.TabIndex = 7;
            this.GbInput.TabStop = false;
            this.GbInput.Text = "Vstup";
            // 
            // pgrValidating
            // 
            this.pgrValidating.Location = new System.Drawing.Point(0, 0);
            this.pgrValidating.Name = "pgrValidating";
            this.pgrValidating.Size = new System.Drawing.Size(970, 10);
            this.pgrValidating.TabIndex = 8;
            this.pgrValidating.Visible = false;
            // 
            // GbOutput
            // 
            this.GbOutput.Controls.Add(this.LblDocumentId);
            this.GbOutput.Controls.Add(this.LblDocumentIdText2);
            this.GbOutput.Controls.Add(this.LblDocumentTypeText);
            this.GbOutput.Controls.Add(this.LblDocumentType);
            this.GbOutput.Controls.Add(this.LblDocumentStatusText);
            this.GbOutput.Controls.Add(this.LblDocumentStatus);
            this.GbOutput.Location = new System.Drawing.Point(12, 128);
            this.GbOutput.Name = "GbOutput";
            this.GbOutput.Size = new System.Drawing.Size(948, 166);
            this.GbOutput.TabIndex = 9;
            this.GbOutput.TabStop = false;
            this.GbOutput.Text = "Výstup";
            // 
            // LblDocumentId
            // 
            this.LblDocumentId.AutoSize = true;
            this.LblDocumentId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LblDocumentId.Location = new System.Drawing.Point(252, 41);
            this.LblDocumentId.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentId.Name = "LblDocumentId";
            this.LblDocumentId.Size = new System.Drawing.Size(0, 29);
            this.LblDocumentId.TabIndex = 8;
            // 
            // LblDocumentIdText2
            // 
            this.LblDocumentIdText2.AutoSize = true;
            this.LblDocumentIdText2.Location = new System.Drawing.Point(10, 41);
            this.LblDocumentIdText2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDocumentIdText2.Name = "LblDocumentIdText2";
            this.LblDocumentIdText2.Size = new System.Drawing.Size(195, 29);
            this.LblDocumentIdText2.TabIndex = 7;
            this.LblDocumentIdText2.Text = "Číslo dokumentu:";
            // 
            // ValidatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 304);
            this.Controls.Add(this.GbOutput);
            this.Controls.Add(this.pgrValidating);
            this.Controls.Add(this.GbInput);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "ValidatorForm";
            this.Text = "Ověřní dokumentu u MVČR";
            this.GbInput.ResumeLayout(false);
            this.GbInput.PerformLayout();
            this.GbOutput.ResumeLayout(false);
            this.GbOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TbxDocumentId;
        private System.Windows.Forms.Button BtnValidate;
        private System.Windows.Forms.Label LblDocumentIdText;
        private System.Windows.Forms.Label LblDocumentTypeText;
        private System.Windows.Forms.Label LblDocumentType;
        private System.Windows.Forms.Label LblDocumentStatusText;
        private System.Windows.Forms.Label LblDocumentStatus;
        private System.Windows.Forms.GroupBox GbInput;
        private System.Windows.Forms.ProgressBar pgrValidating;
        private System.Windows.Forms.GroupBox GbOutput;
        private System.Windows.Forms.Label LblDocumentId;
        private System.Windows.Forms.Label LblDocumentIdText2;
    }
}