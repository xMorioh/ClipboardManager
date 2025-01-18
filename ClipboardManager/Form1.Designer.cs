namespace ClipboardManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1_1 = new System.Windows.Forms.TextBox();
            this.textBox1_2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2_1 = new System.Windows.Forms.TextBox();
            this.textBox2_2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1_1
            // 
            this.textBox1_1.Location = new System.Drawing.Point(12, 12);
            this.textBox1_1.Name = "textBox1_1";
            this.textBox1_1.Size = new System.Drawing.Size(100, 20);
            this.textBox1_1.TabIndex = 0;
            this.textBox1_1.TextChanged += new System.EventHandler(this.textBox1_1_TextChanged);
            // 
            // textBox1_2
            // 
            this.textBox1_2.Location = new System.Drawing.Point(118, 12);
            this.textBox1_2.Name = "textBox1_2";
            this.textBox1_2.Size = new System.Drawing.Size(100, 20);
            this.textBox1_2.TabIndex = 1;
            this.textBox1_2.TextChanged += new System.EventHandler(this.textBox1_2_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(224, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2_1
            // 
            this.textBox2_1.Location = new System.Drawing.Point(12, 38);
            this.textBox2_1.Name = "textBox2_1";
            this.textBox2_1.Size = new System.Drawing.Size(100, 20);
            this.textBox2_1.TabIndex = 3;
            this.textBox2_1.TextChanged += new System.EventHandler(this.textBox2_1_TextChanged);
            // 
            // textBox2_2
            // 
            this.textBox2_2.Location = new System.Drawing.Point(118, 38);
            this.textBox2_2.Name = "textBox2_2";
            this.textBox2_2.Size = new System.Drawing.Size(100, 20);
            this.textBox2_2.TabIndex = 4;
            this.textBox2_2.TextChanged += new System.EventHandler(this.textBox2_2_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(224, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 217);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox2_2);
            this.Controls.Add(this.textBox2_1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1_2);
            this.Controls.Add(this.textBox1_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 256);
            this.MinimumSize = new System.Drawing.Size(400, 256);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Clipboard Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_1;
        private System.Windows.Forms.TextBox textBox1_2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2_1;
        private System.Windows.Forms.TextBox textBox2_2;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

