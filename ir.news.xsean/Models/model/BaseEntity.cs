using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ir.news.xsean
{
	public abstract class BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }
		public DateTime InsertTime { get; set; } = DateTime.Now;
		public DateTime? UpdateTime { get; set; }
		public bool IsRemoved { get; set; } = false;
		public DateTime? RemoveTime { get; set; }
	}
	//public abstract class BaseEntity : BaseEntity<long>
	//{
	//}
}
