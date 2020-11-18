using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FormBackEnd.Controllers;
using FormBackEnd.Model;
using WebApplication1.Services;

namespace FormBackEnd.Services
{
	public class SqlStore : IStore
	{
		private readonly string connectionString;
		public SqlStore()
		{
			this.connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\morhe\Documents\FormDB.mdf;Integrated Security=True;Connect Timeout=30";
		}
		public SubmissionResponse SaveForm(Form form)
		{
			//using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
			//{
			//	using (SqlCommand command = new SqlCommand("INSERT INTO Form ( Id, Name, Email, Age ,Role,Recommendation, FavoriteFeature , Comment,Improvement) " +
			//		"Values(@Id, @Name, @Email, @Age, @Role, @Recommendation, @FavoriteFeature, @Comment, @Improvement) ", connection))
			//	{
			//		command.Parameters.AddWithValue("@Id", form.Id);
			//		command.Parameters.AddWithValue("@Name", form.Name);
			//		command.Parameters.AddWithValue("@Email", form.Email);
			//		command.Parameters.AddWithValue("@Age", form.Age);
			//		command.Parameters.AddWithValue("@Role", form.Role);
			//		command.Parameters.AddWithValue("@Recommendation", form.Recommendation);
			//		command.Parameters.AddWithValue("@Improvement", form.Improvement);
			//		command.Parameters.AddWithValue("@FavoriteFeature", form.FavoriteFeature);
			//		command.Parameters.AddWithValue("@Comment", form.Comment);
			//		connection.Open();
			//		command.ExecuteNonQuery();
			//		return new SubmissionResponse { Success = true, ErrorCode = null };

			//	}
			//}
			SqlQuery sqlQuery = new SqlQuery();
			return sqlQuery.PostQuery("INSERT INTO Form ( Id, Name, Email, Age ,Role,Recommendation, FavoriteFeature , Comment, BackEndProject,DataVisualization,FrontEndProject) " +
					"Values(@Id, @Name, @Email, @Age, @Role, @Recommendation, @FavoriteFeature, @Comment,@BackEndProject,@DataVisualization,@FrontEndProject ) ",
			new[] {
			new SqlParameter("@Id", form.Id),
			new SqlParameter("@Name", form.Name),
			new SqlParameter("@Email", form.Email),
			new SqlParameter("@Age", form.Age),
			new SqlParameter("@Role", form.Role),
			new SqlParameter("@Recommendation", form.Recommendation),
			new SqlParameter("@BackEndProject", form.BackEndProject),
			new SqlParameter("@FrontEndProject", form.FrontEndProject),
			new SqlParameter("@DataVisualization", form.DataVisualization),

			new SqlParameter("@FavoriteFeature", form.FavoriteFeature),
			new SqlParameter("@Comment", form.Comment) });



		}
		public List<Form> GetForm(string formName)
		{



			SqlQuery sqlQuery = new SqlQuery();

			DataTable dataTable = sqlQuery.ExcuteReader("SELECT * FROM Form WHERE Name LIKE '%' +  @name + '%'",
				new SqlParameter("@name", formName));
			var forms = new List<Form>();
			foreach (DataRow row in dataTable.Rows)
			{


				forms.Add(new Form
				{
					Id = (Guid)row["Id"],
					Name = (string)row["Name"],
					Email = (string)row["Email"],
					Role = (currentRole)row["Role"],
					FavoriteFeature = (Favorite)row["FavoriteFeature"],
					Recommendation = (Recommend)row["Recommendation"],
					BackEndProject = (bool)row["BackEndProject"],
					FrontEndProject = (bool)row["FrontEndProject"],
					DataVisualization = (bool)row["DataVisualization"],
					Comment = (string)row["Comment"],
					Age = (int)row["Age"]



				});
			}
			return forms;
		}
	}
}
