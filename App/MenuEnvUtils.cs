using System;
using System.IO;
using JetBrainsOpenMenu.Core;
using Microsoft.Win32;

namespace JetBrainsOpenMenu
{
    //菜单管理工具
    public class MenuEnvUtils
    {
        //菜单是否已经存在
        public static bool MenuExist(Menu menu)
        {
            string menuRoot = menu.Key;
            string menuName = menu.Name;
            string menuRootRet = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", "");
            return menuRootRet == menuName;
        }

        //添加菜单项
        public static void MenuAdd(Menu menu)
        {
            string menuPath = menu.Path;
            string menuName = menu.Name;
            string menuRoot = menu.Key;

            if (string.IsNullOrEmpty(menuPath) || string.IsNullOrEmpty(menuName) || string.IsNullOrEmpty(menuRoot))
            {
                throw new Exception("存在空数据");
            }

            if (!File.Exists(menuPath))
            {
                throw new Exception("路径不存在");
            }

            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", menuName);
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "Icon", "\"" + menuPath + "\"");
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot + @"\command", "", "\"" + menuPath + "\" \"%V\"");
        }

        //修改菜单名称
        public static void MenuUpdate(Menu menu)
        {
            string menuName = menu.Name;
            string menuRoot = menu.Key;

            if (string.IsNullOrEmpty(menuName) || string.IsNullOrEmpty(menuRoot))
            {
                throw new Exception("存在空数据");
            }

            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\" + menuRoot, "", menuName);
        }

        //删除菜单项
        public static void MenuDelete(Menu menu)
        {
            string menuRoot = menu.Key;

            if (string.IsNullOrEmpty(menuRoot))
            {
                throw new Exception("存在空数据");
            }

            Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\shell\" + menuRoot, false);
        }
    }
}
