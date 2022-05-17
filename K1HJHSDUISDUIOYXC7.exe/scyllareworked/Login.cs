using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using scyllareworked.Properties;

namespace scyllareworked
{
	// Token: 0x02000003 RID: 3
	public partial class Login : Form
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002248 File Offset: 0x00000448
		public Login()
		{
			Class2.Gd1ILo6zDdAXZ();
			base..ctor();
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Login.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x06000003 RID: 3
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000004 RID: 4
		[DllImport("User32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000005 RID: 5
		[DllImport("User32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000006 RID: 6 RVA: 0x000029E8 File Offset: 0x00000BE8
		private void Login_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.init();
			base.MouseDown += this.Form_MouseDown;
			try
			{
				if (Registry.CurrentUser.OpenSubKey("Unlocker by Flux") != null)
				{
					RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Unlocker by Flux");
					object value = registryKey.GetValue("Username Unlocker");
					object value2 = registryKey.GetValue("Password Unlocker");
					registryKey.Close();
					this.username.Text = value.ToString();
					this.password.Text = value2.ToString();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002284 File Offset: 0x00000484
		private void Form_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Login.ReleaseCapture();
				Login.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000022AC File Offset: 0x000004AC
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			this.panel1.Region = Region.FromHrgn(Login.CreateRoundRectRgn(0, 0, 272, 410, 10, 10));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022D3 File Offset: 0x000004D3
		private void loginbtn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022D3 File Offset: 0x000004D3
		private void label4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002A88 File Offset: 0x00000C88
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.username.Text, this.password.Text);
			if (Login.KeyAuthApp.response.success)
			{
				Login.uzivatel = this.username.Text;
				new Main().Show();
				base.Hide();
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Unlocker by Flux");
				registryKey.SetValue("Username Unlocker", this.username.Text);
				registryKey.SetValue("Password Unlocker", this.password.Text);
				registryKey.Close();
				return;
			}
			MessageBox.Show(Login.KeyAuthApp.response.message);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022D3 File Offset: 0x000004D3
		private void registerbtn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003954 File Offset: 0x00001B54
		static Login()
		{
			Class2.Gd1ILo6zDdAXZ();
			Login.name = "unlocker";
			Login.ownerid = "I3xvWRKdLi";
			Login.secret = "6900776f8787fb06d0dc79d9b48743815dffd59153954a1fa672606522e59c63";
			Login.version = "1.0";
			Login.KeyAuthApp = new api(Login.name, Login.ownerid, Login.secret, Login.version);
		}

		// Token: 0x04000001 RID: 1
		private static string name;

		// Token: 0x04000002 RID: 2
		private static string ownerid;

		// Token: 0x04000003 RID: 3
		private static string secret;

		// Token: 0x04000004 RID: 4
		private static string version;

		// Token: 0x04000005 RID: 5
		public static string uzivatel;

		// Token: 0x04000006 RID: 6
		public static api KeyAuthApp;

		// Token: 0x04000007 RID: 7
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000008 RID: 8
		public const int HTCAPTION = 2;
	}
}
