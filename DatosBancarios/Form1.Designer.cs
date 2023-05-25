namespace DatosBancarios
{
    partial class Form1
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
            button1 = new Button();
            tbMail = new TextBox();
            tbDirImap = new TextBox();
            tbContraseña = new TextBox();
            cbBancosMail = new ComboBox();
            botonMail = new Button();
            cbIdiomas = new ComboBox();
            botonIdioma = new Button();
            textBox1 = new TextBox();
            botonContraseña = new Button();
            checkExtraer = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(833, 417);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(159, 31);
            button1.TabIndex = 0;
            button1.Text = "pruebas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // tbMail
            // 
            tbMail.Location = new Point(12, 12);
            tbMail.Name = "tbMail";
            tbMail.Size = new Size(248, 27);
            tbMail.TabIndex = 1;
            // 
            // tbDirImap
            // 
            tbDirImap.Location = new Point(12, 45);
            tbDirImap.Name = "tbDirImap";
            tbDirImap.Size = new Size(248, 27);
            tbDirImap.TabIndex = 2;
            // 
            // tbContraseña
            // 
            tbContraseña.Location = new Point(12, 78);
            tbContraseña.Name = "tbContraseña";
            tbContraseña.Size = new Size(248, 27);
            tbContraseña.TabIndex = 3;
            // 
            // cbBancosMail
            // 
            cbBancosMail.FormattingEnabled = true;
            cbBancosMail.Location = new Point(12, 111);
            cbBancosMail.Name = "cbBancosMail";
            cbBancosMail.Size = new Size(248, 28);
            cbBancosMail.TabIndex = 4;
            // 
            // botonMail
            // 
            botonMail.Location = new Point(12, 145);
            botonMail.Name = "botonMail";
            botonMail.Size = new Size(93, 29);
            botonMail.TabIndex = 5;
            botonMail.Text = "button2";
            botonMail.UseVisualStyleBackColor = true;
            // 
            // cbIdiomas
            // 
            cbIdiomas.FormattingEnabled = true;
            cbIdiomas.Location = new Point(841, 12);
            cbIdiomas.Name = "cbIdiomas";
            cbIdiomas.Size = new Size(151, 28);
            cbIdiomas.TabIndex = 6;
            // 
            // botonIdioma
            // 
            botonIdioma.Location = new Point(898, 46);
            botonIdioma.Name = "botonIdioma";
            botonIdioma.Size = new Size(94, 29);
            botonIdioma.TabIndex = 7;
            botonIdioma.Text = "button2";
            botonIdioma.UseVisualStyleBackColor = true;
            botonIdioma.Click += botonIdioma_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 205);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(248, 27);
            textBox1.TabIndex = 8;
            // 
            // botonContraseña
            // 
            botonContraseña.Location = new Point(12, 238);
            botonContraseña.Name = "botonContraseña";
            botonContraseña.Size = new Size(93, 29);
            botonContraseña.TabIndex = 9;
            botonContraseña.Text = "button2";
            botonContraseña.UseVisualStyleBackColor = true;
            // 
            // checkExtraer
            // 
            checkExtraer.AutoSize = true;
            checkExtraer.Location = new Point(12, 273);
            checkExtraer.Name = "checkExtraer";
            checkExtraer.Size = new Size(101, 24);
            checkExtraer.TabIndex = 10;
            checkExtraer.Text = "checkBox1";
            checkExtraer.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 461);
            Controls.Add(checkExtraer);
            Controls.Add(botonContraseña);
            Controls.Add(textBox1);
            Controls.Add(botonIdioma);
            Controls.Add(cbIdiomas);
            Controls.Add(botonMail);
            Controls.Add(cbBancosMail);
            Controls.Add(tbContraseña);
            Controls.Add(tbDirImap);
            Controls.Add(tbMail);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox tbMail;
        private TextBox tbDirImap;
        private TextBox tbContraseña;
        private ComboBox cbBancosMail;
        private Button botonMail;
        private ComboBox cbIdiomas;
        private Button botonIdioma;
        private TextBox textBox1;
        private Button botonContraseña;
        private CheckBox checkExtraer;
    }
}