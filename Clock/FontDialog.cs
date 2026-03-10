using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Linq.Expressions;

namespace Clock
{
    public partial class FontDialog : Form
    {
        MainForm parent;
        public FontDialog()
        {
            InitializeComponent();
            LoadFonts();
        }
        
        public FontDialog(MainForm parent):this()
        {
            this.parent = parent;
        }

        private void FontDialog_Load(object sender, EventArgs e)
        {

            this.Location = new Point(parent.Location.X - this.Width/3, parent.Location.Y+80);
            
        }
        void LoadFonts()
        {
            Console.WriteLine(Application.ExecutablePath);
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
            Console.WriteLine(Directory.GetCurrentDirectory());
            //string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
            LoadFonts(Directory.GetCurrentDirectory(), "*.otf");

        }
        void LoadFonts(string path,string format)
        {
            string[] files = Directory.GetFiles(path, format);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Split('\\').Last();
            }
            comboBoxFonts.Items.AddRange(files);
            
        }

        void ApplyFontExemple()
        {
            PrivateFontCollection ptc = new PrivateFontCollection();
            ptc.AddFontFile(comboBoxFonts.SelectedItem.ToString());
            labeExemple.Font = new Font(ptc.Families[0],(float)nudFontSize.Value);

        }
        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {

            ApplyFontExemple(); 
        }

        private void nudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ApplyFontExemple();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    } 
}
