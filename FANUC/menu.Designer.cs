namespace FANUC
{
    partial class menu
    {
        /// <summary>
        /// 必需的設計器變量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的資源。
        /// </summary>
        /// <param name="disposing">如果應釋放託管資源，為 true；否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗體設計器生成的代碼

        /// <summary>
        /// 設計器支持所需的方法 - 不要
        /// 使用代碼編輯器修改此方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("55");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.傳輸設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.傳輸設定ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新增設備ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理設備ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1684, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.傳輸設定ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // 傳輸設定ToolStripMenuItem
            // 
            this.傳輸設定ToolStripMenuItem.Name = "傳輸設定ToolStripMenuItem";
            this.傳輸設定ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.傳輸設定ToolStripMenuItem.Text = "傳輸設定";
            this.傳輸設定ToolStripMenuItem.Click += new System.EventHandler(this.傳輸設定ToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.傳輸設定ToolStripMenuItem1,
            this.基本設定ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1684, 24);
            this.menuStrip2.TabIndex = 43;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(79, 20);
            this.toolStripMenuItem1.Text = "匯出入設定";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem3.Text = "匯出介面設定";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem4.Text = "匯入介面設定";
            // 
            // 傳輸設定ToolStripMenuItem1
            // 
            this.傳輸設定ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增設備ToolStripMenuItem,
            this.管理設備ToolStripMenuItem});
            this.傳輸設定ToolStripMenuItem1.Name = "傳輸設定ToolStripMenuItem1";
            this.傳輸設定ToolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.傳輸設定ToolStripMenuItem1.Text = "傳輸設定";
            this.傳輸設定ToolStripMenuItem1.Click += new System.EventHandler(this.傳輸設定ToolStripMenuItem1_Click);
            // 
            // 新增設備ToolStripMenuItem
            // 
            this.新增設備ToolStripMenuItem.Name = "新增設備ToolStripMenuItem";
            this.新增設備ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.新增設備ToolStripMenuItem.Text = "新增設備";
            this.新增設備ToolStripMenuItem.Click += new System.EventHandler(this.新增設備ToolStripMenuItem_Click);
            // 
            // 管理設備ToolStripMenuItem
            // 
            this.管理設備ToolStripMenuItem.Name = "管理設備ToolStripMenuItem";
            this.管理設備ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.管理設備ToolStripMenuItem.Text = "管理設備";
            this.管理設備ToolStripMenuItem.Click += new System.EventHandler(this.管理設備ToolStripMenuItem_Click);
            // 
            // 基本設定ToolStripMenuItem
            // 
            this.基本設定ToolStripMenuItem.Name = "基本設定ToolStripMenuItem";
            this.基本設定ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.基本設定ToolStripMenuItem.Text = "基本設定";
            this.基本設定ToolStripMenuItem.Click += new System.EventHandler(this.基本設定ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "本地資料夾";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(26, 62);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "55";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(299, 278);
            this.treeView1.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(22, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "CNC設備";
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(26, 383);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(299, 358);
            this.treeView2.TabIndex = 47;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(376, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(827, 280);
            this.listBox1.TabIndex = 48;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(376, 383);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(827, 358);
            this.listView1.TabIndex = 49;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 762);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "menu";
            this.Text = "FANUC CNC 揚恩科技  API測試";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menu_FormClosing);
            this.Load += new System.EventHandler(this.menu_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 傳輸設定ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 傳輸設定ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 基本設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增設備ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理設備ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView listView1;
    }
}

