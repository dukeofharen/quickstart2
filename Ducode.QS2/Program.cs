using Ducode.QS2.Unity;
using System;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Ducode.QS2.Views;

namespace Ducode.QS2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			UnityConfig.Configure();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				var form = Container.Current.Resolve<MainForm>();
				form.RefreshItems();
				Application.Run(form);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
        }
	}
}
