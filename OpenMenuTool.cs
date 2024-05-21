using Microsoft.Win32;
using SharpConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JetBrainsOpenMenu
{
    // 菜单管理工具
    public class OpenMenuTool
    {
        // 配置项
        private static Configuration conf = Configuration.LoadFromFile("");

        /// <summary>
        /// 菜单是否已经存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool MenuExist(JetBrainsType key)
        {
            string key_ = key.ToString();
            string menuPath = conf[key_]["path"].StringValue;
            string menuRoot = Path.GetFileNameWithoutExtension(menuPath);
            string menuRootRet = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + key, "", "");
            return menuRootRet == menuRoot;
        }

        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="key"></param>
        public static void MenuAdd(JetBrainsType key)
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

        /// <summary>
        /// 修改菜单名称
        /// </summary>
        /// <param name="key"></param>
        public static void MenuUpdate(JetBrainsType key)
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

        /// <summary>
        /// 删除菜单项
        /// </summary>
        /// <param name="key"></param>
        public static void MenuDelete(JetBrainsType key)
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

    }
}
