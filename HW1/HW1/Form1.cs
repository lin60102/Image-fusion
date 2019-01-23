using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HW1
{
    public partial class Form1 : Form
    {
        Image left,right;
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          left=Image.FromFile(".../image/left.png");
          right=Image.FromFile(".../image/right.png");
          pictureBox2.Image=left;
          pictureBox3.Image=right;
          int[, ,] rgbDataleft = getRGBData(left);
          int[, ,] rgbDataright = getRGBData(right);
          int[, ,] rgbData = new int[889, 256, 3]; ;
          image = new Bitmap(889, 256);
          int Width = image.Width;
          int Height = image.Height;
         
          for (int y = 0; y < Height; y++)
          {
              for (int x = 0; x < Width; x++)
              {
                 if(x<423){
                     rgbData[x, y, 0] = rgbDataleft[x, y, 0];
                     rgbData[x, y, 1] = rgbDataleft[x, y, 1];
                     rgbData[x, y, 2] = rgbDataleft[x, y, 2];
                     image.SetPixel(x, y, Color.FromArgb( rgbData[x, y, 0] , rgbData[x, y, 1] ,  rgbData[x, y, 2] ));
                 }
                 else if (x >= 423)
                 {
                     rgbData[x, y, 0]=rgbDataright[(x-423),y,0];
                     rgbData[x, y, 1] = rgbDataright[(x - 423), y,1];
                     rgbData[x, y, 2] = rgbDataright[(x - 423), y, 2];
                     image.SetPixel(x, y, Color.FromArgb( rgbData[x, y, 0] , rgbData[x, y, 1] ,  rgbData[x, y, 2] ));
                 }
              }
          } 
            pictureBox1.Image=image;
        }
        public int[, ,] getRGBData(Image image)
        {
            // Step 1: 利用 Bitmap 將 image 包起來 
            Bitmap bimage = new Bitmap(image);
            int Height = bimage.Height;
            int Width = bimage.Width;
            int[, ,] rgbData = new int[Width, Height, 3];

            // Step 2: 取得像點顏色資訊 
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color color = bimage.GetPixel(x, y);
                    rgbData[x, y, 0] = color.R;
                    rgbData[x, y, 1] = color.G;
                    rgbData[x, y, 2] = color.B;
                }
            }
            return rgbData;
        } 
    }
}
