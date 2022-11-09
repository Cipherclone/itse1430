namespace JamesSparkman.ContactManager.UI
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._cbFavorite = new System.Windows.Forms.CheckBox();
            this._txtFirstName = new System.Windows.Forms.TextBox();
            this._txtLastName = new System.Windows.Forms.TextBox();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this._txtNotes = new System.Windows.Forms.TextBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-Mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Notes";
            // 
            // _cbFavorite
            // 
            this._cbFavorite.AutoSize = true;
            this._cbFavorite.Location = new System.Drawing.Point(82, 99);
            this._cbFavorite.Name = "_cbFavorite";
            this._cbFavorite.Size = new System.Drawing.Size(68, 19);
            this._cbFavorite.TabIndex = 5;
            this._cbFavorite.Text = "Favorite";
            this._cbFavorite.UseVisualStyleBackColor = true;
            // 
            // _txtFirstName
            // 
            this._txtFirstName.Location = new System.Drawing.Point(82, 12);
            this._txtFirstName.Name = "_txtFirstName";
            this._txtFirstName.Size = new System.Drawing.Size(152, 23);
            this._txtFirstName.TabIndex = 6;
            // 
            // _txtLastName
            // 
            this._txtLastName.Location = new System.Drawing.Point(82, 41);
            this._txtLastName.Name = "_txtLastName";
            this._txtLastName.Size = new System.Drawing.Size(152, 23);
            this._txtLastName.TabIndex = 7;
            // 
            // _txtEmail
            // 
            this._txtEmail.Location = new System.Drawing.Point(82, 70);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(237, 23);
            this._txtEmail.TabIndex = 8;
            // 
            // _txtNotes
            // 
            this._txtNotes.Location = new System.Drawing.Point(82, 124);
            this._txtNotes.Multiline = true;
            this._txtNotes.Name = "_txtNotes";
            this._txtNotes.Size = new System.Drawing.Size(237, 193);
            this._txtNotes.TabIndex = 9;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(277, 381);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(196, 381);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 11;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 416);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._txtNotes);
            this.Controls.Add(this._txtEmail);
            this.Controls.Add(this._txtLastName);
            this.Controls.Add(this._txtFirstName);
            this.Controls.Add(this._cbFavorite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ContactForm";
            this.Text = "Contact Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private CheckBox _cbFavorite;
        private TextBox _txtFirstName;
        private TextBox _txtLastName;
        private TextBox _txtEmail;
        private TextBox _txtNotes;
        private Button _btnCancel;
        private Button _btnSave;
    }
}