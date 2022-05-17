using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using scyllareworked.Properties;

namespace scyllareworked
{
	// Token: 0x02000014 RID: 20
	public partial class SpoofingState : Form
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000027C8 File Offset: 0x000009C8
		public SpoofingState()
		{
			Class2.Gd1ILo6zDdAXZ();
			base..ctor();
			this.InitializeComponent();
			FiddlerCore.OnTokenReceived += this.FiddlerCoreOnOnTokenReceived;
		}

		// Token: 0x060000AC RID: 172
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000AD RID: 173 RVA: 0x000027EC File Offset: 0x000009EC
		private void SpoofingState_Load(object sender, EventArgs e)
		{
			base.Top = 20;
			base.Opacity = 0.0;
			new Form();
			base.Region = Region.FromHrgn(SpoofingState.CreateRoundRectRgn(0, 0, 569, 45, 40, 40));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002828 File Offset: 0x00000A28
		private void FiddlerCoreOnOnTokenReceived(string token)
		{
			base.Opacity -= 0.025;
			if (base.Opacity >= 1.0)
			{
				this.timer2.Stop();
				base.Hide();
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000022D3 File Offset: 0x000004D3
		private void SpoofingState_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002862 File Offset: 0x00000A62
		private void FadeIn(object sender, EventArgs e)
		{
			base.Opacity += 0.025;
			if (base.Opacity >= 1.0)
			{
				this.timer1.Stop();
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00002896 File Offset: 0x00000A96
		private void FadeOut(object sender, EventArgs e)
		{
			base.Opacity -= 0.025;
			if (base.Opacity >= 1.0)
			{
				this.timer2.Stop();
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000028CA File Offset: 0x00000ACA
		private void SpoofingState_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.timer2.Start();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000022D3 File Offset: 0x000004D3
		private void label4_Click(object sender, EventArgs e)
		{
		}
	}
}
