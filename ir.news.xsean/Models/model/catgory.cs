using System.ComponentModel.DataAnnotations;

namespace ir.news.xsean
{
	public class catgory
	{
		[Key]
		public int id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public int count { get; set; } = 0;
		public ICollection<newss>? Newsses { get; set; }



	}
}
