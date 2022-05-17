using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace scyllareworked
{
	// Token: 0x02000012 RID: 18
	public class json_wrapper
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00002780 File Offset: 0x00000980
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006690 File Offset: 0x00004890
		public json_wrapper(object obj_to_work_with)
		{
			Class2.Gd1ILo6zDdAXZ();
			base..ctor();
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000066E8 File Offset: 0x000048E8
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000279E File Offset: 0x0000099E
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000063 RID: 99
		private DataContractJsonSerializer serializer;

		// Token: 0x04000064 RID: 100
		private object current_object;
	}
}
