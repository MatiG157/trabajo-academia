namespace WindowsForms
{
    partial class CursosLista
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cursosDataGridView = new DataGridView();
            agregarButton = new Button();
            eliminarButton = new Button();
            modificarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cursosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // cursosDataGridView
            // 
            cursosDataGridView.AllowUserToOrderColumns = true;
            cursosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cursosDataGridView.Location = new Point(24, 24);
            cursosDataGridView.Margin = new Padding(2);
            cursosDataGridView.MultiSelect = false;
            cursosDataGridView.Name = "cursosDataGridView";
            cursosDataGridView.ReadOnly = true;
            cursosDataGridView.RowHeadersWidth = 82;
            cursosDataGridView.RowTemplate.Height = 41;
            cursosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cursosDataGridView.Size = new Size(858, 360);
            cursosDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(790, 401);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(92, 29);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(578, 401);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(92, 29);
            eliminarButton.TabIndex = 2;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(684, 401);
            modificarButton.Margin = new Padding(2);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(92, 29);
            modificarButton.TabIndex = 3;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // CursosLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 536);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(cursosDataGridView);
            Margin = new Padding(2);
            Name = "CursosLista";
            Text = "Cursos";
            Load += Cursos_Load;
            ((System.ComponentModel.ISupportInitialize)cursosDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView cursosDataGridView;
        private Button agregarButton;
        private Button eliminarButton;
        private Button modificarButton;
    }
}