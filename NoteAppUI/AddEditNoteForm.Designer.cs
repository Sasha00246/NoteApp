using NoteApp;

namespace NoteAppUI
{
    partial class AddEditNoteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CreationTime = new System.Windows.Forms.DateTimePicker();
            this.TimeOfLastChange = new System.Windows.Forms.DateTimePicker();
            this.NoteText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(82, 12);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(421, 22);
            this.Title.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category:";
            // 
            // CategoryBox
            // 
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Items.AddRange(new object[] {
                EnumNoteCategory.Job,
                EnumNoteCategory.Home,
                EnumNoteCategory.HealthAndSports,
                EnumNoteCategory.People,
                EnumNoteCategory.Documents,
                EnumNoteCategory.Finance,
                EnumNoteCategory.Others});
            this.CategoryBox.Location = new System.Drawing.Point(82, 42);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(421, 24);
            this.CategoryBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Created:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modifeid:";
            // 
            // CreationTime
            // 
            this.CreationTime.Enabled = false;
            this.CreationTime.Location = new System.Drawing.Point(82, 83);
            this.CreationTime.Name = "CreationTime";
            this.CreationTime.Size = new System.Drawing.Size(170, 22);
            this.CreationTime.TabIndex = 6;
            // 
            // TimeOfLastChange
            // 
            this.TimeOfLastChange.Enabled = false;
            this.TimeOfLastChange.Location = new System.Drawing.Point(336, 83);
            this.TimeOfLastChange.Name = "TimeOfLastChange";
            this.TimeOfLastChange.Size = new System.Drawing.Size(167, 22);
            this.TimeOfLastChange.TabIndex = 7;
            // 
            // NoteText
            // 
            this.NoteText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoteText.Location = new System.Drawing.Point(3, 18);
            this.NoteText.Name = "NoteText";
            this.NoteText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.NoteText.Size = new System.Drawing.Size(491, 302);
            this.NoteText.TabIndex = 8;
            this.NoteText.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoteText);
            this.groupBox1.Location = new System.Drawing.Point(16, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 323);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(438, 452);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(336, 452);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 11;
            this.ConfirmButton.Text = "ОК";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // AddEditNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 483);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TimeOfLastChange);
            this.Controls.Add(this.CreationTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CategoryBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label1);
            this.Name = "AddEditNoteForm";
            this.Text = "Add/Edit Note";
            this.Shown += new System.EventHandler(this.AddEditNoteForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker CreationTime;
        private System.Windows.Forms.DateTimePicker TimeOfLastChange;
        private System.Windows.Forms.RichTextBox NoteText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
    }
}