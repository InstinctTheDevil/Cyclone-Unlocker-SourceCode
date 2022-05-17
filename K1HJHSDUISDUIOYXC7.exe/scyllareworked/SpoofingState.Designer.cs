namespace scyllareworked
{
	// Token: 0x02000014 RID: 20
	public partial class SpoofingState : global::System.Windows.Forms.Form
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000028D7 File Offset: 0x00000AD7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006730 File Offset: 0x00004930
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::scyllareworked.SpoofingState));
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.label4 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.timer2 = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.timer1.Enabled = true;
			this.timer1.Interval = 10;
			this.timer1.Tick += new global::System.EventHandler(this.FadeIn);
			this.label4.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label4.Font = new global::System.Drawing.Font("Comfortaa", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.label4.Location = new global::System.Drawing.Point(0, 0);
			this.label4.Margin = new global::System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(569, 45);
			this.label4.TabIndex = 3;
			this.label4.Text = "Spoofing Market Information";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.Click += new global::System.EventHandler(this.label4_Click);
			this.pictureBox1.BackgroundImage = global::scyllareworked.Properties.Resources.unlock;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Image = global::scyllareworked.Properties.Resources.unlock;
			this.pictureBox1.Location = new global::System.Drawing.Point(9, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(45, 45);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			this.timer2.Interval = 10;
			this.timer2.Tick += new global::System.EventHandler(this.FadeOut);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			base.ClientSize = new global::System.Drawing.Size(569, 45);
			base.ControlBox = false;
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SpoofingState";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SpoofingState";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.SpoofingState_FormClosing);
			base.Load += new global::System.EventHandler(this.SpoofingState_Load);
			base.Click += new global::System.EventHandler(this.SpoofingState_Click);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000065 RID: 101
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Timer timer2;
	}
}
