namespace WindowsFormsCurso
{
    partial class InicioSesion
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
            usuarioLabel = new Label();
            contraseñaLabel = new Label();
            iniciarSesionButton = new Button();
            usuarioTextBox = new TextBox();
            contraseñaTextBox = new TextBox();
            SuspendLayout();
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Location = new Point(53, 71);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(59, 20);
            usuarioLabel.TabIndex = 0;
            usuarioLabel.Text = "Usuario";
            // 
            // contraseñaLabel
            // 
            contraseñaLabel.AutoSize = true;
            contraseñaLabel.Location = new Point(53, 128);
            contraseñaLabel.Name = "contraseñaLabel";
            contraseñaLabel.Size = new Size(83, 20);
            contraseñaLabel.TabIndex = 1;
            contraseñaLabel.Text = "Contraseña";
            // 
            // iniciarSesionButton
            // 
            iniciarSesionButton.Location = new Point(113, 224);
            iniciarSesionButton.Margin = new Padding(3, 4, 3, 4);
            iniciarSesionButton.Name = "iniciarSesionButton";
            iniciarSesionButton.Size = new Size(211, 59);
            iniciarSesionButton.TabIndex = 2;
            iniciarSesionButton.Text = "Iniciar Sesion";
            iniciarSesionButton.UseVisualStyleBackColor = true;
            iniciarSesionButton.Click += iniciarSesionButton_Click;
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(173, 67);
            usuarioTextBox.Margin = new Padding(3, 4, 3, 4);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(209, 27);
            usuarioTextBox.TabIndex = 3;
            // 
            // contraseñaTextBox
            // 
            contraseñaTextBox.Location = new Point(173, 124);
            contraseñaTextBox.Margin = new Padding(3, 4, 3, 4);
            contraseñaTextBox.Name = "contraseñaTextBox";
            contraseñaTextBox.Size = new Size(209, 27);
            contraseñaTextBox.TabIndex = 4;
            // 
            // InicioSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 299);
            Controls.Add(contraseñaTextBox);
            Controls.Add(usuarioTextBox);
            Controls.Add(iniciarSesionButton);
            Controls.Add(contraseñaLabel);
            Controls.Add(usuarioLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InicioSesion";
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usuarioLabel;
        private Label contraseñaLabel;
        private Button iniciarSesionButton;
        private TextBox usuarioTextBox;
        private TextBox contraseñaTextBox;
    }
}