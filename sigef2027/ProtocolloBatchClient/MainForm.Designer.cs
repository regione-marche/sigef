namespace ProtocolloBatchClient
{
    partial class MainForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.cbBandi = new System.Windows.Forms.ComboBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lstMsg
            // 
            this.lstMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.Location = new System.Drawing.Point(12, 79);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(826, 303);
            this.lstMsg.TabIndex = 0;
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Location = new System.Drawing.Point(704, 12);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(134, 23);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "Avvia Protocollazione";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // cbBandi
            // 
            this.cbBandi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBandi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBandi.FormattingEnabled = true;
            this.cbBandi.Location = new System.Drawing.Point(12, 42);
            this.cbBandi.Name = "cbBandi";
            this.cbBandi.Size = new System.Drawing.Size(826, 21);
            this.cbBandi.TabIndex = 4;
            // 
            // lblCounter
            // 
            this.lblCounter.CausesValidation = false;
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(12, 2);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(250, 37);
            this.lblCounter.TabIndex = 5;
            this.lblCounter.Text = "--/--";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 394);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.cbBandi);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.lstMsg);
            this.Name = "MainForm";
            this.Text = "Protocollo Batch Client";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.ComboBox cbBandi;
        private System.Windows.Forms.Label lblCounter;
    }
}

