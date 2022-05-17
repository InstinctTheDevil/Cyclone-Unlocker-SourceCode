using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace scyllareworked.Properties
{
	// Token: 0x02000015 RID: 21
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00002437 File Offset: 0x00000637
		internal Resources()
		{
			Class2.Gd1ILo6zDdAXZ();
			base..ctor();
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000028F6 File Offset: 0x00000AF6
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("scyllareworked.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700002A RID: 42
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00002923 File Offset: 0x00000B23
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000292B File Offset: 0x00000B2B
		internal static Bitmap IconItems_flashlight
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("IconItems_flashlight", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002946 File Offset: 0x00000B46
		internal static Bitmap IconItems_flashlight1
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("IconItems_flashlight1", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00002961 File Offset: 0x00000B61
		internal static Bitmap unlock
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("unlock", Resources.resourceCulture);
			}
		}

		// Token: 0x0400006A RID: 106
		private static ResourceManager resourceMan;

		// Token: 0x0400006B RID: 107
		private static CultureInfo resourceCulture;
	}
}
