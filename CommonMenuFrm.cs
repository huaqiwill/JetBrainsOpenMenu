using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny;
using Sunny.UI;

namespace JetBrainsOpenMenu
{
    public partial class CommonMenuFrm : UIForm
    {
        private bool is_add;

        public CommonMenuFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "可执行文件文件 (*.exe)|*.exe|所有文件 (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string menuPath = openFileDialog.FileName;
                string menuRoot = Path.GetFileNameWithoutExtension(menuPath);

                textBox_menuPath.Text = menuPath;
                label_menuRoot.Text = menuRoot;

                string menuName = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", "");
                if (!string.IsNullOrEmpty(menuName))
                {
                    textBox_menuName.Text = menuName;
                    button_add.Text = "修改";
                    is_add = false;
                }
                else
                {
                    button_add.Text = "添加";
                    is_add = true;
                }

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_menuPath.Text))
            {
                MessageBox.Show("请输入菜单路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            exec_delete(textBox_menuPath.Text);


            button_add.Text = "添加";
            is_add = true;
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

            string menuRoot = Path.GetFileNameWithoutExtension(textBox_menuPath.Text);
            label_menuRoot.Text = menuRoot;


            if (is_add)
            {
                exec_add(textBox_menuPath.Text, textBox_menuName.Text);
            }
            else
            {
                exec_update(textBox_menuPath.Text, textBox_menuName.Text);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="menuPath"></param>
        /// <param name="menuName"></param>
        private void exec_add(string menuPath, string menuName)
        {
            string menuRoot = Path.GetFileNameWithoutExtension(menuPath);

            try
            {
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", menuName);
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "Icon", "\"" + menuPath + "\"");
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot + @"\command", "", "\"" + menuPath + "\" \"%V\"");

                MessageBox.Show("注册表项已添加。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="menuPath"></param>
        /// <param name="menuName"></param>
        private void exec_update(string menuPath, string menuName)
        {
            string menuRoot = Path.GetFileNameWithoutExtension(menuPath);

            try
            {
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", menuName);
                MessageBox.Show("注册表项更新成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="menuPath"></param>
        private void exec_delete(string menuPath)
        {
            string menuRoot = Path.GetFileNameWithoutExtension(menuPath);
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\shell\" + menuRoot, false);
                MessageBox.Show("注册表项已成功删除。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void 添加JetBrains菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_menuName.Text = "使用 IDEA 打开";
        }
    }
}
