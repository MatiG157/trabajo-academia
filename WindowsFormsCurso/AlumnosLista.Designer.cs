namespace WindowsFormsCurso
{
    partial class Form1
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
            comisionesDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)comisionesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // refrescarButton
            // 
            refrescarButton.Location = new Point(401, 294);
            refrescarButton.Name = "refrescarButton";
            refrescarButton.Size = new Size(80, 23);
            refrescarButton.TabIndex = 15;
            refrescarButton.Text = "Refrescar";
            refrescarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(588, 294);
            modificarButton.Margin = new Padding(2);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(80, 22);
            modificarButton.TabIndex = 14;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(496, 294);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(80, 22);
            eliminarButton.TabIndex = 13;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(681, 294);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(80, 22);
            agregarButton.TabIndex = 12;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            // 
            // comisionesDataGridView
            // 
            comisionesDataGridView.AllowUserToOrderColumns = true;
            comisionesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            comisionesDataGridView.Location = new Point(11, 11);
            comisionesDataGridView.Margin = new Padding(2);
            comisionesDataGridView.MultiSelect = false;
            comisionesDataGridView.Name = "comisionesDataGridView";
            comisionesDataGridView.ReadOnly = true;
            comisionesDataGridView.RowHeadersWidth = 82;
            comisionesDataGridView.RowTemplate.Height = 41;
            comisionesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comisionesDataGridView.Size = new Size(751, 270);
            comisionesDataGridView.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 327);
            Controls.Add(refrescarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(comisionesDataGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Alumnos_Load;
            ((System.ComponentModel.ISupportInitialize)comisionesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button refrescarButton;
        private Button modificarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView comisionesDataGridView;
    }
}