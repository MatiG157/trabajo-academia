namespace WindowsFormsCurso
{
    partial class Registrarse
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
            repitaContraseñaLabel = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            RegistrarButton = new Button();
            iniciarSesionLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Location = new Point(29, 42);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(47, 15);
            usuarioLabel.TabIndex = 0;
            usuarioLabel.Text = "Usuario";
            // 
            // contraseñaLabel
            // 
            contraseñaLabel.AutoSize = true;
            contraseñaLabel.Location = new Point(29, 81);
            contraseñaLabel.Name = "contraseñaLabel";
            contraseñaLabel.Size = new Size(67, 15);
            contraseñaLabel.TabIndex = 1;
            contraseñaLabel.Text = "Contraseña";
            // 
            // repitaContraseñaLabel
            // 
            repitaContraseñaLabel.AutoSize = true;
            repitaContraseñaLabel.Location = new Point(29, 119);
            repitaContraseñaLabel.Name = "repitaContraseñaLabel";
            repitaContraseñaLabel.Size = new Size(101, 15);
            repitaContraseñaLabel.TabIndex = 2;
            repitaContraseñaLabel.Text = "Repita contraseña";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(160, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(160, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(160, 119);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(213, 23);
            textBox3.TabIndex = 5;
            // 
            // RegistrarButton
            // 
            RegistrarButton.Location = new Point(106, 201);
            RegistrarButton.Name = "RegistrarButton";
            RegistrarButton.Size = new Size(164, 38);
            RegistrarButton.TabIndex = 6;
            RegistrarButton.Text = "Crear Cuenta";
            RegistrarButton.UseVisualStyleBackColor = true;
            // 
            // iniciarSesionLinkLabel
            // 
            iniciarSesionLinkLabel.AutoSize = true;
            iniciarSesionLinkLabel.Location = new Point(134, 172);
            iniciarSesionLinkLabel.Name = "iniciarSesionLinkLabel";
            iniciarSesionLinkLabel.Size = new Size(115, 15);
            iniciarSesionLinkLabel.TabIndex = 7;
            iniciarSesionLinkLabel.TabStop = true;
            iniciarSesionLinkLabel.Text = "Ya tengo una cuenta";
            iniciarSesionLinkLabel.LinkClicked += iniciarSesionLinkLabel_LinkClicked;
            // 
            // Registrarse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 272);
            Controls.Add(iniciarSesionLinkLabel);
            Controls.Add(RegistrarButton);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(repitaContraseñaLabel);
            Controls.Add(contraseñaLabel);
            Controls.Add(usuarioLabel);
            Name = "Registrarse";
            Text = "Registrarse";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usuarioLabel;
        private Label contraseñaLabel;
        private Label repitaContraseñaLabel;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button RegistrarButton;
        private LinkLabel iniciarSesionLinkLabel;
    }
}