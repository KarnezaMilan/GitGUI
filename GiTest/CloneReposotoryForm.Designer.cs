namespace GiTest
{
    partial class CloneReposotoryForm
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
            this.textBox_remote = new System.Windows.Forms.TextBox();
            this.textBox_local = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Clone = new System.Windows.Forms.Button();
            this.btn_paste = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_remote
            // 
            this.textBox_remote.Location = new System.Drawing.Point(102, 45);
            this.textBox_remote.Name = "textBox_remote";
            this.textBox_remote.Size = new System.Drawing.Size(290, 20);
            this.textBox_remote.TabIndex = 0;
            // 
            // textBox_local
            // 
            this.textBox_local.Location = new System.Drawing.Point(102, 92);
            this.textBox_local.Name = "textBox_local";
            this.textBox_local.Size = new System.Drawing.Size(290, 20);
            this.textBox_local.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL Paht";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path on comp";
            // 
            // btn_Clone
            // 
            this.btn_Clone.Location = new System.Drawing.Point(407, 145);
            this.btn_Clone.Name = "btn_Clone";
            this.btn_Clone.Size = new System.Drawing.Size(75, 23);
            this.btn_Clone.TabIndex = 4;
            this.btn_Clone.Text = "Clone";
            this.btn_Clone.UseVisualStyleBackColor = true;
            this.btn_Clone.Click += new System.EventHandler(this.btn_Clone_Click);
            // 
            // btn_paste
            // 
            this.btn_paste.Location = new System.Drawing.Point(407, 43);
            this.btn_paste.Name = "btn_paste";
            this.btn_paste.Size = new System.Drawing.Size(75, 23);
            this.btn_paste.TabIndex = 5;
            this.btn_paste.Text = "Paste";
            this.btn_paste.UseVisualStyleBackColor = true;
            this.btn_paste.Click += new System.EventHandler(this.btn_paste_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(407, 88);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // CloneReposotoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 204);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_paste);
            this.Controls.Add(this.btn_Clone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_local);
            this.Controls.Add(this.textBox_remote);
            this.Name = "CloneReposotoryForm";
            this.Text = "CloneReposotory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_remote;
        private System.Windows.Forms.TextBox textBox_local;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Clone;
        private System.Windows.Forms.Button btn_paste;
        private System.Windows.Forms.Button btn_search;
    }
}