using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms
public class load_file : Form
{
    [STAThread]
    public static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();
        Application.Run(new OpenFileDialogForm());
    }
    private Button selectButton;
    private OpenFileDialog OpenFileDialog1;
    private OpenFileDialogForm()
    { OpenFileDialog1= new OpenFileDialog
        {
        FileName = "select a text file",
        Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
        Title = "Select a text file"
        };


   
         
    }

}
