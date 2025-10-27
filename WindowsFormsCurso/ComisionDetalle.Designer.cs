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
            añoEspecialidadLabel = new Label();
            añoEspecialidadNumericUpDown = new NumericUpDown();
            descripcionLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            idPlanLabel = new Label();
            DescripcionRichTextBox = new RichTextBox();
            planDropDown = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)añoEspecialidadNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // añoEspecialidadLabel
            // 
            añoEspecialidadLabel.AutoSize = true;
            añoEspecialidadLabel.Location = new Point(25, 128);
            añoEspecialidadLabel.Margin = new Padding(2, 0, 2, 0);
            añoEspecialidadLabel.Name = "añoEspecialidadLabel";
            añoEspecialidadLabel.Size = new Size(124, 20);
            añoEspecialidadLabel.TabIndex = 29;
            añoEspecialidadLabel.Text = "Año especialidad";
            // 
            // añoEspecialidadNumericUpDown
            // 
            añoEspecialidadNumericUpDown.Location = new Point(153, 126);
            añoEspecialidadNumericUpDown.Margin = new Padding(2, 3, 2, 3);
            añoEspecialidadNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            añoEspecialidadNumericUpDown.Name = "añoEspecialidadNumericUpDown";
            añoEspecialidadNumericUpDown.Size = new Size(138, 27);
            añoEspecialidadNumericUpDown.TabIndex = 22;
            añoEspecialidadNumericUpDown.TabStop = false;
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(25, 27);
            descripcionLabel.Margin = new Padding(2, 0, 2, 0);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(87, 20);
            descripcionLabel.TabIndex = 27;
            descripcionLabel.Text = "Descripcion";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(239, 227);
            cancelarButton.Margin = new Padding(2, 3, 2, 3);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(91, 29);
            cancelarButton.TabIndex = 26;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(123, 227);
            aceptarButton.Margin = new Padding(2, 3, 2, 3);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(91, 29);
            aceptarButton.TabIndex = 25;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // idPlanLabel
            // 
            idPlanLabel.AutoSize = true;
            idPlanLabel.Location = new Point(25, 177);
            idPlanLabel.Margin = new Padding(2, 0, 2, 0);
            idPlanLabel.Name = "idPlanLabel";
            idPlanLabel.Size = new Size(55, 20);
            idPlanLabel.TabIndex = 23;
            idPlanLabel.Text = "Id plan";
            // 
            // DescripcionRichTextBox
            // 
            DescripcionRichTextBox.Location = new Point(153, 24);
            DescripcionRichTextBox.Margin = new Padding(3, 4, 3, 4);
            DescripcionRichTextBox.Name = "DescripcionRichTextBox";
            DescripcionRichTextBox.Size = new Size(310, 79);
            DescripcionRichTextBox.TabIndex = 30;
            DescripcionRichTextBox.Text = "";
            // 
            // planDropDown
            // 
            planDropDown.FormattingEnabled = true;
            planDropDown.Location = new Point(153, 174);
            planDropDown.Margin = new Padding(3, 4, 3, 4);
            planDropDown.Name = "planDropDown";
            planDropDown.Size = new Size(138, 28);
            planDropDown.TabIndex = 32;
            // 
            // ComisionDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 280);
            Controls.Add(planDropDown);
            Controls.Add(DescripcionRichTextBox);
            Controls.Add(añoEspecialidadLabel);
            Controls.Add(añoEspecialidadNumericUpDown);
            Controls.Add(descripcionLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(idPlanLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ComisionDetalle";
            Text = "Detalle comisión";
            Load += Comision_Load;
            ((System.ComponentModel.ISupportInitialize)añoEspecialidadNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label HorasSemanalesLabel;
        private NumericUpDown añoEspecialidadNumericUpDown;
        private Label descripcionLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private Label idPlanLabel;
        private Label añoEspecialidadLabel;
        private RichTextBox DescripcionRichTextBox;
        private ComboBox planDropDown;
    }
}