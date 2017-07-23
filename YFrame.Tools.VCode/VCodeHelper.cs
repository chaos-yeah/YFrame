using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.VCode
{
    /// <summary>
    /// 验证码助手
    /// </summary>
    public class VCodeHelper
    {
        //定义颜色
        public readonly static Color[] Colors =
        {
            Color.Black,
            Color.Red,
            Color.Blue,
            Color.Green,
            //Color.Orange,
            Color.Brown,
            Color.DarkBlue,
            Color.Purple
        };

        //字体样式
        public readonly static FontStyle[] FontStyles =
        {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline
        };

        //字体列表
        public readonly static string[] Prototypes =
        {
            "Arial",
            "Times New Roman",
            "MS Mincho",
            "Book Antiqua",
            "Gungsuh",
            "PMingLiU",
            "Impact"
        };

        /// <summary>
        /// 随机字符串包含的字符
        /// </summary>
        public static readonly char[] Chars = new char[]
        {
            '0', '1','2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
            'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
            'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
            'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
            's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        };

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="verifycode"></param>
        /// <returns></returns>
        public static byte[] CreateVerifyCodeImage(string verifycode)
        {
            int randAngle = 40; //随机转动角度
            int mapwidth = (int)(verifycode.Length * 18);
            Bitmap map = new Bitmap(mapwidth, 42);//创建图片背景
            Graphics graph = Graphics.FromImage(map);
            graph.Clear(Color.White);//清除画面，填充背景

            Random rand = new Random();

            //验证码旋转，防止机器识别
            char[] chars = verifycode.ToCharArray();//拆散字符串成单字符数组
            //文字距中
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            //画图片的背景噪音线
            for (int i = 0; i < 3; i++)
            {
                int x1 = rand.Next(10);
                int x2 = rand.Next(map.Width - 10, map.Width);
                int y1 = rand.Next(map.Height);
                int y2 = rand.Next(map.Height);

                graph.DrawLine(new Pen(Colors[rand.Next(Colors.Length)]), x1, y1, x2, y2);
            }

            for (int i = 0; i < chars.Length; i++)
            {
                Font f = new Font(Prototypes[rand.Next(Prototypes.Length)], rand.Next(20, 25), FontStyles[rand.Next(FontStyles.Length)]);//字体样式(参数2为字体大小)
                Brush b = new SolidBrush(Colors[rand.Next(Colors.Length)]);
                Point dot = new Point(12, 20);
                float angle = rand.Next(-randAngle, randAngle);//转动的度数
                graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                graph.RotateTransform(angle);
                graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                graph.RotateTransform(-angle);//转回去
                graph.TranslateTransform(2, -dot.Y);//移动光标到指定位置
            }
            //生成图片
            MemoryStream stream = new MemoryStream();
            map.Save(stream, ImageFormat.Jpeg);
            graph.Dispose();
            map.Dispose();
            return stream.ToArray();
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length = 5)
        {
            if (length < 0)
            {
                throw new ArgumentException("parameter length must greater than 0 !");
            }

            StringBuilder randomString = new StringBuilder();
            int n = Chars.Length;
            Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < length; i++)
            {
                int rnd = random.Next(0, n);
                randomString.Append(Chars[rnd]);
            }
            return randomString.ToString();
        }
    }

}
