using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using FormBackEnd.Model;
namespace FormBackEnd.Controllers
{
	
	public class FormController : ControllerBase

	{	private readonly IStore store;

		public FormController(IStore store)
		{
			this.store = store;
		}

		[Route("api/[controller]")]
		[HttpPost]
		public ActionResult<SubmissionResponse> SaveForm([FromBody] Form form)
		{
			form.Id = Guid.NewGuid();
			if (form == null)
			{
				return BadRequest(new SubmissionResponse
				{
					Success = false,
					ErrorCode = "invalid"
				});
			}

			

			var submissionResult = store.SaveForm(form);

			if (!submissionResult.Success)
			{
				return BadRequest(submissionResult);
			}

			return Ok(submissionResult);
		}
		[HttpGet()]
		[Route("api/[controller]/{name}")]
		public ActionResult<string> Get(string name)
		{
			List<Form> ListofEmployees = store.GetForm(name);
			return Ok(ListofEmployees);

		}
	}
}
