using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Введение_в_кг
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        public Bitmap Draw_pic()
        {
            Bitmap bitmap = new Bitmap(MainPanel.Width, MainPanel.Height);
            Graphics gGraphics = Graphics.FromImage(bitmap);
            gGraphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 2);
            PointF[] points = { new PointF(600, 100),
            new PointF(530, 210),
            new PointF(350, 256),
            new PointF(342, 320),
            new PointF(347,320),
            new PointF(344,350),
            new PointF(345, 365),
            new PointF(356, 395),
            new PointF(470, 395),
            new PointF(520,345),
            new PointF(570,345),
            new PointF(610, 395),
            new PointF(850,395),
            new PointF(900, 345),
            new PointF(950,345),
            new PointF(990, 395),
            new PointF(1060, 395),
            new PointF(1060, 220),
             new PointF(1020, 100)
            };
            gGraphics.FillEllipse(new SolidBrush(Color.Yellow), 332, 350, 25, 30);
            gGraphics.FillPolygon(new SolidBrush(Color.Red), points);
            gGraphics.FillEllipse(new SolidBrush(Color.Red), 342, 350, 30, 45);
            gGraphics.DrawLine(pen, 600, 100, 1020, 100);   //крыша
            gGraphics.DrawLine(pen, 600, 100, 530, 210); //стекло 
            gGraphics.DrawLine(pen, 530, 210, 350, 256);// капот 
            gGraphics.DrawLine(pen, 350, 256, 342, 320); // передняя часть
            Rectangle fara = new Rectangle(337, 320, 10, 30);
            gGraphics.DrawRectangle(pen, fara);
            gGraphics.FillRectangle(new SolidBrush(Color.Yellow), fara);
            gGraphics.DrawArc(pen, 332, 350, 25, 30, 90.0F, 180.0F);
            gGraphics.DrawLine(pen, 345, 350, 345, 380);
            gGraphics.DrawArc(pen, 345, 365, 30, 30, 90.0F, 90.0F);
            gGraphics.DrawLine(pen, 356, 395, 470, 395);
            gGraphics.DrawLine(pen, 470, 395, 520, 345);//выемка под левое колесо
            gGraphics.DrawLine(pen, 520, 345, 570, 345);
            gGraphics.DrawLine(pen, 570, 345, 610, 395);
            gGraphics.DrawLine(pen, 610, 395, 850, 395);//днище
            gGraphics.DrawLine(pen, 850, 395, 900, 345);//выемка под правое колесо
            gGraphics.DrawLine(pen, 900, 345, 950, 345);
            gGraphics.DrawLine(pen, 950, 345, 990, 395);
            gGraphics.DrawLine(pen, 990, 395, 1060, 395);
            gGraphics.DrawLine(pen, 1060, 395, 1060, 220);// задняя стенка
            gGraphics.DrawLine(pen, 1060, 220, 1020, 100);//заднее стекло

            //окно водителя 
            float radius = 10.0F;
            float x = 610;
            float y = 110;
            float width = 100;
            float height = 100;

            gGraphics.DrawArc(pen, x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner верхнее
            gGraphics.DrawArc(pen, x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner нижнее
            gGraphics.DrawLine(pen, 710, 115, 710, 205);///правое
            gGraphics.DrawLine(pen, 705, 210, 545, 210);//нижнее
            gGraphics.DrawLine(pen, 703, 110, 605, 110);//верхнее
            gGraphics.DrawLine(pen, 605, 110, 545, 210);//левое


            PointF[] points2 = { new PointF(605,110),
            new PointF(545, 210),
            new PointF(710, 210),
            new PointF(710,110),
            new PointF(605,110)};
            gGraphics.FillPolygon(new SolidBrush(Color.Blue), points2);

            //второе окно
            float x2 = 740;
            float y2 = 110;
            float width2 = 280;
            float height2 = 100;

            gGraphics.DrawArc(pen, x2 + width2 - (radius * 2), y2, radius * 2, radius * 2, 270, 90); // Corner
            gGraphics.DrawArc(pen, x2 + width2 - (radius * 2), y2 + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gGraphics.DrawArc(pen, x2, y2 + height2 - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gGraphics.DrawArc(pen, x2, y2, radius * 2, radius * 2, 180, 90); // Corner

            gGraphics.DrawLine(pen, 1020, 115, 1020, 205);//правое
            gGraphics.DrawLine(pen, 1013, 210, 750, 210);//нижнее
            gGraphics.DrawLine(pen, 1013, 110, 750, 110);//верхнее
            gGraphics.DrawLine(pen, 741, 115, 741, 205);//левое

            PointF[] points3 = { new PointF(1020, 100),
            new PointF(1020, 210),
            new PointF( 742, 210),
            new PointF(742, 110),
            new PointF(1020, 110)};
            gGraphics.FillPolygon(new SolidBrush(Color.Blue), points3);
            gGraphics.DrawLine(pen, 900, 110, 900, 210);//среднее
            //ручки дверей
            gGraphics.DrawRectangle(pen, 670, 230, 30, 10);
            gGraphics.FillRectangle(new SolidBrush(Color.Gray), 670, 230, 30, 10);

            gGraphics.DrawString("Проект выполнил Маликов Стас. 2 курс группа 1.1 ", SystemFonts.MenuFont, Brushes.Black, 100, 50);

            //раскрашивание 
            gGraphics.DrawLine(pen, 0, 460, 3000, 460);
            gGraphics.FillRectangle(new SolidBrush(Color.DarkGreen), 0, 461, 3000, 3000);

            gGraphics.DrawEllipse(new Pen(Color.Black, 4), 482, 354, 120, 120);//левое колесо
            gGraphics.FillEllipse(new SolidBrush(Color.Black), 482, 354, 120, 120);
            gGraphics.FillEllipse(new SolidBrush(Color.Gray), 492, 365, 100, 100);

            gGraphics.DrawEllipse(new Pen(Color.Black, 4), 862, 354, 120, 120);// правое колесо
            gGraphics.FillEllipse(new SolidBrush(Color.Black), 862, 354, 120, 120);
            gGraphics.FillEllipse(new SolidBrush(Color.Gray), 872, 365, 100, 100);
            return bitmap;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            MainPanel.CreateGraphics().DrawImage(Draw_pic(), 0, 0);
        }
    }
}
