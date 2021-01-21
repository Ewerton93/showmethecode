using CalculoJuros.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Servico
{
    public class UrlRepositorioGit : IUrlRepositorioGit
    {
        public string ObterUrl()
        {
            return "https://github.com/Ewerton93/showmethecode";
        }
    }
}
