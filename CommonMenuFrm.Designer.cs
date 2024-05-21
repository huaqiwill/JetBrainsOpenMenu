namespace JetBrainsOpenMenu
{
    partial class CommonMenuFrm
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
            this.button_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_menuName = new System.Windows.Forms.TextBox();
            this.label_menuRoot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_menuPath
            // 
            this.textBox_menuPath.Location = new System.Drawing.Point(103, 49);
            this.textBox_menuPath.Name = "textBox_menuPath";
            this.textBox_menuPath.Size = new System.Drawing.Size(472, 30);
            this.textBox_menuPath.TabIndex = 0;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(581, 49);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(62, 30);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "...";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(420, 160);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 36);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "添加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(501, 160);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 36);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "菜单名称";
            // 
            // textBox_menuName
            // 
            this.textBox_menuName.Location = new System.Drawing.Point(103, 98);
            this.textBox_menuName.Name = "textBox_menuName";
            this.textBox_menuName.Size = new System.Drawing.Size(472, 30);
            this.textBox_menuName.TabIndex = 6;
            // 
            // label_menuRoot
            // 
            this.label_menuRoot.AutoSize = true;
            this.label_menuRoot.Location = new System.Drawing.Point(8, 168);
            this.label_menuRoot.Name = "label_menuRoot";
            this.label_menuRoot.Size = new System.Drawing.Size(89, 20);
            this.label_menuRoot.TabIndex = 7;
            this.label_menuRoot.Text = "配置成功";
            // 
            // CommonMenuFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(653, 226);
            this.Controls.Add(this.label_menuRoot);
            this.Controls.Add(this.textBox_menuName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.textBox_menuPath);
            this.MaximizeBox = false;
            this.Name = "CommonMenuFrm";
            this.Text = "通用菜单配置工具";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 620, 152);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_menuPath;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_menuName;
        private System.Windows.Forms.Label label_menuRoot;
    }
}

