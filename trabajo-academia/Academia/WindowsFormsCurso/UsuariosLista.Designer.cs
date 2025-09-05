namespace WindowsForms
{
    partial class UsuariosLista
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
            usuariosDataGridView = new DataGridView();
            agregarButton = new Button();
            eliminarButton = new Button();
            modificarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)usuariosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // usuariosDataGridView
            // 
            usuariosDataGridView.AllowUserToOrderColumns = true;
            usuariosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usuariosDataGridView.Location = new Point(24, 24);
            usuariosDataGridView.Margin = new Padding(2);
            usuariosDataGridView.MultiSelect = false;
            usuariosDataGridView.Name = "usuariosDataGridView";
            usuariosDataGridView.ReadOnly = true;
            usuariosDataGridView.RowHeadersWidth = 82;
            usuariosDataGridView.RowTemplate.Height = 41;
            usuariosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usuariosDataGridView.Size = new Size(858, 360);
            usuariosDataGridView.TabIndex = 0;
            usuariosDataGridView.CellContentClick += usuariosDataGridView_CellContentClick;
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
            // UsuariosLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 536);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(usuariosDataGridView);
            Margin = new Padding(2);
            Name = "UsuariosLista";
            Text = "Usuarios"; 
            Load += Usuarios_Load;
            ((System.ComponentModel.ISupportInitialize)usuariosDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView usuariosDataGridView;
        private Button agregarButton;
        private Button eliminarButton;
        private Button modificarButton;
    }
}