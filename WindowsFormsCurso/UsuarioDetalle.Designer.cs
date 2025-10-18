namespace WindowsForms
{
    partial class UsuarioDetalle
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
            nombreUsuarioTextBox = new TextBox();
            nombreUsuarioLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            claveLabel = new Label();
            claveTextBox = new TextBox();
            habilitadoLabel = new Label();
            habilitadoCheckBox = new CheckBox();
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            cambiaClaveLabel = new Label();
            idPersonaLabel = new Label();
            cambiaClaveCheckBox = new CheckBox();
            idPersonaNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)idPersonaNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // nombreUsuarioTextBox
            // 
            nombreUsuarioTextBox.Location = new Point(130, 18);
            nombreUsuarioTextBox.Margin = new Padding(2);
            nombreUsuarioTextBox.Name = "nombreUsuarioTextBox";
            nombreUsuarioTextBox.Size = new Size(147, 23);
            nombreUsuarioTextBox.TabIndex = 0;
            // 
            // nombreUsuarioLabel
            // 
            nombreUsuarioLabel.AutoSize = true;
            nombreUsuarioLabel.Location = new Point(23, 23);
            nombreUsuarioLabel.Margin = new Padding(2, 0, 2, 0);
            nombreUsuarioLabel.Name = "nombreUsuarioLabel";
            nombreUsuarioLabel.Size = new Size(89, 15);
            nombreUsuarioLabel.TabIndex = 1;
            nombreUsuarioLabel.Text = "nombreUsuario";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(297, 375);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(80, 22);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(396, 375);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(80, 22);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // claveLabel
            // 
            claveLabel.AutoSize = true;
            claveLabel.Location = new Point(23, 61);
            claveLabel.Margin = new Padding(2, 0, 2, 0);
            claveLabel.Name = "claveLabel";
            claveLabel.Size = new Size(34, 15);
            claveLabel.TabIndex = 5;
            claveLabel.Text = "clave";
            claveLabel.Click += claveLabel_Click;
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(130, 56);
            claveTextBox.Margin = new Padding(2);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new Size(147, 23);
            claveTextBox.TabIndex = 1;
            // 
            // habilitadoLabel
            // 
            habilitadoLabel.AutoSize = true;
            habilitadoLabel.Location = new Point(20, 106);
            habilitadoLabel.Margin = new Padding(2, 0, 2, 0);
            habilitadoLabel.Name = "habilitadoLabel";
            habilitadoLabel.Size = new Size(62, 15);
            habilitadoLabel.TabIndex = 9;
            habilitadoLabel.Text = "Habilitado";
            // 
            // habilitadoCheckBox
            // 
            habilitadoCheckBox.Location = new Point(130, 106);
            habilitadoCheckBox.Margin = new Padding(2);
            habilitadoCheckBox.Name = "habilitadoCheckBox";
            habilitadoCheckBox.Size = new Size(109, 20);
            habilitadoCheckBox.TabIndex = 0;
            habilitadoCheckBox.TabStop = false;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(23, 148);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 7;
            nombreLabel.Text = "Nombre";
            nombreLabel.Click += nombreLabel_Click;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(130, 148);
            nombreTextBox.Margin = new Padding(2);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(147, 23);
            nombreTextBox.TabIndex = 2;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(23, 198);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(49, 15);
            apellidoLabel.TabIndex = 10;
            apellidoLabel.Text = "apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(130, 196);
            apellidoTextBox.Margin = new Padding(3, 2, 3, 2);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(147, 23);
            apellidoTextBox.TabIndex = 11;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(130, 240);
            emailTextBox.Margin = new Padding(3, 2, 3, 2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(147, 23);
            emailTextBox.TabIndex = 13;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(23, 242);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 12;
            emailLabel.Text = "email";
            // 
            // cambiaClaveLabel
            // 
            cambiaClaveLabel.AutoSize = true;
            cambiaClaveLabel.Location = new Point(23, 278);
            cambiaClaveLabel.Name = "cambiaClaveLabel";
            cambiaClaveLabel.Size = new Size(75, 15);
            cambiaClaveLabel.TabIndex = 14;
            cambiaClaveLabel.Text = "cambiaClave";
            // 
            // idPersonaLabel
            // 
            idPersonaLabel.AutoSize = true;
            idPersonaLabel.Location = new Point(23, 316);
            idPersonaLabel.Name = "idPersonaLabel";
            idPersonaLabel.Size = new Size(59, 15);
            idPersonaLabel.TabIndex = 16;
            idPersonaLabel.Text = "idPersona";
            // 
            // cambiaClaveCheckBox
            // 
            cambiaClaveCheckBox.AutoSize = true;
            cambiaClaveCheckBox.Location = new Point(130, 278);
            cambiaClaveCheckBox.Margin = new Padding(3, 2, 3, 2);
            cambiaClaveCheckBox.Name = "cambiaClaveCheckBox";
            cambiaClaveCheckBox.Size = new Size(15, 14);
            cambiaClaveCheckBox.TabIndex = 17;
            cambiaClaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // idPersonaNumericUpDown
            // 
            idPersonaNumericUpDown.Location = new Point(130, 311);
            idPersonaNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            idPersonaNumericUpDown.Name = "idPersonaNumericUpDown";
            idPersonaNumericUpDown.Size = new Size(147, 23);
            idPersonaNumericUpDown.TabIndex = 18;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 417);
            Controls.Add(idPersonaNumericUpDown);
            Controls.Add(cambiaClaveCheckBox);
            Controls.Add(idPersonaLabel);
            Controls.Add(cambiaClaveLabel);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(habilitadoLabel);
            Controls.Add(habilitadoCheckBox);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(claveLabel);
            Controls.Add(claveTextBox);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreUsuarioLabel);
            Controls.Add(nombreUsuarioTextBox);
            Margin = new Padding(2);
            Name = "UsuarioDetalle";
            Text = "Detalle usuario";
            Load += UsuarioDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)idPersonaNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreUsuarioTextBox;
        private Label nombreUsuarioLabel;

        private Button aceptarButton;
        private Button cancelarButton;

        private Label claveLabel;
        private TextBox claveTextBox;

        private Label nombreLabel;
        private TextBox nombreTextBox;

        private Label habilitadoLabel;
        private CheckBox habilitadoCheckBox;

        private TextBox textBox1;
        private Label apellidoLabel;
        private TextBox apellidoTextBox;
        private TextBox emailTextBox;
        private Label emailLabel;
        private Label cambiaClaveLabel;
        private Label idPersonaLabel;
        private CheckBox cambiaClaveCheckBox;
        private NumericUpDown idPersonaNumericUpDown;
    }
}