using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProgramacaoWeb3.Core.Interface;

namespace ProgramacaoWeb3.Filters
{
    public class ActionFilterCpfIsValid : ActionFilterAttribute
    {

        private readonly IClientService _clientService;

        public ActionFilterCpfIsValid(IClientService clientService)
        {
            _clientService = clientService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Client? client = (Client?)context.ActionArguments["Client"];

            if (_clientService.DescriptionClient(client.Cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
