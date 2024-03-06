using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VL.ColorSetter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 显示器颜色
        const int SPI_SETDESKCOLOR = 25;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            // 设置亮度
            SystemParametersInfo(SPI_SETDESKCOLOR, 1, "50", SPIF_UPDATEINIFILE | SPIF_SENDCHANGE); // 0-100 的值

            // 设置对比度
            SystemParametersInfo(SPI_SETDESKCOLOR, 2, "50", SPIF_UPDATEINIFILE | SPIF_SENDCHANGE); // 0-100 的值

            // 设置灰度
            SystemParametersInfo(SPI_SETDESKCOLOR, 3, "1", SPIF_UPDATEINIFILE | SPIF_SENDCHANGE); // 0 表示彩色，1 表示灰度
        }
        #endregion

        #region 桌面壁纸
        //const int SPI_SETDESKWALLPAPER = 20;
        //const int SPIF_UPDATEINIFILE = 0x01;
        //const int SPIF_SENDCHANGE = 0x02;

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        //private void buttonDefault_Click(object sender, EventArgs e)
        //{
        //    // 设置新的桌面壁纸路径
        //    string wallpaperPath = @"C:\Users\Administrator\Pictures\1209\u=572574840,3136661187&fm=253&gp=0.jpg";

        //    // 使用SystemParametersInfo函数设置桌面壁纸
        //    int result = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperPath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);

        //    if (result != 0)
        //    {
        //        Console.WriteLine("桌面壁纸设置成功！");
        //    }
        //    else
        //    {
        //        Console.WriteLine("桌面壁纸设置失败！");
        //    }
        //} 
        #endregion

        #region 桌面背景
        //[DllImport("user32.dll")]
        //public static extern bool SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);
        //private void buttonDefault_Click(object sender, EventArgs e)
        //{
        //    // 定义要修改的系统颜色元素
        //    int COLOR_DESKTOP = 1; // 桌面背景颜色
        //    int cElements = 1; // 要修改的元素数量
        //    int[] lpaElements = new int[] { COLOR_DESKTOP }; // 要修改的元素列表

        //    // 新的 RGB 值
        //    uint newColor = 0x00FF00; // 这里使用16进制表示颜色值，这里是绿色

        //    // 将新的颜色值应用到系统颜色
        //    uint[] lpaRgbValues = new uint[] { newColor };
        //    bool result = SetSysColors(cElements, lpaElements, lpaRgbValues);

        //    if (result)
        //    {
        //        Console.WriteLine("系统颜色设置成功！");
        //    }
        //    else
        //    {
        //        Console.WriteLine("系统颜色设置失败！");
        //    }
        //} 
        #endregion
    }
}
