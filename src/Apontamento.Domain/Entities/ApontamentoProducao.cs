using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento.Domain.Entities
{
	public class ApontamentoProducao : ApontamentoBase
	{

		public ApontamentoProducao(int idApontamento, DateTime dataInicio, DateTime dataFim, string idEvento, int? numeroLote, int quantidade) : base(idApontamento, dataInicio, dataFim, idEvento)
		{
			NumeroLote = numeroLote;
			Quantidade = quantidade;
		}

		public int? NumeroLote { get; set; }
		public int Quantidade { get; set; }
	}
}
