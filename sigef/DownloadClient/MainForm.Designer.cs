
namespace DownloadClient
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
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnRequest = new System.Windows.Forms.Button();
            this.txtIdTicket = new System.Windows.Forms.TextBox();
            this.lblIdTicket = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMsg
            // 
            this.lstMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.HorizontalScrollbar = true;
            this.lstMsg.Location = new System.Drawing.Point(12, 72);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(826, 368);
            this.lstMsg.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Location = new System.Drawing.Point(717, 26);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(121, 20);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "Avvia Richiesta";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // txtIdTicket
            // 
            this.txtIdTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdTicket.Location = new System.Drawing.Point(522, 26);
            this.txtIdTicket.Name = "txtIdTicket";
            this.txtIdTicket.Size = new System.Drawing.Size(187, 20);
            this.txtIdTicket.TabIndex = 2;
            // 
            // lblIdTicket
            // 
            this.lblIdTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdTicket.AutoSize = true;
            this.lblIdTicket.Location = new System.Drawing.Point(465, 30);
            this.lblIdTicket.Name = "lblIdTicket";
            this.lblIdTicket.Size = new System.Drawing.Size(51, 13);
            this.lblIdTicket.TabIndex = 3;
            this.lblIdTicket.Text = "ID Ticket";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.lblIdTicket);
            this.Controls.Add(this.txtIdTicket);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.lstMsg);
            this.Name = "MainForm";
            this.Text = "Download Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMsg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox txtIdTicket;
        private System.Windows.Forms.Label lblIdTicket;
    }
}

