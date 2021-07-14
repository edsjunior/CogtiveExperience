using Apontamento.Domain.Entities;
using Apontamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento.Service.Interfaces
{
	public interface IApontamentoService
	{
		public TimeSpan GetManutencao();
		public GapModel GetGAP();

		public ProducaoModel GetQuantidadeProducao();
	}
}
