using Apontamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento.Domain.Models
{
	public class ProducaoModel
	{
		public ProducaoModel()
		{
			MaioresProducoes = new List<ApontamentoProducao>();
		}
		public int QuantidadeProduzida { get; set; }
		public IEnumerable<ApontamentoProducao> MaioresProducoes { get; set; }

		
	}
}
