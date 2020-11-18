using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormBackEnd.Controllers;
using FormBackEnd.Model;

namespace FormBackEnd.Services
{
	public interface IStore
	{
		SubmissionResponse SaveForm(Form form);
		List<Form> GetForm(string name);
	}
}
