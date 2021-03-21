
namespace TransportExercise
{
    partial class Grid
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
            this.uc_Vehicle1 = new TransportExercise.uc_Vehicle();
            this.SuspendLayout();
            // 
            // uc_Vehicle1
            // 
            this.uc_Vehicle1.Location = new System.Drawing.Point(12, 12);
            this.uc_Vehicle1.Name = "uc_Vehicle1";
            this.uc_Vehicle1.Size = new System.Drawing.Size(1268, 640);
            this.uc_Vehicle1.TabIndex = 1;
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 706);
            this.Controls.Add(this.uc_Vehicle1);
            this.Name = "Grid";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private uc_Vehicle uc_Vehicle1;
    }
}

