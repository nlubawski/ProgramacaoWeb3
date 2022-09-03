using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoWeb3.Core.Interface
{
    public interface IClientService
    {
        ActionResult<List<Client>> GetClients();
    }
}
