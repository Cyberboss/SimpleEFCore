using Microsoft.EntityFrameworkCore;

namespace SimpleSQLShit
{
	/// <summary>
	/// Db representation
	/// </summary>
    class DatabaseContext : DbContext
    {
		/// <summary>
		/// Table representation
		/// </summary>
		public DbSet<OurModel> OurModels { get; set; }
		
		/// <summary>
		/// Another table
		/// </summary>
		public DbSet<OurOtherModel> OurOtherModels { get; set; }
		
		/// <summary>
		/// Configure the connection
		/// </summary>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("<your connection string>");
		}
	}
}
