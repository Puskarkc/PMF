namespace PMF
{
    partial class LoginPMF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPMF));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.btnLoginPMF = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PMF.Properties.Resources.login_screen_pmf;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 416);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.AcceptsReturn = true;
            this.txtBoxUserName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxUserName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUserName.Location = new System.Drawing.Point(423, 182);
            this.txtBoxUserName.Margin = new System.Windows.Forms.Padding(6);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(296, 32);
            this.txtBoxUserName.TabIndex = 1;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPassword.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword.Location = new System.Drawing.Point(423, 262);
            this.txtBoxPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(296, 29);
            this.txtBoxPassword.TabIndex = 2;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            this.txtBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordKeyDown);
            // 
            // btnLoginPMF
            // 
            this.btnLoginPMF.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLoginPMF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnLoginPMF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLoginPMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginPMF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginPMF.Location = new System.Drawing.Point(379, 320);
            this.btnLoginPMF.Name = "btnLoginPMF";
            this.btnLoginPMF.Size = new System.Drawing.Size(108, 34);
            this.btnLoginPMF.TabIndex = 3;
            this.btnLoginPMF.Text = "Login";
            this.btnLoginPMF.UseVisualStyleBackColor = false;
            this.btnLoginPMF.Click += new System.EventHandler(this.btnLoginPMF_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.LimeGreen;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(534, 320);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(185, 34);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // LoginPMF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 418);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnLoginPMF);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginPMF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginPMF";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Button btnLoginPMF;
        private System.Windows.Forms.Button btnContinue;
    }
}