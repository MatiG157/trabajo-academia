namespace WindowsFormsCurso
{
    partial class PersonasLista
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
            refrescarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            agregarButton = new Button();
            personasDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)personasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // refrescarButton
            // 
            refrescarButton.Location = new Point(458, 392);
            refrescarButton.Margin = new Padding(3, 4, 3, 4);
            refrescarButton.Name = "refrescarButton";
            refrescarButton.Size = new Size(91, 31);
            refrescarButton.TabIndex = 15;
            refrescarButton.Text = "Refrescar";
            refrescarButton.UseVisualStyleBackColor = true;
            refrescarButton.Click += refrescarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(672, 392);
            modificarButton.Margin = new Padding(2, 3, 2, 3);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(91, 29);
            modificarButton.TabIndex = 14;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(567, 392);
            eliminarButton.Margin = new Padding(2, 3, 2, 3);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(91, 29);
            eliminarButton.TabIndex = 13;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(778, 392);
            agregarButton.Margin = new Padding(2, 3, 2, 3);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(91, 29);
            agregarButton.TabIndex = 12;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // personasDataGridView
            // 
            personasDataGridView.AllowUserToOrderColumns = true;
            personasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personasDataGridView.Location = new Point(13, 15);
            personasDataGridView.Margin = new Padding(2, 3, 2, 3);
            personasDataGridView.MultiSelect = false;
            personasDataGridView.Name = "personasDataGridView";
            personasDataGridView.ReadOnly = true;
            personasDataGridView.RowHeadersWidth = 82;
            personasDataGridView.RowTemplate.Height = 41;
            personasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            personasDataGridView.Size = new Size(858, 360);
            personasDataGridView.TabIndex = 11;
            // 
            // PersonasLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 436);
            Controls.Add(refrescarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(personasDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PersonasLista";
            Text = "Personas Lista";
            Load += Personas_Load;
            ((System.ComponentModel.ISupportInitialize)personasDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button refrescarButton;
        private Button modificarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView personasDataGridView;
    }
}