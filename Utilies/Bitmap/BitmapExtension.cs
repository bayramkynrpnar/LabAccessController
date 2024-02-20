using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Utilies.Bitmap
{
    public static class BitmapExtension
    {
     public static byte[] BitmapToByteArray(this System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms,ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
