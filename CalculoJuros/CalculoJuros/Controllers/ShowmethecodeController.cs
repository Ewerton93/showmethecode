using CalculoJuros.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowmethecodeController : ControllerBase
    {
        private readonly IUrlRepositorioGit _urlRepositorioGit;
        public ShowmethecodeController(IUrlRepositorioGit urlRepositorioGit)
        {
            _urlRepositorioGit = urlRepositorioGit;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_urlRepositorioGit.ObterUrl());
        }
    }
}
