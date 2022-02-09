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

namespace Disk_Cleanup_2
{
    public partial class Form1 : Form
    {
        bool ClearDump = false;
        bool SoftwareDistribution = false;
        bool TempFol = false;
        bool ClearCache = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TempFol)
            {
                if (Directory.Exists(Path.GetTempPath()))
                {
                    DirectoryInfo dir = new DirectoryInfo(Path.GetTempPath());
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch { }
                    }
                    foreach (DirectoryInfo dire in dir.GetDirectories())
                    {
                        try
                        {
                            dire.Delete(true);
                        }
                        catch { }
                    }
                }
            }

            if (SoftwareDistribution)
            {
                if (Directory.Exists("C:\\Windows\\SoftwareDistribution"))
                {
                    DirectoryInfo drr2 = new DirectoryInfo("C:\\Windows\\SoftwareDistribution");
                    foreach (FileInfo file in drr2.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch { }

                        foreach (DirectoryInfo drr in drr2.GetDirectories())
                        {
                            try
                            {
                                drr.Delete(true);
                            }
                            catch { }
                        }
                    }
                }
            }
            if (ClearDump)
            {
                if (Directory.Exists("C:\\Windows\\minidump"))
                {
                    DirectoryInfo drr2 = new DirectoryInfo("C:\\Windows\\minidump");
                foreach (FileInfo file in drr2.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch { }

                    foreach (DirectoryInfo drr in drr2.GetDirectories())
                    {
                        try
                        {
                            drr.Delete(true);
                        }
                        catch { }
                    }
                }
            }
        }
       if(ClearCache)
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)))
                {
                    DirectoryInfo drr2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache));
                    foreach (FileInfo file in drr2.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch { }

                        foreach (DirectoryInfo drr in drr2.GetDirectories())
                        {
                            try
                            {
                                drr.Delete(true);
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TempFol = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SoftwareDistribution = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ClearDump = checkBox3.Checked;  
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ClearCache = checkBox4.Checked;
        }
    }
}
