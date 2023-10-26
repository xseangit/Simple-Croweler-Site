using System.ComponentModel.DataAnnotations;

namespace ir.news.xsean
{
	public class newss : BaseEntity
	{

		[Required]
#pragma warning disable CS8618 // Non-nullable property 'url' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public string url { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'url' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

		public string? site { get; set; }
		public string? titleimg { get; set; }
		public string? titleimgdo { get; set; }

		public string? title { get; set; }
		//public string? category { get; set; }

		public string? news { get; set; }
		public string? newser { get; set; }
		public string? datetime { get; set; }
		public string? shorts { get; set; }
		public catgory? Catgory { get; set; }
        public virtual int Catgoryid { get; set; }

        public int? seen { get; set; }
		public int? like { get; set; }

		public ICollection<coment>? coment { get; set; }


	}

}
