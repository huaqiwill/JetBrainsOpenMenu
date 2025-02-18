using System;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using JetBrainsOpenMenu.Core;

namespace JetBrainsOpenMenu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; // 不允许双击编辑

            LoadData();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var frm = new MenuForm();
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            var dataList = MenuUtils.GetAllItems();
            foreach (var item in dataList)
            {
                string str = "无配置";
                if (MenuEnvUtils.MenuExist(item))
                {
                    str = "配置";
                }
                int rowIndex = dataGridView1.Rows.Add(item.Name, item.Key, item.Path, str);
                dataGridView1.Rows[rowIndex].Tag = item;
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
                return;
            }

            var data = (Core.Menu)dataGridView1.SelectedRows[0].Tag;
            var frm = new MenuForm(data);
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                LoadData();
            }
        }

        // 删除
        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
                return;
            }

            var data = (Core.Menu)dataGridView1.SelectedRows[0].Tag;
            var dr = MessageBox.Show("确定删除吗？", "标题", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    MenuUtils.MenuDelete(data.Key);
                    MenuEnvUtils.MenuDelete(data);
                    LoadData();
                    MessageBox.Show("注册表项已成功删除。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除注册表项时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
                return;
            }
            var data = (Core.Menu)dataGridView1.SelectedRows[0].Tag;

            if (MenuEnvUtils.MenuExist(data))
            {
                MessageBox.Show("已存在");
                return;
            }

            try
            {
                MenuEnvUtils.MenuAdd(data);
                LoadData();
                MessageBox.Show("配置成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置失败" + ex.Message);
            }
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据");
                return;
            }
            var data = (Core.Menu)dataGridView1.SelectedRows[0].Tag;

            if (!MenuEnvUtils.MenuExist(data))
            {
                MessageBox.Show("已移除");
                return;
            }

            try
            {
                MenuEnvUtils.MenuDelete(data);
                LoadData();
                MessageBox.Show("配置成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("配置失败" + ex.Message);
            }
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            uiButton2_Click(sender, e);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Height = Height;
            dataGridView1.Width = Width - 20;
        }
    }
}
