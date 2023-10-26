using System.Text;

namespace ir.news.xsean
{
	public class id
	{
		private readonly Random _random = new Random();

		public long idgn(int l)
		{
			long i = 1;

			foreach (byte b in Guid.NewGuid().ToByteArray())
			{
				i *= ((int)b + 1);
			}

			string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);


			return Convert.ToInt64(number);
		}
		public string ss(int sis)
		{
			int size = sis;
			bool lowerCase = true;
			var builder = new StringBuilder(size);


			char offset = lowerCase ? 'a' : 'A';
			const int lettersOffset = 26; // A...Z or a..z: length = 26  

			for (var i = 0; i < size; i++)
			{
				var @char = (char)_random.Next(offset, offset + lettersOffset);
				builder.Append(@char);
			}

			return builder.ToString();
		}
	}
}
