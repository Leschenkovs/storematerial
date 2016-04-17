using System;

namespace Store.Bll.Exception
{
	[Serializable]
	public class DbOwnException : System.Exception
	{
		public DbOwnException()
			: base()
		{
		}

		public DbOwnException(String message)
			: base(message)
		{
		}
	}
}
