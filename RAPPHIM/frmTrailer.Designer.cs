namespace RAPPHIM
{
    partial class frmTrailer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrailer));
            this.sfTrailer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.sfTrailer)).BeginInit();
            this.SuspendLayout();
            // 
            // sfTrailer
            // 
            this.sfTrailer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfTrailer.Enabled = true;
            this.sfTrailer.Location = new System.Drawing.Point(0, 0);
            this.sfTrailer.Name = "sfTrailer";
            this.sfTrailer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sfTrailer.OcxState")));
            this.sfTrailer.Size = new System.Drawing.Size(780, 444);
            this.sfTrailer.TabIndex = 0;
            // 
            // frmTrailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 444);
            this.Controls.Add(this.sfTrailer);
            this.Name = "frmTrailer";
            this.Text = "frmTrailer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTrailer_FormClosed);
            this.Load += new System.EventHandler(this.frmTrailer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfTrailer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash sfTrailer;
    }
}