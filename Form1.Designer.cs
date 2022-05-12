namespace Snake
{
    partial class Snake
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.scorelbl = new System.Windows.Forms.Label();
            this.food = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Location = new System.Drawing.Point(12, 28);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(87, 21);
            this.scorelbl.TabIndex = 0;
            this.scorelbl.Text = "Score:0";
            // 
            // food
            // 
            this.food.BackColor = System.Drawing.Color.Red;
            this.food.Location = new System.Drawing.Point(289, 152);
            this.food.Name = "food";
            this.food.Size = new System.Drawing.Size(20, 21);
            this.food.TabIndex = 1;
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.food);
            this.Controls.Add(this.scorelbl);
            this.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Snake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snake_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Label scorelbl;
        private System.Windows.Forms.Label food;
    }
}

