namespace WindowsFormsCurso
{
    partial class ComisionesLista
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
            comisionesDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)comisionesDataGridView).BeginInit();
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
            comisionesDataGridView.TabIndex = 4;
            // 
            // ComisionesLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 326);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(comisionesDataGridView);
            Name = "ComisionesLista";
            Text = "Lista de comisiones";
            Load += Comisiones_Load;
            ((System.ComponentModel.ISupportInitialize)comisionesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button modificarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView comisionesDataGridView;
    }
}