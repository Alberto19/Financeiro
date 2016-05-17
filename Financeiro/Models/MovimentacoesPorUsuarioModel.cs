using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class MovimentacoesPorUsuarioModel
    {

        public int? UsuarioId { get; set; }
        public IList<Movimentacao> Movimentacoes { get; set; }
        public IList<Usuario> Usuarios { get; set; }       


    }
}