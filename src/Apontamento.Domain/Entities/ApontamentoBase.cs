using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento.Domain.Entities
{
	public class ApontamentoBase
	{
		public ApontamentoBase(int idApontamento, DateTime dataInicio, DateTime dataFim, string idEvento)
		{
			IdApontamento = idApontamento;
			DataInicio = dataInicio;
			DataFim = dataFim;
			IdEvento = idEvento;
		}

		public int IdApontamento { get; set; }
		public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }
		public string IdEvento { get; set; }
	}
}
