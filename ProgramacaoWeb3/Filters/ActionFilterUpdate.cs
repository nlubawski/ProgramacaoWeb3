using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProgramacaoWeb3.Core.Interface;

namespace ProgramacaoWeb3.Filters
{
    public class ActionFilterUpdate : IActionFilter
    {
        private readonly IClientService _clientService;

        public ActionFilterUpdate(IClientService clientService)
        {
            _clientService = clientService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.ErrorCount != 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string? cpf = (string?) context.ActionArguments["cpf"];
            if (_clientService.DescriptionClient(cpf) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
