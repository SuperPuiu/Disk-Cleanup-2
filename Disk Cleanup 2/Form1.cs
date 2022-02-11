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
using System.Runtime.InteropServices;

namespace Disk_Cleanup_2
{
    public partial class Form1 : Form
    {
        bool ClearDump = false;
        bool SoftwareDistribution = false;
        bool TempFol = false;
        bool ClearCache = false;
        bool ClearDownloads = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TempFol)
            {
                if (Directory.Exists(Path.GetTempPath())) // Get temp folder path
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
                if (Directory.Exists("C:\\Windows\\SoftwareDistribution")) // If SoftwareDistribution exists, continue.
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
       if(ClearDownloads)
            {
                DirectoryInfo drr2 = new DirectoryInfo(KnownFolders.GetPath(KnownFolder.Downloads));
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
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ClearDownloads = checkBox5.Checked;
        }
    }
}


/// <summary>
/// Class containing methods to retrieve specific file system paths.
/// </summary>
public static class KnownFolders
{
    private static string[] _knownFolderGuids = new string[]
    {
        "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
        "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
        "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
        "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
        "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
        "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
        "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
        "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
        "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
        "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
        "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
    };

    /// <summary>
    /// Gets the current path to the specified known folder as currently configured. This does
    /// not require the folder to be existent.
    /// </summary>
    /// <param name="knownFolder">The known folder which current path will be returned.</param>
    /// <returns>The default path of the known folder.</returns>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
    ///     could not be retrieved.</exception>
    public static string GetPath(KnownFolder knownFolder)
    {
        return GetPath(knownFolder, false);
    }

    /// <summary>
    /// Gets the current path to the specified known folder as currently configured. This does
    /// not require the folder to be existent.
    /// </summary>
    /// <param name="knownFolder">The known folder which current path will be returned.</param>
    /// <param name="defaultUser">Specifies if the paths of the default user (user profile
    ///     template) will be used. This requires administrative rights.</param>
    /// <returns>The default path of the known folder.</returns>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
    ///     could not be retrieved.</exception>
    public static string GetPath(KnownFolder knownFolder, bool defaultUser)
    {
        return GetPath(knownFolder, KnownFolderFlags.DontVerify, defaultUser);
    }

    private static string GetPath(KnownFolder knownFolder, KnownFolderFlags flags,
        bool defaultUser)
    {
        int result = SHGetKnownFolderPath(new Guid(_knownFolderGuids[(int)knownFolder]),
            (uint)flags, new IntPtr(defaultUser ? -1 : 0), out IntPtr outPath);
        if (result >= 0)
        {
            string path = Marshal.PtrToStringUni(outPath);
            Marshal.FreeCoTaskMem(outPath);
            return path;
        }
        else
        {
            throw new ExternalException("Unable to retrieve the known folder path. It may not "
                + "be available on this system.", result);
        }
    }

    [DllImport("Shell32.dll")]
    private static extern int SHGetKnownFolderPath(
        [MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken,
        out IntPtr ppszPath);

    [Flags]
    private enum KnownFolderFlags : uint
    {
        SimpleIDList = 0x00000100,
        NotParentRelative = 0x00000200,
        DefaultPath = 0x00000400,
        Init = 0x00000800,
        NoAlias = 0x00001000,
        DontUnexpand = 0x00002000,
        DontVerify = 0x00004000,
        Create = 0x00008000,
        NoAppcontainerRedirection = 0x00010000,
        AliasOnly = 0x80000000
    }
}

/// <summary>
/// Standard folders registered with the system. These folders are installed with Windows Vista
/// and later operating systems, and a computer will have only folders appropriate to it
/// installed.
/// </summary>
public enum KnownFolder
{
    Contacts,
    Desktop,
    Documents,
    Downloads,
    Favorites,
    Links,
    Music,
    Pictures,
    SavedGames,
    SavedSearches,
    Videos
}
