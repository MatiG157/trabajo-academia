namespace WindowsFormsCurso
{
    partial class MateriaDetalle
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
            HorasSemanalesLabel = new Label();
            horasSemanalesNumericUpDown = new NumericUpDown();
            horasTotalesLabel = new Label();
            horasTotalesNumericUpDown = new NumericUpDown();
            descripcionLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            DescripcionRichTextBox = new RichTextBox();
            idPlanLabel = new Label();
            idPlanUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)horasSemanalesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)horasTotalesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idPlanUpDown).BeginInit();
            SuspendLayout();
            // 
            // HorasSemanalesLabel
            // 
            HorasSemanalesLabel.AutoSize = true;
            HorasSemanalesLabel.Location = new Point(25, 98);
            HorasSemanalesLabel.Margin = new Padding(2, 0, 2, 0);
            HorasSemanalesLabel.Name = "HorasSemanalesLabel";
            HorasSemanalesLabel.Size = new Size(96, 15);
            HorasSemanalesLabel.TabIndex = 19;
            HorasSemanalesLabel.Text = "Horas semanales";
            // 
            // horasSemanalesNumericUpDown
            // 
            horasSemanalesNumericUpDown.Location = new Point(125, 96);
            horasSemanalesNumericUpDown.Margin = new Padding(2);
            horasSemanalesNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            horasSemanalesNumericUpDown.Name = "horasSemanalesNumericUpDown";
            horasSemanalesNumericUpDown.Size = new Size(109, 23);
            horasSemanalesNumericUpDown.TabIndex = 10;
            horasSemanalesNumericUpDown.TabStop = false;
            // 
            // horasTotalesLabel
            // 
            horasTotalesLabel.AutoSize = true;
            horasTotalesLabel.Location = new Point(25, 132);
            horasTotalesLabel.Margin = new Padding(2, 0, 2, 0);
            horasTotalesLabel.Name = "horasTotalesLabel";
            horasTotalesLabel.Size = new Size(76, 15);
            horasTotalesLabel.TabIndex = 18;
            horasTotalesLabel.Text = "Horas totales";
            // 
            // horasTotalesNumericUpDown
            // 
            horasTotalesNumericUpDown.Location = new Point(125, 130);
            horasTotalesNumericUpDown.Margin = new Padding(2);
            horasTotalesNumericUpDown.Name = "horasTotalesNumericUpDown";
            horasTotalesNumericUpDown.Size = new Size(109, 23);
            horasTotalesNumericUpDown.TabIndex = 14;
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(25, 22);
            descripcionLabel.Margin = new Padding(2, 0, 2, 0);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(69, 15);
            descripcionLabel.TabIndex = 17;
            descripcionLabel.Text = "Descripcion";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(212, 201);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(80, 22);
            cancelarButton.TabIndex = 16;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(111, 201);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(80, 22);
            aceptarButton.TabIndex = 15;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // DescripcionRichTextBox
            // 
            DescripcionRichTextBox.Location = new Point(125, 19);
            DescripcionRichTextBox.Name = "DescripcionRichTextBox";
            DescripcionRichTextBox.Size = new Size(272, 60);
            DescripcionRichTextBox.TabIndex = 20;
            DescripcionRichTextBox.Text = "";
            // 
            // idPlanLabel
            // 
            idPlanLabel.AutoSize = true;
            idPlanLabel.Location = new Point(25, 164);
            idPlanLabel.Margin = new Padding(2, 0, 2, 0);
            idPlanLabel.Name = "idPlanLabel";
            idPlanLabel.Size = new Size(43, 15);
            idPlanLabel.TabIndex = 13;
            idPlanLabel.Text = "Id plan";
            // 
            // idPlanUpDown
            // 
            idPlanUpDown.Location = new Point(125, 162);
            idPlanUpDown.Name = "idPlanUpDown";
            idPlanUpDown.Size = new Size(109, 23);
            idPlanUpDown.TabIndex = 21;
            // 
            // MateriaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 234);
            Controls.Add(idPlanUpDown);
            Controls.Add(DescripcionRichTextBox);
            Controls.Add(HorasSemanalesLabel);
            Controls.Add(horasSemanalesNumericUpDown);
            Controls.Add(horasTotalesLabel);
            Controls.Add(horasTotalesNumericUpDown);
            Controls.Add(descripcionLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(idPlanLabel);
            Name = "MateriaDetalle";
            Text = "Detalle materia";
            ((System.ComponentModel.ISupportInitialize)horasSemanalesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)horasTotalesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)idPlanUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HorasSemanalesLabel;
        private NumericUpDown horasSemanalesNumericUpDown;
        private Label horasTotalesLabel;
        private NumericUpDown horasTotalesNumericUpDown;
        private Label descripcionLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private RichTextBox DescripcionRichTextBox;
        private Label idPlanLabel;
        private NumericUpDown idPlanUpDown;
    }
}