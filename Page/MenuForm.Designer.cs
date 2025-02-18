namespace JetBrainsOpenMenu
{
    partial class MenuForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_menuPath = new System.Windows.Forms.TextBox();
            this.button_select = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_menuName = new System.Windows.Forms.TextBox();
            this.label_menuRoot = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_menuKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_menuPath
            // 
            this.textBox_menuPath.Location = new System.Drawing.Point(111, 12);
            this.textBox_menuPath.Name = "textBox_menuPath";
            this.textBox_menuPath.Size = new System.Drawing.Size(408, 25);
            this.textBox_menuPath.TabIndex = 0;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(521, 10);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(62, 30);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "...";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(508, 149);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 36);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "保存";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "菜单名称";
            // 
            // textBox_menuName
            // 
            this.textBox_menuName.Location = new System.Drawing.Point(111, 57);
            this.textBox_menuName.Name = "textBox_menuName";
            this.textBox_menuName.Size = new System.Drawing.Size(472, 25);
            this.textBox_menuName.TabIndex = 6;
            // 
            // label_menuRoot
            // 
            this.label_menuRoot.AutoSize = true;
            this.label_menuRoot.Location = new System.Drawing.Point(16, 160);
            this.label_menuRoot.Name = "label_menuRoot";
            this.label_menuRoot.Size = new System.Drawing.Size(196, 15);
            this.label_menuRoot.TabIndex = 7;
            this.label_menuRoot.Text = "菜单Key一经创建，不能修改";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "菜单Key";
            // 
            // textBox_menuKey
            // 
            this.textBox_menuKey.Location = new System.Drawing.Point(111, 102);
            this.textBox_menuKey.Name = "textBox_menuKey";
            this.textBox_menuKey.Size = new System.Drawing.Size(472, 25);
            this.textBox_menuKey.TabIndex = 9;
            // 
            // MenuForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(597, 198);
            this.Controls.Add(this.textBox_menuKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_menuRoot);
            this.Controls.Add(this.textBox_menuName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.textBox_menuPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通用菜单配置工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_menuPath;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_menuName;
        private System.Windows.Forms.Label label_menuRoot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_menuKey;
    }
}

