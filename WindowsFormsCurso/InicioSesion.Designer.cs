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
            registroLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Location = new Point(46, 53);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(47, 15);
            usuarioLabel.TabIndex = 0;
            usuarioLabel.Text = "Usuario";
            // 
            // contraseñaLabel
            // 
            contraseñaLabel.AutoSize = true;
            contraseñaLabel.Location = new Point(46, 96);
            contraseñaLabel.Name = "contraseñaLabel";
            contraseñaLabel.Size = new Size(67, 15);
            contraseñaLabel.TabIndex = 1;
            contraseñaLabel.Text = "Contraseña";
            // 
            // iniciarSesionButton
            // 
            iniciarSesionButton.Location = new Point(99, 168);
            iniciarSesionButton.Name = "iniciarSesionButton";
            iniciarSesionButton.Size = new Size(185, 44);
            iniciarSesionButton.TabIndex = 2;
            iniciarSesionButton.Text = "Iniciar Sesion";
            iniciarSesionButton.UseVisualStyleBackColor = true;
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(151, 50);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(183, 23);
            usuarioTextBox.TabIndex = 3;
            // 
            // contraseñaTextBox
            // 
            contraseñaTextBox.Location = new Point(151, 93);
            contraseñaTextBox.Name = "contraseñaTextBox";
            contraseñaTextBox.Size = new Size(183, 23);
            contraseñaTextBox.TabIndex = 4;
            // 
            // registroLinkLabel
            // 
            registroLinkLabel.AutoSize = true;
            registroLinkLabel.Location = new Point(138, 141);
            registroLinkLabel.Name = "registroLinkLabel";
            registroLinkLabel.Size = new Size(97, 15);
            registroLinkLabel.TabIndex = 5;
            registroLinkLabel.TabStop = true;
            registroLinkLabel.Text = "Crear una cuenta";
            registroLinkLabel.LinkClicked += registroLinkLabel_LinkClicked;
            // 
            // InicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 224);
            Controls.Add(registroLinkLabel);
            Controls.Add(contraseñaTextBox);
            Controls.Add(usuarioTextBox);
            Controls.Add(iniciarSesionButton);
            Controls.Add(contraseñaLabel);
            Controls.Add(usuarioLabel);
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
        private LinkLabel registroLinkLabel;
    }
}