namespace WindowsFormsCurso
{
    partial class MateriasLista
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
            modificarButton = new Button();
            eliminarButton = new Button();
            agregarButton = new Button();
            materiasDataGridView = new DataGridView();
            refrescarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)materiasDataGridView).BeginInit();
            SuspendLayout();
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(588, 294);
            modificarButton.Margin = new Padding(2);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(80, 22);
            modificarButton.TabIndex = 7;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(496, 294);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(80, 22);
            eliminarButton.TabIndex = 6;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(681, 294);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(80, 22);
            agregarButton.TabIndex = 5;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // materiasDataGridView
            // 
            materiasDataGridView.AllowUserToOrderColumns = true;
            materiasDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            materiasDataGridView.Location = new Point(11, 11);
            materiasDataGridView.Margin = new Padding(2);
            materiasDataGridView.MultiSelect = false;
            materiasDataGridView.Name = "materiasDataGridView";
            materiasDataGridView.ReadOnly = true;
            materiasDataGridView.RowHeadersWidth = 82;
            materiasDataGridView.RowTemplate.Height = 41;
            materiasDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            materiasDataGridView.Size = new Size(751, 270);
            materiasDataGridView.TabIndex = 4;
            // 
            // refrescarButton
            // 
            refrescarButton.Location = new Point(401, 294);
            refrescarButton.Name = "refrescarButton";
            refrescarButton.Size = new Size(80, 23);
            refrescarButton.TabIndex = 8;
            refrescarButton.Text = "Refrescar";
            refrescarButton.UseVisualStyleBackColor = true;
            refrescarButton.Click += refrescarButton_Click;
            // 
            // MateriasLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 331);
            Controls.Add(refrescarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(materiasDataGridView);
            Name = "MateriasLista";
            Text = "Materias";
            Load += materias_load;
            ((System.ComponentModel.ISupportInitialize)materiasDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button modificarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView materiasDataGridView;
        private Button refrescarButton;
    }
}