using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Clock
{
    public partial class FontDialog : Form
    {
        MainForm parent;
        Dictionary<string, string> d_fonts; // словаь(дерево) структура данный которая хранит множество пар <Ключ -- значения> <Key -- Value>
        public FontDialog()
        {
            InitializeComponent();
            //LoadFonts();
            d_fonts = new Dictionary<string, string>();
            Travers($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
            comboBoxFonts.Items.AddRange(d_fonts.Keys.ToArray());

        }

        public FontDialog(MainForm parent):this()
        {
            this.parent = parent;
        }

        private void FontDialog_Load(object sender, EventArgs e)
        {

            this.Location = new Point(parent.Location.X - this.Width/3, parent.Location.Y+80);
            
        }
        void Travers(string path)
        {
            Console.WriteLine(path);
            LoadFonts(path, "*.ttf");
            LoadFonts(path, "*.otf");
            string[] directories = Directory.GetDirectories(path);
            for (int i = 0; i < directories.Length; i++)
                Travers(directories[i]);
            
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
                d_fonts.Add(files[i].Split('\\').Last(), files[i]);
                //files[i] = files[i].Split('\\').Last();
            }
            //comboBoxFonts.Items.AddRange(files);
            
        }

        void ApplyFontExemple()
        {
            PrivateFontCollection ptc = new PrivateFontCollection();
            ptc.AddFontFile(d_fonts[comboBoxFonts.SelectedItem.ToString()]);
            //ptc.AddFontFile(comboBoxFonts.SelectedItem.ToString());
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
