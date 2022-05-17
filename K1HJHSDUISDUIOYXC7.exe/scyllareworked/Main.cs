using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using scyllareworked.Properties;

namespace scyllareworked
{
	// Token: 0x02000004 RID: 4
	public partial class Main : Form
	{
		// Token: 0x06000010 RID: 16
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000022F4 File Offset: 0x000004F4
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000022FC File Offset: 0x000004FC
		public string Token { get; private set; }

		// Token: 0x06000013 RID: 19
		[DllImport("User32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000014 RID: 20
		[DllImport("User32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000015 RID: 21 RVA: 0x000039AC File Offset: 0x00001BAC
		public Main()
		{
			Class2.Gd1ILo6zDdAXZ();
			base..ctor();
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			FiddlerCore.OnTokenReceived += this.FiddlerCoreOnOnTokenReceived;
			base.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, 704, 344, 20, 20));
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022D3 File Offset: 0x000004D3
		private void FiddlerCoreOnOnTokenReceived(string token)
		{
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002305 File Offset: 0x00000505
		private void Main_Load(object sender, EventArgs e)
		{
			base.ClientSize = new Size(704, 344);
			base.MouseDown += this.Form_MouseDown;
			this.nickname.Text = Login.uzivatel;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000233E File Offset: 0x0000053E
		private void Form_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002366 File Offset: 0x00000566
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			this.panel2.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, 167, 131, 20, 20));
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002366 File Offset: 0x00000566
		private void label4_Click(object sender, EventArgs e)
		{
			this.panel2.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, 167, 131, 20, 20));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000238D File Offset: 0x0000058D
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			this.panel3.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, 167, 68, 20, 20));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000023B1 File Offset: 0x000005B1
		private void panel4_Paint(object sender, PaintEventArgs e)
		{
			this.panel4.Region = Region.FromHrgn(Main.CreateRoundRectRgn(0, 0, 167, 68, 20, 20));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023D5 File Offset: 0x000005D5
		private void anticrack()
		{
			new Thread(delegate(object t)
			{
				for (;;)
				{
					foreach (Process process in Process.GetProcesses())
					{
						if (process.ProcessName.ToUpper().Contains("de4dot"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("Fiddler"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("de4dot"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("x64dbg"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("x96dbg"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("x32dbg"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("debugger"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("x32dbg"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("unpack"))
						{
							process.Kill();
						}
						if (process.ProcessName.ToUpper().Contains("UNPACK"))
						{
							process.Kill();
						}
					}
				}
			})
			{
				IsBackground = true
			}.Start();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003A04 File Offset: 0x00001C04
		private void panel5_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022D3 File Offset: 0x000004D3
		private void guna2Button9_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003A54 File Offset: 0x00001C54
		private void guna2Button8_Click_2(object sender, EventArgs e)
		{
			new WebClient().DownloadFile("https://raw.githubusercontent.com/Hrnda2/Newbie/main/cusbus", Path.GetTempPath() + "google.txt");
			string text = File.ReadAllText(Path.GetTempPath() + "google.txt");
			text = text.Replace(": \"xxx\",", ": \"" + new Random().Next(1000, 9999).ToString() + "\",");
			File.WriteAllText(Path.GetTempPath() + "google.txt", text);
			FiddlerCore.Start();
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DeadByDaylight\\Saved\\Config\\WindowsNoEditor\\Engine.ini";
			if (!File.ReadAllText(path).Contains("n.VerifyPeer=False"))
			{
				try
				{
					using (StreamWriter streamWriter = File.AppendText(path))
					{
						streamWriter.WriteLine("\n\n[/Script/Engine.NetworkSettings]");
						streamWriter.WriteLine("n.VerifyPeer=False");
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x04000016 RID: 22
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000017 RID: 23
		public const int HTCAPTION = 2;
	}
}
