namespace Store.Model.RequestObjects
{
	public class QueryRequest
	{
		public int id { get; set; }

		// for paging
		public string page { get; set; }
		public string pageSize { get; set; }
	}

	public class QueryRequest<T> : QueryRequest where T : class
	{
		public T model { get; set; }
	}
}