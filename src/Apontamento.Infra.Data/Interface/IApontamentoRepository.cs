using System;
using System.Collections.Generic;
using System.Text;
using Apontamento.Domain.Entities;

namespace Apontamento.Infra.Data.Interface
{
	public interface IApontamentoRepository
	{
		public IEnumerable<ApontamentoBase> GetAll();
	}
}
