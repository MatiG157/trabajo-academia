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
            nombreUsuarioTextBox.Location = new Point(149, 24);
            nombreUsuarioTextBox.Margin = new Padding(2);
            nombreUsuarioTextBox.Name = "nombreUsuarioTextBox";
            nombreUsuarioTextBox.Size = new Size(167, 27);
            nombreUsuarioTextBox.TabIndex = 0;
            // 
            // nombreUsuarioLabel
            // 
            nombreUsuarioLabel.AutoSize = true;
            nombreUsuarioLabel.Location = new Point(26, 31);
            nombreUsuarioLabel.Margin = new Padding(2, 0, 2, 0);
            nombreUsuarioLabel.Name = "nombreUsuarioLabel";
            nombreUsuarioLabel.Size = new Size(111, 20);
            nombreUsuarioLabel.TabIndex = 1;
            nombreUsuarioLabel.Text = "nombreUsuario";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(339, 500);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(92, 29);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(453, 500);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(92, 29);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // claveLabel
            // 
            claveLabel.AutoSize = true;
            claveLabel.Location = new Point(26, 81);
            claveLabel.Margin = new Padding(2, 0, 2, 0);
            claveLabel.Name = "claveLabel";
            claveLabel.Size = new Size(43, 20);
            claveLabel.TabIndex = 5;
            claveLabel.Text = "clave";
            claveLabel.Click += claveLabel_Click;
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(149, 74);
            claveTextBox.Margin = new Padding(2);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new Size(167, 27);
            claveTextBox.TabIndex = 1;
            // 
            // habilitadoLabel
            // 
            habilitadoLabel.AutoSize = true;
            habilitadoLabel.Location = new Point(23, 142);
            habilitadoLabel.Margin = new Padding(2, 0, 2, 0);
            habilitadoLabel.Name = "habilitadoLabel";
            habilitadoLabel.Size = new Size(80, 20);
            habilitadoLabel.TabIndex = 9;
            habilitadoLabel.Text = "Habilitado";
            // 
            // habilitadoCheckBox
            // 
            habilitadoCheckBox.Location = new Point(149, 142);
            habilitadoCheckBox.Margin = new Padding(2);
            habilitadoCheckBox.Name = "habilitadoCheckBox";
            habilitadoCheckBox.Size = new Size(125, 27);
            habilitadoCheckBox.TabIndex = 0;
            habilitadoCheckBox.TabStop = false;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(26, 197);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 7;
            nombreLabel.Text = "Nombre";
            nombreLabel.Click += nombreLabel_Click;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(149, 197);
            nombreTextBox.Margin = new Padding(2);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(167, 27);
            nombreTextBox.TabIndex = 2;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(26, 264);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(64, 20);
            apellidoLabel.TabIndex = 10;
            apellidoLabel.Text = "apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(149, 261);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(167, 27);
            apellidoTextBox.TabIndex = 11;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(149, 320);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(167, 27);
            emailTextBox.TabIndex = 13;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(26, 323);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 12;
            emailLabel.Text = "email";
            // 
            // cambiaClaveLabel
            // 
            cambiaClaveLabel.AutoSize = true;
            cambiaClaveLabel.Location = new Point(26, 371);
            cambiaClaveLabel.Name = "cambiaClaveLabel";
            cambiaClaveLabel.Size = new Size(94, 20);
            cambiaClaveLabel.TabIndex = 14;
            cambiaClaveLabel.Text = "cambiaClave";
            // 
            // idPersonaLabel
            // 
            idPersonaLabel.AutoSize = true;
            idPersonaLabel.Location = new Point(26, 422);
            idPersonaLabel.Name = "idPersonaLabel";
            idPersonaLabel.Size = new Size(73, 20);
            idPersonaLabel.TabIndex = 16;
            idPersonaLabel.Text = "idPersona";
            // 
            // cambiaClaveCheckBox
            // 
            cambiaClaveCheckBox.AutoSize = true;
            cambiaClaveCheckBox.Location = new Point(149, 371);
            cambiaClaveCheckBox.Name = "cambiaClaveCheckBox";
            cambiaClaveCheckBox.Size = new Size(18, 17);
            cambiaClaveCheckBox.TabIndex = 17;
            cambiaClaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // idPersonaNumericUpDown
            // 
            idPersonaNumericUpDown.Location = new Point(149, 415);
            idPersonaNumericUpDown.Name = "idPersonaNumericUpDown";
            idPersonaNumericUpDown.Size = new Size(150, 27);
            idPersonaNumericUpDown.TabIndex = 18;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 556);
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
            Text = "Usuario";
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