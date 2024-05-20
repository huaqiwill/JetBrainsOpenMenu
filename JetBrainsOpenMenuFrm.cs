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
using System.Configuration;
using SharpConfig;

namespace JetBrainsOpenMenu
{
    public enum JetBrainsType
    {
        IDEA,
        GoLand,
        WebStorm,
        PyCharm,
        PhpStorm,
        CLion
    }

    public partial class JetBrainsOpenMenuFrm : UIForm
    {
        private Configuration conf;

        private string jetBrainsIniFilePath = "./jetbrains_menu.ini";

        public JetBrainsOpenMenuFrm()
        {
            InitializeComponent();
        }

        private bool MenuExist(JetBrainsType key)
        {
            string key_ = key.ToString();
            string menuPath = conf[key_]["path"].StringValue;
            string menuRoot = Path.GetFileNameWithoutExtension(menuPath);
            string menuRootRet = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + key, "", "");
            return menuRootRet == menuRoot;
        }

        private void MenuAdd(JetBrainsType key)
        {
            string key_ = key.ToString();
            string menuPath = conf[key_]["path"].StringValue;
            string menuName = conf[key_]["name"].StringValue;
            if (string.IsNullOrEmpty(menuPath) || string.IsNullOrEmpty(menuName))
            {
                MessageBox.Show("还没有配置" + key_ + "的路径", "请检查配置项", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string menuRoot = Path.GetFileNameWithoutExtension(menuPath);
            try
            {
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", menuName);
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "Icon", "\"" + menuPath + "\"");
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot + @"\command", "", "\"" + menuPath + "\" \"%V\"");

                MessageBox.Show("注册表项添加成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuUpdate(JetBrainsType key)
        {
            string key_ = key.ToString();
            string menuPath = conf[key_]["path"].StringValue;
            string menuName = conf[key_]["name"].StringValue;
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

        private void MenuDelete(JetBrainsType key)
        {
            string key_ = key.ToString();
            string menuPath = conf[key_]["path"].StringValue;
            if (string.IsNullOrEmpty(menuPath))
            {
                MessageBox.Show("还没有配置" + key_ + "的路径", "请检查配置项", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            if (!File.Exists(jetBrainsIniFilePath)) File.Create(jetBrainsIniFilePath).Close();
            conf = Configuration.LoadFromFile(jetBrainsIniFilePath);

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;

            textBox1.Text = conf[JetBrainsType.IDEA.ToString()]["path"].StringValue;
            textBox2.Text = conf[JetBrainsType.GoLand.ToString()]["path"].StringValue;
            textBox3.Text = conf[JetBrainsType.WebStorm.ToString()]["path"].StringValue;
            textBox4.Text = conf[JetBrainsType.PyCharm.ToString()]["path"].StringValue;
            textBox5.Text = conf[JetBrainsType.PhpStorm.ToString()]["path"].StringValue;
            textBox6.Text = conf[JetBrainsType.CLion.ToString()]["path"].StringValue;
        }

        private string SelectFile(JetBrainsType key)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "可执行文件文件 (*.exe)|*.exe|所有文件 (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string key_ = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                //if (key_.ToLower() != key.ToLower()) return string.Empty;
                string key_ = key.ToString();
                conf[key_]["path"].StringValue = openFileDialog.FileName;
                conf[key_]["name"].StringValue = "通过 " + key + " 打开";
                conf.SaveToFile(jetBrainsIniFilePath);
                return openFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, 0, button1.Height);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(button2, 0, button2.Height);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = SelectFile(JetBrainsType.IDEA);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = SelectFile(JetBrainsType.GoLand);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = SelectFile(JetBrainsType.WebStorm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = SelectFile(JetBrainsType.PyCharm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = SelectFile(JetBrainsType.PhpStorm);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = SelectFile(JetBrainsType.CLion);
        }

        private void 添加IDEA菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuAdd(JetBrainsType.IDEA);
        }

        private void 添加GoLand菜单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MenuAdd(JetBrainsType.GoLand);
        }

        private void 添加WebStorm菜单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MenuAdd(JetBrainsType.WebStorm);
        }

        private void 添加PyChaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuAdd(JetBrainsType.PyCharm);
        }

        private void 添加PhpStorm菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuAdd(JetBrainsType.PhpStorm);
        }

        private void 添加CLion菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuAdd(JetBrainsType.CLion);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MenuDelete(JetBrainsType.IDEA);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MenuDelete(JetBrainsType.GoLand);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MenuDelete(JetBrainsType.WebStorm);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MenuDelete(JetBrainsType.PyCharm);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            MenuDelete(JetBrainsType.PhpStorm);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            MenuDelete(JetBrainsType.CLion);
        }
    }
}
