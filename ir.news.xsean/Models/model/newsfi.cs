using System.ComponentModel.DataAnnotations;

namespace ir.news.xsean
{
	public class newsfi : BaseEntity
	{

		[Required]
#pragma warning disable CS8618 // Non-nullable property 'url' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public string url { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'url' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
		public catgory? Catgory { get; set; }
		public virtual int Catgoryid { get; set; }
        public int? seen { get; set; }
		public int? like { get; set; }
		public int? coment { get; set; }
		public string? datetime { get; set; }


	}

}
