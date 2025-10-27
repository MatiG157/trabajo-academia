namespace WindowsFormsCurso
{
    partial class PlanesLista
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
            planesDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)planesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // refrescarButton
            // 
            refrescarButton.Location = new Point(458, 392);
            refrescarButton.Margin = new Padding(3, 4, 3, 4);
            refrescarButton.Name = "refrescarButton";
            refrescarButton.Size = new Size(91, 31);
            refrescarButton.TabIndex = 13;
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
            modificarButton.TabIndex = 12;
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
            eliminarButton.TabIndex = 11;
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
            agregarButton.TabIndex = 10;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // planesDataGridView
            // 
            planesDataGridView.AllowUserToOrderColumns = true;
            planesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            planesDataGridView.Location = new Point(13, 15);
            planesDataGridView.Margin = new Padding(2, 3, 2, 3);
            planesDataGridView.MultiSelect = false;
            planesDataGridView.Name = "planesDataGridView";
            planesDataGridView.ReadOnly = true;
            planesDataGridView.RowHeadersWidth = 82;
            planesDataGridView.RowTemplate.Height = 41;
            planesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            planesDataGridView.Size = new Size(858, 360);
            planesDataGridView.TabIndex = 9;
            // 
            // PlanesLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 435);
            Controls.Add(refrescarButton);
            Controls.Add(modificarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(planesDataGridView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlanesLista";
            Text = "Plan Lista";
            Load += planes_load;
            ((System.ComponentModel.ISupportInitialize)planesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button refrescarButton;
        private Button modificarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView planesDataGridView;
    }
}