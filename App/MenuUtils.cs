using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JetBrainsOpenMenu.Core
{
    public class MenuUtils
    {
        private readonly static string filePath = "./jetbrains_menu.txt";

        // 获取所有的 Data 列表
        public static List<Menu> GetAllItems()
        {
            List<Menu> dataList = new List<Menu>();
            // 读取所有行并遍历
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] items = line.Split(',');
                    if (items.Length == 3)  // 确保每行都包含3个元素
                    {
                        Menu data = new Menu()
                        {
                            Key = items[0],
                            Name = items[1],
                            Path = items[2]
                        };
                        dataList.Add(data);
                    }
                }
            }
            return dataList;
        }

        // 添加一行 Data
        public static void MenuAdd(Menu data)
        {
            string dataStr = $"{data.Key},{data.Name},{data.Path}";
            // 使用 File.AppendAllText 来简化写入操作
            File.AppendAllText(filePath, dataStr + Environment.NewLine);
        }

        // 删除一行 Data (通过 Key)
        public static void MenuDelete(string key)
        {
            List<Menu> dataList = GetAllItems();
            // 删除 Key 匹配的项
            dataList.RemoveAll(d => d.Key == key);

            // 将更新后的数据写回文件
            SaveAllItems(dataList);
        }

        // 修改一行 Data (通过 Key)
        public static void MenuUpdate(string key, Menu newData)
        {
            List<Menu> dataList = GetAllItems();
            // 查找并更新指定 Key 的项
            var existingData = dataList.FirstOrDefault(d => d.Key == key);
            if (existingData != null)
            {
                existingData.Key = newData.Key;
                existingData.Name = newData.Name;
                existingData.Path = newData.Path;
            }
            // 将更新后的数据写回文件
            SaveAllItems(dataList);
        }

        // 保存所有 Data 项到文件
        private static void SaveAllItems(List<Menu> dataList)
        {
            // 将列表中的所有 Data 转换为字符串并写回文件
            var lines = dataList.Select(d => $"{d.Key},{d.Name},{d.Path}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
