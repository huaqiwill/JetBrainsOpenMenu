using System;
using System.IO;
using System.Windows.Forms;
using JetBrainsOpenMenu.Core;

namespace JetBrainsOpenMenu
{
    public partial class MenuForm : Form
    {
        private bool isEdit;
        private Core.Menu data;

        public MenuForm(Core.Menu data = null)
        {
            InitializeComponent();
            if (data == null)
            {
                isEdit = false;
                textBox_menuKey.ReadOnly = true;
            }
            else
            {
                this.data = data;
                isEdit = true;
            }
        }

        //选择文件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "可执行文件文件 (*.exe)|*.exe|所有文件 (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string menuPath = openFileDialog.FileName;
                string menuRoot = Path.GetFileNameWithoutExtension(menuPath);

                textBox_menuPath.Text = menuPath;
                if (!isEdit)
                {
                    textBox_menuKey.Text = menuRoot;
                }
            }
        }

       

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_menuPath.Text))
            {
                MessageBox.Show("请输入菜单路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox_menuName.Text))
            {
                MessageBox.Show("请输入菜单名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox_menuKey.Text))
            {
                MessageBox.Show("请输入菜单Key", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isEdit)
            {
                data.Name = textBox_menuName.Text;
                data.Key = textBox_menuKey.Text;
                data.Path = textBox_menuPath.Text;

                if (!MenuEnvUtils.MenuExist(data))
                {
                    MessageBox.Show("注册表键不存在");
                    return;
                }

                try
                {
                    MenuUtils.MenuUpdate(data.Key, data);
                    MenuEnvUtils.MenuUpdate(data);
                    MessageBox.Show("注册表项更新成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                data = new Core.Menu()
                {
                    Name = textBox_menuName.Text,
                    Key = textBox_menuKey.Text,
                    Path = textBox_menuPath.Text,
                };

                if (MenuEnvUtils.MenuExist(data))
                {
                    MessageBox.Show("注册表键已存在");
                    return;
                }

                try
                {
                    MenuUtils.MenuAdd(data);
                    MenuEnvUtils.MenuAdd(data);
                    MessageBox.Show("注册表项添加成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                textBox_menuPath.Text = data.Path;
                textBox_menuName.Text = data.Name;
                textBox_menuKey.Text = data.Key;
            }
        }


    }
}
