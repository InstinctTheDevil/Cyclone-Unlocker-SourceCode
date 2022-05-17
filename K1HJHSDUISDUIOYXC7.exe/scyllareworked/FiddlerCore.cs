using System;
using System.IO;
using BCCertMaker;
using Fiddler;

namespace scyllareworked
{
	// Token: 0x02000006 RID: 6
	public static class FiddlerCore
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000026 RID: 38 RVA: 0x00004E04 File Offset: 0x00003004
		// (remove) Token: 0x06000027 RID: 39 RVA: 0x00004E38 File Offset: 0x00003038
		public static event FiddlerCore.CookieHandler OnTokenReceived;

		// Token: 0x06000028 RID: 40 RVA: 0x00002444 File Offset: 0x00000644
		static FiddlerCore()
		{
			Class2.Gd1ILo6zDdAXZ();
			FiddlerCore.AssemblyDirectory = Path.GetTempPath();
			FiddlerCore.responded = false;
			FiddlerApplication.BeforeRequest += new SessionStateHandler(FiddlerCore.FiddlerApplication_BeforeRequest);
			FiddlerCore.EnsureRootCertificate();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004E6C File Offset: 0x0000306C
		private static void FiddlerApplication_BeforeRequest(Session oSession)
		{
			if (oSession.uriContains("api/v1/inventories"))
			{
				oSession.bBufferResponse = true;
				oSession.utilDecodeResponse();
				oSession.oFlags["x-replywithfile"] = Path.GetTempPath() + "google.txt";
				FiddlerCore.hui();
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000022D3 File Offset: 0x000004D3
		private static void hui()
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00004EB8 File Offset: 0x000030B8
		private static void EnsureRootCertificate()
		{
			BCCertMaker bccertMaker = new BCCertMaker();
			CertMaker.oCertProvider = bccertMaker;
			string text = Path.Combine(FiddlerCore.AssemblyDirectory, "defaultCertificate.p12");
			string text2 = "$0M3$H1T";
			if (!File.Exists(text))
			{
				CertMaker.removeFiddlerGeneratedCerts(true);
				bccertMaker.CreateRootCertificate();
				bccertMaker.WriteRootCertificateAndPrivateKeyToPkcs12File(text, text2, null);
			}
			else
			{
				bccertMaker.ReadRootCertificateAndPrivateKeyFromPkcs12File(text, text2, null);
			}
			if (CertMaker.rootCertIsTrusted())
			{
				return;
			}
			CertMaker.trustRootCert();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002471 File Offset: 0x00000671
		public static void Start()
		{
			CONFIG.IgnoreServerCertErrors = true;
			FiddlerApplication.Startup(new FiddlerCoreStartupSettingsBuilder().ListenOnPort(0).RegisterAsSystemProxy().ChainToUpstreamGateway().DecryptSSL().OptimizeThreadPool().Build());
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000024A2 File Offset: 0x000006A2
		public static void Stop()
		{
			FiddlerApplication.Shutdown();
		}

		// Token: 0x0400002E RID: 46
		private static readonly string AssemblyDirectory;

		// Token: 0x0400002F RID: 47
		public static bool responded;

		// Token: 0x02000007 RID: 7
		// (Invoke) Token: 0x0600002F RID: 47
		public delegate void CookieHandler(string cookie);
	}
}
