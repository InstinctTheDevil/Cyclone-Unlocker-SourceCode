namespace scyllareworked
{
	// Token: 0x02000004 RID: 4
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002407 File Offset: 0x00000607
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003B54 File Offset: 0x00001D54
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::scyllareworked.Main));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.nickname = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.guna2Panel_0 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.label23 = new global::System.Windows.Forms.Label();
			this.cookiepanel = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label22 = new global::System.Windows.Forms.Label();
			this.guna2CustomCheckBox8 = new global::Guna.UI2.WinForms.Guna2CustomCheckBox();
			this.guna2Button8 = new global::Guna.UI2.WinForms.Guna2Button();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.guna2Panel_0.SuspendLayout();
			this.cookiepanel.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(40, 52, 120);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new global::System.Drawing.Point(1, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(189, 445);
			this.panel1.TabIndex = 0;
			this.pictureBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox1.BackgroundImage = global::scyllareworked.Properties.Resources.unlock;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new global::System.Drawing.Point(11, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(50, 50);
			this.pictureBox1.TabIndex = 34;
			this.pictureBox1.TabStop = false;
			this.label4.Anchor = global::System.Windows.Forms.AnchorStyles.Left;
			this.label4.BackColor = global::System.Drawing.Color.Transparent;
			this.label4.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.label4.Font = new global::System.Drawing.Font("Comfortaa", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.label4.Location = new global::System.Drawing.Point(47, 4);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(142, 47);
			this.label4.TabIndex = 2;
			this.label4.Text = "Unlocker";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.Click += new global::System.EventHandler(this.label4_Click);
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Location = new global::System.Drawing.Point(11, 268);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(167, 68);
			this.panel4.TabIndex = 2;
			this.panel4.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label2.Font = new global::System.Drawing.Font("Comfortaa", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(49, 61, 129);
			this.label2.Location = new global::System.Drawing.Point(0, 34);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(167, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "powered by fluxauth";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label3.Font = new global::System.Drawing.Font("Comfortaa", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(67, 83, 176);
			this.label3.Location = new global::System.Drawing.Point(0, 8);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(167, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "unlocker for dead by daylight";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			this.panel3.Controls.Add(this.nickname);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new global::System.Drawing.Point(11, 57);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(167, 68);
			this.panel3.TabIndex = 1;
			this.panel3.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			this.nickname.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.nickname.Font = new global::System.Drawing.Font("Comfortaa", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nickname.ForeColor = global::System.Drawing.Color.FromArgb(57, 72, 158);
			this.nickname.Location = new global::System.Drawing.Point(0, 29);
			this.nickname.Name = "nickname";
			this.nickname.Size = new global::System.Drawing.Size(167, 26);
			this.nickname.TabIndex = 1;
			this.nickname.Text = "user";
			this.nickname.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label1.Font = new global::System.Drawing.Font("Comfortaa", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(102, 110, 159);
			this.label1.Location = new global::System.Drawing.Point(0, 3);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(167, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "welcome";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new global::System.Drawing.Point(11, 131);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(167, 131);
			this.panel2.TabIndex = 1;
			this.panel2.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			this.label5.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label5.Font = new global::System.Drawing.Font("Comfortaa", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.DarkOliveGreen;
			this.label5.Location = new global::System.Drawing.Point(3, 26);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(164, 26);
			this.label5.TabIndex = 3;
			this.label5.Text = "Up to date";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label6.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label6.Font = new global::System.Drawing.Font("Comfortaa", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.FromArgb(102, 110, 159);
			this.label6.Location = new global::System.Drawing.Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(167, 26);
			this.label6.TabIndex = 1;
			this.label6.Text = "Status";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.guna2Panel_0.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.guna2Panel_0.AutoRoundedCorners = true;
			this.guna2Panel_0.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Panel_0.BorderColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			this.guna2Panel_0.BorderRadius = 14;
			this.guna2Panel_0.BorderThickness = 2;
			this.guna2Panel_0.Controls.Add(this.label23);
			this.guna2Panel_0.CustomBorderColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			this.guna2Panel_0.FillColor = global::System.Drawing.Color.FromArgb(28, 40, 108);
			this.guna2Panel_0.Location = new global::System.Drawing.Point(203, 38);
			this.guna2Panel_0.Name = "guna2Panel2";
			this.guna2Panel_0.ShadowDecoration.Parent = this.guna2Panel_0;
			this.guna2Panel_0.ShadowDecoration.Shadow = new global::System.Windows.Forms.Padding(50);
			this.guna2Panel_0.Size = new global::System.Drawing.Size(487, 30);
			this.guna2Panel_0.TabIndex = 23;
			this.label23.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label23.Font = new global::System.Drawing.Font("Comfortaa", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label23.ForeColor = global::System.Drawing.Color.FromArgb(57, 72, 158);
			this.label23.Location = new global::System.Drawing.Point(0, -6);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(485, 26);
			this.label23.TabIndex = 35;
			this.label23.Text = "Store Unlocker";
			this.label23.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cookiepanel.BackColor = global::System.Drawing.Color.FromArgb(40, 52, 120);
			this.cookiepanel.Controls.Add(this.label7);
			this.cookiepanel.Controls.Add(this.label22);
			this.cookiepanel.Controls.Add(this.guna2CustomCheckBox8);
			this.cookiepanel.Controls.Add(this.guna2Button8);
			this.cookiepanel.Location = new global::System.Drawing.Point(203, 56);
			this.cookiepanel.Name = "cookiepanel";
			this.cookiepanel.Size = new global::System.Drawing.Size(487, 279);
			this.cookiepanel.TabIndex = 33;
			this.label7.Anchor = (global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label7.Font = new global::System.Drawing.Font("Comfortaa", 8.999999f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.FromArgb(67, 83, 176);
			this.label7.Location = new global::System.Drawing.Point(2, 235);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(485, 41);
			this.label7.TabIndex = 2;
			this.label7.Text = "dont close after spoofing. leave the software open. if your internet is not working after spoofing, disable proxy in windows settings.";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label22.AutoSize = true;
			this.label22.ForeColor = global::System.Drawing.Color.FromArgb(102, 110, 159);
			this.label22.Location = new global::System.Drawing.Point(29, 61);
			this.label22.Margin = new global::System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(146, 21);
			this.label22.TabIndex = 31;
			this.label22.Text = "Encrypt Connection";
			this.guna2CustomCheckBox8.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.guna2CustomCheckBox8.Animated = true;
			this.guna2CustomCheckBox8.BackColor = global::System.Drawing.Color.FromArgb(53, 65, 133);
			this.guna2CustomCheckBox8.Checked = true;
			this.guna2CustomCheckBox8.CheckedState.BorderColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.guna2CustomCheckBox8.CheckedState.BorderRadius = 2;
			this.guna2CustomCheckBox8.CheckedState.BorderThickness = 0;
			this.guna2CustomCheckBox8.CheckedState.FillColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.guna2CustomCheckBox8.CheckedState.Parent = this.guna2CustomCheckBox8;
			this.guna2CustomCheckBox8.CheckMarkColor = global::System.Drawing.Color.FromArgb(57, 29, 158);
			this.guna2CustomCheckBox8.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.guna2CustomCheckBox8.Location = new global::System.Drawing.Point(6, 63);
			this.guna2CustomCheckBox8.Name = "guna2CustomCheckBox8";
			this.guna2CustomCheckBox8.ShadowDecoration.Mode = 1;
			this.guna2CustomCheckBox8.ShadowDecoration.Parent = this.guna2CustomCheckBox8;
			this.guna2CustomCheckBox8.Size = new global::System.Drawing.Size(20, 21);
			this.guna2CustomCheckBox8.TabIndex = 32;
			this.guna2CustomCheckBox8.UncheckedState.BorderColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.guna2CustomCheckBox8.UncheckedState.BorderRadius = 2;
			this.guna2CustomCheckBox8.UncheckedState.BorderThickness = 0;
			this.guna2CustomCheckBox8.UncheckedState.FillColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.guna2CustomCheckBox8.UncheckedState.Parent = this.guna2CustomCheckBox8;
			this.guna2Button8.Animated = true;
			this.guna2Button8.AutoRoundedCorners = true;
			this.guna2Button8.BackColor = global::System.Drawing.Color.FromArgb(40, 52, 120);
			this.guna2Button8.BorderColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.guna2Button8.BorderRadius = 15;
			this.guna2Button8.BorderThickness = 1;
			this.guna2Button8.CheckedState.Parent = this.guna2Button8;
			this.guna2Button8.CustomImages.Parent = this.guna2Button8;
			this.guna2Button8.FillColor = global::System.Drawing.Color.FromArgb(68, 84, 175);
			this.guna2Button8.Font = new global::System.Drawing.Font("Comfortaa", 8.999999f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.guna2Button8.ForeColor = global::System.Drawing.Color.FromArgb(102, 110, 159);
			this.guna2Button8.HoverState.Parent = this.guna2Button8;
			this.guna2Button8.Location = new global::System.Drawing.Point(5, 22);
			this.guna2Button8.Name = "guna2Button8";
			this.guna2Button8.ShadowDecoration.Parent = this.guna2Button8;
			this.guna2Button8.Size = new global::System.Drawing.Size(479, 33);
			this.guna2Button8.TabIndex = 31;
			this.guna2Button8.Text = "Initialize";
			this.guna2Button8.Click += new global::System.EventHandler(this.guna2Button8_Click_2);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 21f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(53, 65, 133);
			base.ClientSize = new global::System.Drawing.Size(704, 344);
			base.ControlBox = false;
			base.Controls.Add(this.cookiepanel);
			base.Controls.Add(this.guna2Panel_0);
			base.Controls.Add(this.panel1);
			this.Font = new global::System.Drawing.Font("Comfortaa", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Utilities";
			base.Load += new global::System.EventHandler(this.Main_Load);
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.guna2Panel_0.ResumeLayout(false);
			this.cookiepanel.ResumeLayout(false);
			this.cookiepanel.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000018 RID: 24
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label nickname;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000023 RID: 35
		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel_0;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Panel cookiepanel;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000026 RID: 38
		private global::Guna.UI2.WinForms.Guna2CustomCheckBox guna2CustomCheckBox8;

		// Token: 0x04000027 RID: 39
		private global::Guna.UI2.WinForms.Guna2Button guna2Button8;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Label label23;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
