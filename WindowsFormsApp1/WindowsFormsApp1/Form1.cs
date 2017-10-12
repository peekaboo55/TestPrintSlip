using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ThaiBath b = new ThaiBath();
        DateTime dt = new DateTime();

        Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;

        private void button1_Click(object sender, EventArgs e)
        {
            //if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            //    printDocument1.Print();
            //}
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = "Test Document";
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            
            pd.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x, y, lineOffset , center;

            // Set Font
            Font printFont = new Font("Superspace Bold", (float)10, FontStyle.Regular, GraphicsUnit.Point); // Substituted to FontA Font

            e.Graphics.PageUnit = GraphicsUnit.Point;

            // Draw the bitmap            
            center = 50;
            e.Graphics.DrawImage(WindowsFormsApp1.Properties.Resources.cu2, 70, -8, 80, 95);

            // Print the receipt text
            lineOffset = printFont.GetHeight(e.Graphics) - (float)0.5;
            x = 10;
            y = 75 + lineOffset;
            e.Graphics.DrawString("   Smart Queue System", printFont, Brushes.Black, center, y);
            y += lineOffset;
            e.Graphics.DrawString("    TEL : 02-311-6881", printFont, Brushes.Black, center, y);
            y += lineOffset;
            e.Graphics.DrawString("  " + DateTime.Now.ToString(), printFont, Brushes.Black, center, y);
            y += lineOffset;
            e.Graphics.DrawString("     จำนวนคิวที่รอ 5 คิว", printFont, Brushes.Black, center, y);
            y += lineOffset;

            e.Graphics.DrawString("___________________________________", printFont, Brushes.Black, x, y);
            y += 120;
            //e.Graphics.DrawImage(WindowsFormsApp1.Properties.Resources._1, 60, 150, 100, 100);
            e.Graphics.DrawImage(qrcode.Draw("001",100), 60, 150, 100, 100);
            y += lineOffset;
            e.Graphics.DrawString("___________________________________", printFont, Brushes.Black, x, y);

            printFont = new Font("Superspace Bold", 14, FontStyle.Regular, GraphicsUnit.Point);
            lineOffset = printFont.GetHeight(e.Graphics) - 3;
            y += lineOffset;
            e.Graphics.DrawString("Computer Union CO.,Ltd", printFont, Brushes.Black, 35, y);
        }
    }
}
