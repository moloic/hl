using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;
using System.IO;
using System.Drawing.Imaging;
namespace Hl.dotNet.Utilities
{

    /// <summary>
    /// 生成二维码
    /// </summary>
    public class BaseQRCoder
    {

        /// <summary>
        /// 生成二维码
        /// string msg 二维码信息
        /// int pixelsPerModule:生成二维码图片的像素大小 ，我这里设置的是5 
        /// Color darkColor：暗色   一般设置为Color.Black 黑色
        /// Color lightColor:亮色   一般设置为Color.White  白色
        /// Bitmap icon :二维码 水印图标 例如：Bitmap icon = new Bitmap(context.Server.MapPath("~/images/zs.png")); 默认为NULL ，加上这个二维码中间会显示一个图标
        /// int iconSizePercent： 水印图标的大小比例 ，可根据自己的喜好设置 
        /// int iconBorderWidth： 水印图标的边框
        /// bool drawQuietZones:静止区，位于二维码某一边的空白边界,用来阻止读者获取与正在浏览的二维码无关的信息 即是否绘画二维码的空白边框区域 默认为true
        /// </summary>
        /// <returns></returns>
        public static Bitmap createQRCoder(string msg, int pixelsPerModule, Color darkColor, Color lightColor, Bitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true)
        {
            string strCode =msg;//二维码信息
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();//实例化二维码
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q, true, true);// 二维码信息属性设置
            QRCode qrcode = new QRCode(qrCodeData);//填充二维码
            Bitmap qrCodeImage = qrcode.GetGraphic(pixelsPerModule, darkColor, lightColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones);//设置二维码的呈现形式
            return qrCodeImage;

        }
    }
}
