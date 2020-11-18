using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormBackEnd.Controllers
{
	public class Form
	{ public Guid Id { set; get; }
		public string Name { set; get; }
		public string Email { set; get; }
		public int Age { set; get; }
		public currentRole Role { set; get; }
		public bool FrontEndProject { set; get; }
		public bool BackEndProject { set; get; }
		public bool	DataVisualization { set; get; }
		public Favorite FavoriteFeature { set; get; }
		//public List<string> Improvement { set; get; }
		public string Comment { set; get; }
		public DateTime date { set; get; }

		public  Recommend Recommendation { set; get; }
	}
	public enum currentRole
	{
	    Student,
		FullTimeJob,
		FullTimeLearner,
		PreferNotToSay,
		Other

	}
	public enum Recommend
		{
		Defenetly,
		Maybe,
		NotSure


		}
	public enum Favorite
	{
		Challenges,
		Project,
		Community,
		OpenSource


	}
}
