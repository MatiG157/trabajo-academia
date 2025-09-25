namespace WindowsFormsCurso
{
    partial class ComisionDetalle
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
            idPlanUpDown = new NumericUpDown();
            añoEspecialidadLabel = new Label();
            añoEspecialidadNumericUpDown = new NumericUpDown();
            descripcionLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            idPlanLabel = new Label();
            DescripcionRichTextBox = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)idPlanUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)añoEspecialidadNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // idPlanUpDown
            // 
            idPlanUpDown.Location = new Point(122, 131);
            idPlanUpDown.Name = "idPlanUpDown";
            idPlanUpDown.Size = new Size(109, 23);
            idPlanUpDown.TabIndex = 31;
            // 
            // añoEspecialidadLabel
            // 
            this.añoEspecialidadLabel.AutoSize = true;
            this.añoEspecialidadLabel.Location = new Point(22, 96);
            this.añoEspecialidadLabel.Margin = new Padding(2, 0, 2, 0);
            this.añoEspecialidadLabel.Name = "añoEspecialidadLabel";
            this.añoEspecialidadLabel.Size = new Size(97, 15);
            this.añoEspecialidadLabel.TabIndex = 29;
            this.añoEspecialidadLabel.Text = "Año especialidad";
            // 
            // añoEspecialidadNumericUpDown
            // 
            añoEspecialidadNumericUpDown.Location = new Point(122, 94);
            añoEspecialidadNumericUpDown.Margin = new Padding(2);
            añoEspecialidadNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            añoEspecialidadNumericUpDown.Name = "añoEspecialidadNumericUpDown";
            añoEspecialidadNumericUpDown.Size = new Size(109, 23);
            añoEspecialidadNumericUpDown.TabIndex = 22;
            añoEspecialidadNumericUpDown.TabStop = false;
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(22, 20);
            descripcionLabel.Margin = new Padding(2, 0, 2, 0);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(69, 15);
            descripcionLabel.TabIndex = 27;
            descripcionLabel.Text = "Descripcion";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(209, 170);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(80, 22);
            cancelarButton.TabIndex = 26;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(108, 170);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(80, 22);
            aceptarButton.TabIndex = 25;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            // 
            // idPlanLabel
            // 
            idPlanLabel.AutoSize = true;
            idPlanLabel.Location = new Point(22, 133);
            idPlanLabel.Margin = new Padding(2, 0, 2, 0);
            idPlanLabel.Name = "idPlanLabel";
            idPlanLabel.Size = new Size(43, 15);
            idPlanLabel.TabIndex = 23;
            idPlanLabel.Text = "Id plan";
            // 
            // DescripcionRichTextBox
            // 
            DescripcionRichTextBox.Location = new Point(122, 17);
            DescripcionRichTextBox.Name = "DescripcionRichTextBox";
            DescripcionRichTextBox.Size = new Size(272, 60);
            DescripcionRichTextBox.TabIndex = 30;
            DescripcionRichTextBox.Text = "";
            // 
            // ComisionDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 210);
            Controls.Add(idPlanUpDown);
            Controls.Add(DescripcionRichTextBox);
            Controls.Add(this.añoEspecialidadLabel);
            Controls.Add(añoEspecialidadNumericUpDown);
            Controls.Add(descripcionLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(idPlanLabel);
            Name = "ComisionDetalle";
            Text = "Detalle Comicion";
            ((System.ComponentModel.ISupportInitialize)idPlanUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)añoEspecialidadNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown idPlanUpDown;
        private Label HorasSemanalesLabel;
        private NumericUpDown añoEspecialidadNumericUpDown;
        private Label descripcionLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private Label idPlanLabel;
        private Label añoEspecialidadLabel;
        private RichTextBox DescripcionRichTextBox;
    }
}