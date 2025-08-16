using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using MDSolutionEntities;

namespace MDSolution
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CreateVisualStyleColors();
        }
        private void AddCustomColorCommand(Color clr, string name)
        {
            Janus.Windows.Ribbon.GalleryItem item = new Janus.Windows.Ribbon.GalleryItem("COLOR" + name);
            item.Tag = clr;
            item.Image = CreateColorImage(clr, 48, 48);
            this.rgalColors.GalleryItems.Add(item);
        }
        private Image CreateColorImage(Color clr, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(clr);
            Rectangle r = new Rectangle(0, 0, width - 1, height - 1);
            g.DrawRectangle(Pens.Black, r);
            r.Inflate(-1, -1);
            g.DrawRectangle(Pens.White, r);
            g.Dispose();
            return bmp;
        }
        private void CreateBuiltInVisualStyleCommand(string key, string text, Color imageColor)
        {
            Janus.Windows.Ribbon.ButtonCommand command = new Janus.Windows.Ribbon.ButtonCommand(key);
            command.SizeStyle = Janus.Windows.Ribbon.CommandSizeStyle.Large;
            command.ActAsOptionButton = true;
            command.CheckOnClick = true;
            command.Text = text;
            command.Image = CreateColorImage(imageColor, 16, 16);
            command.LargeImage = CreateColorImage(imageColor, 32, 32);
            this.rbngOfficeColors.Commands.Add(command);
        }
        private void CreateVisualStyleColors()
        {
            this.CreateBuiltInVisualStyleCommand("rcmdBlue", "Blue", Color.FromArgb(118, 153, 199));
            this.CreateBuiltInVisualStyleCommand("rcmdSilver", "Silver", Color.Silver);
            this.CreateBuiltInVisualStyleCommand("rcmdBlack", "Black", Color.Black);
            Janus.Windows.Ribbon.ButtonCommand cmdBlue = this.rbngOfficeColors.Commands["rcmdBlue"] as Janus.Windows.Ribbon.ButtonCommand;
            cmdBlue.Checked = true;

            rgalColors.MaxGalleryColumns = 6;


            AddCustomColorCommand(Color.FromArgb(96, 128, 160), "21");
            AddCustomColorCommand(Color.FromArgb(160, 96, 96), "22");
            AddCustomColorCommand(Color.FromArgb(128, 160, 96), "23");
            AddCustomColorCommand(Color.FromArgb(96, 160, 128), "24");
            AddCustomColorCommand(Color.FromArgb(128, 128, 160), "25");
            AddCustomColorCommand(Color.FromArgb(160, 96, 128), "26");

            AddCustomColorCommand(Color.FromArgb(80, 128, 192), "21");
            AddCustomColorCommand(Color.FromArgb(192, 80, 80), "22");
            AddCustomColorCommand(Color.FromArgb(128, 192, 80), "23");
            AddCustomColorCommand(Color.FromArgb(80, 192, 128), "24");
            AddCustomColorCommand(Color.FromArgb(128, 128, 192), "25");
            AddCustomColorCommand(Color.FromArgb(192, 80, 128), "26");

            AddCustomColorCommand(Color.FromArgb(40, 80, 128), "31");
            AddCustomColorCommand(Color.FromArgb(128, 40, 40), "32");
            AddCustomColorCommand(Color.FromArgb(80, 128, 40), "33");
            AddCustomColorCommand(Color.FromArgb(40, 128, 80), "45");
            AddCustomColorCommand(Color.FromArgb(80, 80, 128), "34");
            AddCustomColorCommand(Color.FromArgb(128, 40, 80), "34");

            AddCustomColorCommand(Color.FromArgb(32, 48, 80), "21");
            AddCustomColorCommand(Color.FromArgb(80, 40, 40), "22");
            AddCustomColorCommand(Color.FromArgb(48, 80, 32), "23");
            AddCustomColorCommand(Color.FromArgb(32, 80, 48), "24");
            AddCustomColorCommand(Color.FromArgb(40, 40, 80), "25");
            AddCustomColorCommand(Color.FromArgb(80, 32, 40), "26");

            AddCustomColorCommand(Color.FromArgb(24, 40, 64), "41");
            AddCustomColorCommand(Color.FromArgb(64, 24, 24), "42");
            AddCustomColorCommand(Color.FromArgb(40, 64, 32), "43");
            AddCustomColorCommand(Color.FromArgb(24, 64, 48), "45");
            AddCustomColorCommand(Color.FromArgb(32, 32, 64), "44");
            AddCustomColorCommand(Color.FromArgb(64, 24, 48), "44");


        }
        private void UncheckCustomColors()
        {
            foreach (Janus.Windows.Ribbon.GalleryItem item in this.rgalColors.GalleryItems)
            {
                item.Checked = false;
            }
        }
        private void ribbonColorStyle_CommandClick(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (e.Command.Key.StartsWith("COLOR"))
            {
                Janus.Windows.Common.VisualStyleManager.DefaultOffice2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Custom;
                Janus.Windows.Common.VisualStyleManager.DefaultOffice2007CustomColor = (Color)e.Command.Tag;
                foreach (Janus.Windows.Ribbon.ButtonCommand btnCommand in this.rbngOfficeColors.Commands)
                {
                    btnCommand.Checked = false;
                }
            }
            else
            {
                switch (e.Command.Key)
                {
                    case "rcmdBlack":
                        Janus.Windows.Common.VisualStyleManager.DefaultOffice2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Black;
                        UncheckCustomColors();
                        break;
                    case "rcmdBlue":
                        Janus.Windows.Common.VisualStyleManager.DefaultOffice2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Blue;
                        UncheckCustomColors();
                        break;
                    case "rcmdSilver":
                        Janus.Windows.Common.VisualStyleManager.DefaultOffice2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Silver;
                        UncheckCustomColors();
                        break;
                    case "buttonCommandThemMoiHopDong":                        
                        //DACASUCO_App.HopDongMia_ThemMoi.ShowDialog();
                        break;
                    case "buttonCommand2":
                        //Form8 frm1 = new Form8();
                        //frm1.ShowDialog();

                        break;

                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.VisualStyleManager1.DefaultColorScheme = "";
            this.VisualStyleManager1.ColorSchemes.Clear();
            Janus.Windows.Common.JanusColorScheme cs = null;

            cs = new Janus.Windows.Common.JanusColorScheme("Default");
            cs.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            cs.UseThemes = true;
            cs.Office2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Default;
            Janus.Windows.Common.VisualStyleManager.DefaultOffice2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Blue;

            this.VisualStyleManager1.ColorSchemes.Add(cs);
            this.VisualStyleManager1.DefaultColorScheme = "Default";
        }

       

    }
}