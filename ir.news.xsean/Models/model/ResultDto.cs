namespace ir.news.xsea
{
	public class ResultDto
	{
		public bool IsSuccess { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Message' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public string Message { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Message' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
	}

	public class ResultDto<T>
	{
		public bool IsSuccess { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Message' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public string Message { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Message' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public T Data { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
	}
}
