using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento.Domain.Entities
{
	public class ApontamentoManutencao : ApontamentoBase
	{
		public ApontamentoManutencao(int idApontamento, DateTime dataInicio, DateTime dataFim, string idEvento) : base(idApontamento, dataInicio, dataFim, idEvento)
		{
		}
	}
}
