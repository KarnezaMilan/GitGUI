namespace GiTest
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openReposotoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.branchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RescanBTN = new System.Windows.Forms.Button();
            this.CommitBTN = new System.Windows.Forms.Button();
            this.AddBTN = new System.Windows.Forms.Button();
            this.PullBNT = new System.Windows.Forms.Button();
            this.PushBTN = new System.Windows.Forms.Button();
            this.listViewStatus = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.CommitBTN2 = new System.Windows.Forms.Button();
            this.BranchLAB = new System.Windows.Forms.Label();
            this.FIleLAB = new System.Windows.Forms.Label();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem,
            this.branchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.openReposotoryToolStripMenuItem,
            this.closeToolStripMenuItem1,
            this.closeToolStripMenuItem2});
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.datotekaToolStripMenuItem.Text = "Reposotory";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.closeToolStripMenuItem.Text = "Create";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // openReposotoryToolStripMenuItem
            // 
            this.openReposotoryToolStripMenuItem.Name = "openReposotoryToolStripMenuItem";
            this.openReposotoryToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openReposotoryToolStripMenuItem.Text = "Open";
            this.openReposotoryToolStripMenuItem.Click += new System.EventHandler(this.openReposotoryToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.closeToolStripMenuItem1.Text = "Clone";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // closeToolStripMenuItem2
            // 
            this.closeToolStripMenuItem2.Name = "closeToolStripMenuItem2";
            this.closeToolStripMenuItem2.Size = new System.Drawing.Size(108, 22);
            this.closeToolStripMenuItem2.Text = "Close";
            this.closeToolStripMenuItem2.Click += new System.EventHandler(this.closeToolStripMenuItem2_Click);
            // 
            // branchToolStripMenuItem
            // 
            this.branchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.editToolStripMenuItem});
            this.branchToolStripMenuItem.Name = "branchToolStripMenuItem";
            this.branchToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.branchToolStripMenuItem.Text = "Branch";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.createToolStripMenuItem.Text = "Create ...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.editToolStripMenuItem.Text = "Edit ...";
            // 
            // RescanBTN
            // 
            this.RescanBTN.Location = new System.Drawing.Point(88, 39);
            this.RescanBTN.Name = "RescanBTN";
            this.RescanBTN.Size = new System.Drawing.Size(70, 70);
            this.RescanBTN.TabIndex = 9;
            this.RescanBTN.Text = "Rescan";
            this.RescanBTN.UseVisualStyleBackColor = true;
            this.RescanBTN.Click += new System.EventHandler(this.RescanBTN_Click);
            // 
            // CommitBTN
            // 
            this.CommitBTN.Location = new System.Drawing.Point(240, 39);
            this.CommitBTN.Name = "CommitBTN";
            this.CommitBTN.Size = new System.Drawing.Size(70, 70);
            this.CommitBTN.TabIndex = 10;
            this.CommitBTN.Text = "Commit";
            this.CommitBTN.UseVisualStyleBackColor = true;
            // 
            // AddBTN
            // 
            this.AddBTN.Location = new System.Drawing.Point(164, 39);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(70, 70);
            this.AddBTN.TabIndex = 11;
            this.AddBTN.Text = "Add";
            this.AddBTN.UseVisualStyleBackColor = true;
            // 
            // PullBNT
            // 
            this.PullBNT.Location = new System.Drawing.Point(12, 39);
            this.PullBNT.Name = "PullBNT";
            this.PullBNT.Size = new System.Drawing.Size(70, 70);
            this.PullBNT.TabIndex = 12;
            this.PullBNT.Text = "Pull";
            this.PullBNT.UseVisualStyleBackColor = true;
            // 
            // PushBTN
            // 
            this.PushBTN.Location = new System.Drawing.Point(316, 39);
            this.PushBTN.Name = "PushBTN";
            this.PushBTN.Size = new System.Drawing.Size(70, 70);
            this.PushBTN.TabIndex = 13;
            this.PushBTN.Text = "Push";
            this.PushBTN.UseVisualStyleBackColor = true;
            // 
            // listViewStatus
            // 
            this.listViewStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnStatus});
            this.listViewStatus.Location = new System.Drawing.Point(12, 146);
            this.listViewStatus.Name = "listViewStatus";
            this.listViewStatus.Size = new System.Drawing.Size(287, 175);
            this.listViewStatus.TabIndex = 15;
            this.listViewStatus.UseCompatibleStateImageBehavior = false;
            this.listViewStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 88;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(12, 356);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(287, 164);
            this.listView2.TabIndex = 16;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(316, 146);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(588, 213);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(316, 366);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(588, 120);
            this.richTextBox2.TabIndex = 20;
            this.richTextBox2.Text = "";
            // 
            // CommitBTN2
            // 
            this.CommitBTN2.Location = new System.Drawing.Point(829, 497);
            this.CommitBTN2.Name = "CommitBTN2";
            this.CommitBTN2.Size = new System.Drawing.Size(75, 23);
            this.CommitBTN2.TabIndex = 21;
            this.CommitBTN2.Text = "Commit";
            this.CommitBTN2.UseVisualStyleBackColor = true;
            // 
            // BranchLAB
            // 
            this.BranchLAB.AutoSize = true;
            this.BranchLAB.Location = new System.Drawing.Point(316, 127);
            this.BranchLAB.Name = "BranchLAB";
            this.BranchLAB.Size = new System.Drawing.Size(157, 13);
            this.BranchLAB.TabIndex = 22;
            this.BranchLAB.Text = "//////////////////////////////";
            // 
            // FIleLAB
            // 
            this.FIleLAB.AutoSize = true;
            this.FIleLAB.Location = new System.Drawing.Point(639, 126);
            this.FIleLAB.Name = "FIleLAB";
            this.FIleLAB.Size = new System.Drawing.Size(35, 13);
            this.FIleLAB.TabIndex = 23;
            this.FIleLAB.Text = "label4";
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Location = new System.Drawing.Point(829, 39);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(75, 23);
            this.ConnectBTN.TabIndex = 24;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTN_Click);
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 132;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 592);
            this.Controls.Add(this.ConnectBTN);
            this.Controls.Add(this.FIleLAB);
            this.Controls.Add(this.BranchLAB);
            this.Controls.Add(this.CommitBTN2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listViewStatus);
            this.Controls.Add(this.PushBTN);
            this.Controls.Add(this.PullBNT);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.CommitBTN);
            this.Controls.Add(this.RescanBTN);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openReposotoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem branchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button RescanBTN;
        private System.Windows.Forms.Button CommitBTN;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button PullBNT;
        private System.Windows.Forms.Button PushBTN;
        private System.Windows.Forms.ListView listViewStatus;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button CommitBTN2;
        private System.Windows.Forms.Label BranchLAB;
        private System.Windows.Forms.Label FIleLAB;
        private System.Windows.Forms.Button ConnectBTN;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnStatus;


    }
}

