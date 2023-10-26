using ir.news.xsean;
using System.ComponentModel.DataAnnotations;

public class coment : BaseEntity
{

	public newss? news { get; set; }

#pragma warning disable CS8618 // Non-nullable property 'name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
	public string name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
	[Required]
#pragma warning disable CS8618 // Non-nullable property 'com' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
	public string com { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'com' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.



}
