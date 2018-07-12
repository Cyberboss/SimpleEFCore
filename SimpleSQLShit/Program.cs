using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SimpleSQLShit
{
    class Program
    {
		static void Main(string[] args)
		{
			using (var db = new DatabaseContext())
			{
				//runs commands to create the database
				db.Database.EnsureCreated();

				//lets make a model tree
				var parent = new OurOtherModel
				{
					//we don't assign the id columns
					Title = "Main",
					OurModels = new List<OurModel>
					{
						new OurModel
						{
							Data = 42
						},
						new OurModel
						{
							Data = 21
						}
					}
				};

				//add it to the "context" (its not in the db yet)
				db.OurOtherModels.Add(parent);

				//lets add one more unassociated OurModel for demo purposes
				db.OurModels.Add(new OurModel
				{
					Data = 16
				});

				//now save changes does all the sql shit
				db.SaveChanges();
			}
			//ok that was fun now i want my data back

			//try to use a different instance of your context class per .SaveChanges() call, things get fucky and memory intensive otherwise
			using (var db = new DatabaseContext())
			{
				//SELECT * FROM OurModels
				var results = db.OurModels.ToListAsync().Result;

				foreach (var I in results)
					Console.WriteLine("OurModel: ID: " + I.Id + " Data: " + I.Data);


				//SELECT * FROM OurOtherModels (with a join on OurModels via .Include (i forget the syntax))
				
				var results2 = db.OurOtherModels.Include(x => x.OurModels).ToListAsync().Result;

				foreach (var I in results2)
					Console.WriteLine("OurOtherModel: ID: " + I.Id + " Title: " + I.Title + " ChildCount: " + I.OurModels.Count);
			}
		}
    }
}
