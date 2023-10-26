using System.ComponentModel.DataAnnotations;


namespace ir.news.xsean
{
	public class urlscro
	{
		[Required]
		[Key]
#pragma warning disable CS8618 // Non-nullable property 'url' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public string url { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'url' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public bool crowel { get; set; } = false;

		public bool bad { get; set; } = false;

	}
}
