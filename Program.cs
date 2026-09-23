using System;
using System.Windows.Forms;

namespace StudentInformation_CSharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StudentInformationForm());
        }
    }
}
