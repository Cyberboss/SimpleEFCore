using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSQLShit
{
	public class OurOtherModel
	{
		/// <summary>
		/// The Id column
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// A non-nullable string column
		/// </summary>
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// This creates a foreign key to us on the <see cref="OurModel"/> table
		/// </summary>
		public List<OurModel> OurModels { get; set; }
	}
}