namespace WindowsFormsCurso
{
    partial class Reportes
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
            reporteCursosButton = new Button();
            reportePlanesButton = new Button();
            SuspendLayout();
            // 
            // reporteCursosButton
            // 
            reporteCursosButton.Location = new Point(54, 40);
            reporteCursosButton.Name = "reporteCursosButton";
            reporteCursosButton.Size = new Size(197, 62);
            reporteCursosButton.TabIndex = 0;
            reporteCursosButton.Text = "Reporte Cursos";
            reporteCursosButton.UseVisualStyleBackColor = true;
            reporteCursosButton.Click += reporteCursosButton_Click;
            // 
            // reportePlanesButton
            // 
            reportePlanesButton.Location = new Point(286, 40);
            reportePlanesButton.Name = "reportePlanesButton";
            reportePlanesButton.Size = new Size(197, 62);
            reportePlanesButton.TabIndex = 1;
            reportePlanesButton.Text = "Reporte Planes";
            reportePlanesButton.UseVisualStyleBackColor = true;
            // 
            // Reportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 319);
            Controls.Add(reportePlanesButton);
            Controls.Add(reporteCursosButton);
            Name = "Reportes";
            Text = "Reportes";
            ResumeLayout(false);
        }

        #endregion

        private Button reporteCursosButton;
        private Button reportePlanesButton;
    }
}