using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;
using System.DrawingCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        private void GenerateImage(string path)
        {

            int tWidth = 1240;
            int tHeigh = 10;
            int rHeigh = 33;
            Font fTitle = new Font("宋体", 16);
            int titleHeight = 20;
            Font fText = new Font("宋体", 9);
            int x = 0;
            int y = 0;
            int top = 30;
            int left = 10;
            int cellText = 5;
            int cellTextTop = 10;
            int fcelltextleft = 15;

            Bitmap bm = new Bitmap(tWidth, tHeigh * rHeigh + top + cellText + titleHeight + 100);
            Graphics gh = Graphics.FromImage(bm);
            gh.Clear(Color.White);

            #region MyRegion

            SizeF sTitle = gh.MeasureString("工资表", fTitle);
            Point pTitle = new Point((tWidth - (int)sTitle.Width) / 2, y + top);
            y += top; // 1
            gh.DrawString("工资表", fTitle, Brushes.Black, pTitle.X, y);

            y += cellText + titleHeight;
            gh.DrawLine(Pens.Black, new Point(left, y), new Point(tWidth - left, y));

            y += top;
            x = left;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 45, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("序号", fText, Brushes.Black, fcelltextleft, y + cellTextTop);
            x += 45;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 120, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("姓名", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 120;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 130, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("身份证号", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 130;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("基本工资", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("奖金", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("罚款", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("应付工资", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("扣缴社保", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("扣缴公积金", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("应纳税额", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("个税", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 95, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("实发工资", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 95;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x + 70, y));
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));
            gh.DrawString("签字", fText, Brushes.Black, x + cellText, y + cellTextTop);
            x += 70;
            gh.DrawLine(Pens.Black, new Point(x, y), new Point(x, y + rHeigh));

            y += rHeigh;
            gh.DrawLine(Pens.Black, new Point(left, y), new Point(x, y));

            #endregion MyRegion

            Stream ms = new MemoryStream();
            try
            {
                bm.Save(path, System.DrawingCore.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ms.Dispose();
                gh.Dispose();
                bm.Dispose();
            }

        }

        public IActionResult About()
        {
            GenerateImage(Path.Combine(_hostingEnvironment.WebRootPath, "images", "1.jpg"));
            ViewBag.Img = "/images/1.jpg";
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
