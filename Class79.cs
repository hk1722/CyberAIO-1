﻿using System;
using System.IO;

// Token: 0x02000091 RID: 145
internal static class Class79
{
	// Token: 0x0600030A RID: 778 RVA: 0x0001B008 File Offset: 0x00019208
	public static byte[] smethod_0(string string_0)
	{
		if (string_0 == null)
		{
			throw new Exception();
		}
		MemoryStream memoryStream = new MemoryStream(string_0.Length * 4 / 5);
		byte[] result;
		try
		{
			int num = 0;
			uint num2 = 0u;
			foreach (char c in string_0)
			{
				if (c == 'z' && num == 0)
				{
					Class79.smethod_1(memoryStream, num2, 0);
				}
				else
				{
					if (c < '!' || c > 'u')
					{
						throw new Exception();
					}
					checked
					{
						num2 += (uint)(unchecked((ulong)Class79.uint_0[num]) * (ulong)(unchecked((long)(checked(c - '!')))));
					}
					num++;
					if (num == 5)
					{
						Class79.smethod_1(memoryStream, num2, 0);
						num = 0;
						num2 = 0u;
					}
				}
			}
			if (num == 1)
			{
				throw new Exception();
			}
			if (num > 1)
			{
				for (int j = num; j < 5; j++)
				{
					checked
					{
						num2 += 84u * Class79.uint_0[j];
					}
				}
				Class79.smethod_1(memoryStream, num2, 5 - num);
			}
			result = memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
		return result;
	}

	// Token: 0x0600030B RID: 779 RVA: 0x0001B0F8 File Offset: 0x000192F8
	private static void smethod_1(Stream stream_0, uint uint_1, int int_0)
	{
		stream_0.WriteByte((byte)(uint_1 >> 24));
		if (int_0 == 3)
		{
			return;
		}
		stream_0.WriteByte((byte)(uint_1 >> 16 & 255u));
		if (int_0 == 2)
		{
			return;
		}
		stream_0.WriteByte((byte)(uint_1 >> 8 & 255u));
		if (int_0 == 1)
		{
			return;
		}
		stream_0.WriteByte((byte)(uint_1 & 255u));
	}

	// Token: 0x040001A9 RID: 425
	private static readonly uint[] uint_0 = new uint[]
	{
		52200625u,
		614125u,
		7225u,
		85u,
		1u
	};
}
