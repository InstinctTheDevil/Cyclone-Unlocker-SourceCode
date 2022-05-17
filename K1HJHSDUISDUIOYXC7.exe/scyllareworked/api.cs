using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace scyllareworked
{
	// Token: 0x02000008 RID: 8
	public class api
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00004F20 File Offset: 0x00003120
		public api(string name, string ownerid, string secret, string version)
		{
			Class2.Gd1ILo6zDdAXZ();
			this.app_data = new api.app_data_class();
			this.user_data = new api.user_data_class();
			this.response = new api.response_class();
			this.response_decoder = new json_wrapper(new api.response_structure());
			base..ctor();
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004FB8 File Offset: 0x000031B8
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				Process.Start(response_structure.download);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000513C File Offset: 0x0000333C
		public void register(string username, string pass, string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000052A8 File Offset: 0x000034A8
		public void login(string username, string pass)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000053FC File Offset: 0x000035FC
		public void upgrade(string username, string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000552C File Offset: 0x0000372C
		public void license(string key)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005668 File Offset: 0x00003868
		public void setvar(string var, string data)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005780 File Offset: 0x00003980
		public string getvar(string var)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005890 File Offset: 0x00003A90
		public void ban()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005978 File Offset: 0x00003B78
		public string var(string varid)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005A98 File Offset: 0x00003C98
		public List<api.msg> chatget(string channelname)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005BA8 File Offset: 0x00003DA8
		public bool chatsend(string msg, string channelname)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005CCC File Offset: 0x00003ECC
		public bool checkblack()
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005DE8 File Offset: 0x00003FE8
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
				return null;
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005F44 File Offset: 0x00004144
		public byte[] download(string fileid)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first. File is empty since no request could be made.");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000605C File Offset: 0x0000425C
		public void log(string message)
		{
			if (!this.initzalized)
			{
				api.error("Please initzalize first");
				Environment.Exit(0);
			}
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			api.req(nameValueCollection);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00006158 File Offset: 0x00004358
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000061C8 File Offset: 0x000043C8
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00006218 File Offset: 0x00004418
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000062B4 File Offset: 0x000044B4
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00006318 File Offset: 0x00004518
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000024A9 File Offset: 0x000006A9
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000031 RID: 49
		public string name;

		// Token: 0x04000032 RID: 50
		public string ownerid;

		// Token: 0x04000033 RID: 51
		public string secret;

		// Token: 0x04000034 RID: 52
		public string version;

		// Token: 0x04000035 RID: 53
		private string sessionid;

		// Token: 0x04000036 RID: 54
		private string enckey;

		// Token: 0x04000037 RID: 55
		private bool initzalized;

		// Token: 0x04000038 RID: 56
		public api.app_data_class app_data;

		// Token: 0x04000039 RID: 57
		public api.user_data_class user_data;

		// Token: 0x0400003A RID: 58
		public api.response_class response;

		// Token: 0x0400003B RID: 59
		private json_wrapper response_decoder;

		// Token: 0x02000009 RID: 9
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000002 RID: 2
			// (get) Token: 0x06000048 RID: 72 RVA: 0x000024CD File Offset: 0x000006CD
			// (set) Token: 0x06000049 RID: 73 RVA: 0x000024D5 File Offset: 0x000006D5
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x0600004A RID: 74 RVA: 0x000024DE File Offset: 0x000006DE
			// (set) Token: 0x0600004B RID: 75 RVA: 0x000024E6 File Offset: 0x000006E6
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x0600004C RID: 76 RVA: 0x000024EF File Offset: 0x000006EF
			// (set) Token: 0x0600004D RID: 77 RVA: 0x000024F7 File Offset: 0x000006F7
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x0600004E RID: 78 RVA: 0x00002500 File Offset: 0x00000700
			// (set) Token: 0x0600004F RID: 79 RVA: 0x00002508 File Offset: 0x00000708
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000050 RID: 80 RVA: 0x00002511 File Offset: 0x00000711
			// (set) Token: 0x06000051 RID: 81 RVA: 0x00002519 File Offset: 0x00000719
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000052 RID: 82 RVA: 0x00002522 File Offset: 0x00000722
			// (set) Token: 0x06000053 RID: 83 RVA: 0x0000252A File Offset: 0x0000072A
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000054 RID: 84 RVA: 0x00002533 File Offset: 0x00000733
			// (set) Token: 0x06000055 RID: 85 RVA: 0x0000253B File Offset: 0x0000073B
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000056 RID: 86 RVA: 0x00002544 File Offset: 0x00000744
			// (set) Token: 0x06000057 RID: 87 RVA: 0x0000254C File Offset: 0x0000074C
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000058 RID: 88 RVA: 0x00002555 File Offset: 0x00000755
			// (set) Token: 0x06000059 RID: 89 RVA: 0x0000255D File Offset: 0x0000075D
			[DataMember]
			public List<api.msg> messages { get; set; }

			// Token: 0x0600005A RID: 90 RVA: 0x00002437 File Offset: 0x00000637
			public response_structure()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x0200000A RID: 10
		public class msg
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600005B RID: 91 RVA: 0x00002566 File Offset: 0x00000766
			// (set) Token: 0x0600005C RID: 92 RVA: 0x0000256E File Offset: 0x0000076E
			public string message { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600005D RID: 93 RVA: 0x00002577 File Offset: 0x00000777
			// (set) Token: 0x0600005E RID: 94 RVA: 0x0000257F File Offset: 0x0000077F
			public string author { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x0600005F RID: 95 RVA: 0x00002588 File Offset: 0x00000788
			// (set) Token: 0x06000060 RID: 96 RVA: 0x00002590 File Offset: 0x00000790
			public string timestamp { get; set; }

			// Token: 0x06000061 RID: 97 RVA: 0x00002437 File Offset: 0x00000637
			public msg()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x0200000B RID: 11
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000062 RID: 98 RVA: 0x00002599 File Offset: 0x00000799
			// (set) Token: 0x06000063 RID: 99 RVA: 0x000025A1 File Offset: 0x000007A1
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000064 RID: 100 RVA: 0x000025AA File Offset: 0x000007AA
			// (set) Token: 0x06000065 RID: 101 RVA: 0x000025B2 File Offset: 0x000007B2
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000066 RID: 102 RVA: 0x000025BB File Offset: 0x000007BB
			// (set) Token: 0x06000067 RID: 103 RVA: 0x000025C3 File Offset: 0x000007C3
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000068 RID: 104 RVA: 0x000025CC File Offset: 0x000007CC
			// (set) Token: 0x06000069 RID: 105 RVA: 0x000025D4 File Offset: 0x000007D4
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600006A RID: 106 RVA: 0x000025DD File Offset: 0x000007DD
			// (set) Token: 0x0600006B RID: 107 RVA: 0x000025E5 File Offset: 0x000007E5
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600006C RID: 108 RVA: 0x000025EE File Offset: 0x000007EE
			// (set) Token: 0x0600006D RID: 109 RVA: 0x000025F6 File Offset: 0x000007F6
			[DataMember]
			public List<api.Data> subscriptions { get; set; }

			// Token: 0x0600006E RID: 110 RVA: 0x00002437 File Offset: 0x00000637
			public user_data_structure()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x0200000C RID: 12
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600006F RID: 111 RVA: 0x000025FF File Offset: 0x000007FF
			// (set) Token: 0x06000070 RID: 112 RVA: 0x00002607 File Offset: 0x00000807
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00002610 File Offset: 0x00000810
			// (set) Token: 0x06000072 RID: 114 RVA: 0x00002618 File Offset: 0x00000818
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00002621 File Offset: 0x00000821
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00002629 File Offset: 0x00000829
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000075 RID: 117 RVA: 0x00002632 File Offset: 0x00000832
			// (set) Token: 0x06000076 RID: 118 RVA: 0x0000263A File Offset: 0x0000083A
			[DataMember]
			public string version { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000077 RID: 119 RVA: 0x00002643 File Offset: 0x00000843
			// (set) Token: 0x06000078 RID: 120 RVA: 0x0000264B File Offset: 0x0000084B
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x06000079 RID: 121 RVA: 0x00002437 File Offset: 0x00000637
			public app_data_structure()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x0200000D RID: 13
		public class app_data_class
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600007A RID: 122 RVA: 0x00002654 File Offset: 0x00000854
			// (set) Token: 0x0600007B RID: 123 RVA: 0x0000265C File Offset: 0x0000085C
			public string numUsers { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00002665 File Offset: 0x00000865
			// (set) Token: 0x0600007D RID: 125 RVA: 0x0000266D File Offset: 0x0000086D
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600007E RID: 126 RVA: 0x00002676 File Offset: 0x00000876
			// (set) Token: 0x0600007F RID: 127 RVA: 0x0000267E File Offset: 0x0000087E
			public string numKeys { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000080 RID: 128 RVA: 0x00002687 File Offset: 0x00000887
			// (set) Token: 0x06000081 RID: 129 RVA: 0x0000268F File Offset: 0x0000088F
			public string version { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000082 RID: 130 RVA: 0x00002698 File Offset: 0x00000898
			// (set) Token: 0x06000083 RID: 131 RVA: 0x000026A0 File Offset: 0x000008A0
			public string customerPanelLink { get; set; }

			// Token: 0x06000084 RID: 132 RVA: 0x00002437 File Offset: 0x00000637
			public app_data_class()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x0200000E RID: 14
		public class user_data_class
		{
			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000085 RID: 133 RVA: 0x000026A9 File Offset: 0x000008A9
			// (set) Token: 0x06000086 RID: 134 RVA: 0x000026B1 File Offset: 0x000008B1
			public string username { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000087 RID: 135 RVA: 0x000026BA File Offset: 0x000008BA
			// (set) Token: 0x06000088 RID: 136 RVA: 0x000026C2 File Offset: 0x000008C2
			public string ip { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000089 RID: 137 RVA: 0x000026CB File Offset: 0x000008CB
			// (set) Token: 0x0600008A RID: 138 RVA: 0x000026D3 File Offset: 0x000008D3
			public string hwid { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600008B RID: 139 RVA: 0x000026DC File Offset: 0x000008DC
			// (set) Token: 0x0600008C RID: 140 RVA: 0x000026E4 File Offset: 0x000008E4
			public string createdate { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600008D RID: 141 RVA: 0x000026ED File Offset: 0x000008ED
			// (set) Token: 0x0600008E RID: 142 RVA: 0x000026F5 File Offset: 0x000008F5
			public string lastlogin { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600008F RID: 143 RVA: 0x000026FE File Offset: 0x000008FE
			// (set) Token: 0x06000090 RID: 144 RVA: 0x00002706 File Offset: 0x00000906
			public List<api.Data> subscriptions { get; set; }

			// Token: 0x06000091 RID: 145 RVA: 0x00002437 File Offset: 0x00000637
			public user_data_class()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x0200000F RID: 15
		public class Data
		{
			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000092 RID: 146 RVA: 0x0000270F File Offset: 0x0000090F
			// (set) Token: 0x06000093 RID: 147 RVA: 0x00002717 File Offset: 0x00000917
			public string subscription { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000094 RID: 148 RVA: 0x00002720 File Offset: 0x00000920
			// (set) Token: 0x06000095 RID: 149 RVA: 0x00002728 File Offset: 0x00000928
			public string expiry { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000096 RID: 150 RVA: 0x00002731 File Offset: 0x00000931
			// (set) Token: 0x06000097 RID: 151 RVA: 0x00002739 File Offset: 0x00000939
			public string timeleft { get; set; }

			// Token: 0x06000098 RID: 152 RVA: 0x00002437 File Offset: 0x00000637
			public Data()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}

		// Token: 0x02000010 RID: 16
		public class response_class
		{
			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000099 RID: 153 RVA: 0x00002742 File Offset: 0x00000942
			// (set) Token: 0x0600009A RID: 154 RVA: 0x0000274A File Offset: 0x0000094A
			public bool success { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600009B RID: 155 RVA: 0x00002753 File Offset: 0x00000953
			// (set) Token: 0x0600009C RID: 156 RVA: 0x0000275B File Offset: 0x0000095B
			public string message { get; set; }

			// Token: 0x0600009D RID: 157 RVA: 0x00002437 File Offset: 0x00000637
			public response_class()
			{
				Class2.Gd1ILo6zDdAXZ();
				base..ctor();
			}
		}
	}
}
