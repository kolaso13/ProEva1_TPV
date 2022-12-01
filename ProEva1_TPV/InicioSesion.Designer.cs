namespace ProEva1_TPV
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
            this.textBox_contraseña = new System.Windows.Forms.TextBox();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.Label();
            this.contraseña = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_contraseña
            // 
            this.textBox_contraseña.Location = new System.Drawing.Point(140, 106);
            this.textBox_contraseña.Name = "textBox_contraseña";
            this.textBox_contraseña.Size = new System.Drawing.Size(100, 23);
            this.textBox_contraseña.TabIndex = 20;
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(140, 71);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(100, 23);
            this.textBox_usuario.TabIndex = 19;
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Location = new System.Drawing.Point(52, 74);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(47, 15);
            this.usuario.TabIndex = 18;
            this.usuario.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.AutoSize = true;
            this.contraseña.Location = new System.Drawing.Point(52, 114);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(67, 15);
            this.contraseña.TabIndex = 17;
            this.contraseña.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Iniciar Sesión";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(127, 158);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 15;
            this.login.Text = "Aceptar";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(52, 208);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 15);
            this.lblResultado.TabIndex = 14;
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 285);
            this.Controls.Add(this.textBox_contraseña);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.lblResultado);
            this.Name = "InicioSesion";
            this.Text = "InicioSesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox_contraseña;
        private TextBox textBox_usuario;
        private Label usuario;
        private Label contraseña;
        private Label label1;
        private Button login;
        private Label lblResultado;
    }
}