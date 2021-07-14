using Apontamento.Domain.Entities;
using Apontamento.Domain.Models;
using Apontamento.Infra.Data.Interface;
using Apontamento.Infra.Data.Repository;
using Apontamento.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apontamento.Service.Services
{
	public class ApontamentoService : IApontamentoService
	{
		private readonly IApontamentoRepository _apontamentoRepository;
		List<ApontamentoBase> apontamentos;

		public ApontamentoService()
		{
			_apontamentoRepository = new ApontamentoRepository();
			apontamentos = new List<ApontamentoBase>(_apontamentoRepository.GetAll());
		}

		public ProducaoModel GetQuantidadeProducao()
		{
			var producao = new ProducaoModel();
			var listProducao = new List<ApontamentoProducao>();

			foreach (var item in apontamentos)
			{
				if (item is ApontamentoProducao)
				{
					producao.QuantidadeProduzida += ((ApontamentoProducao)item).Quantidade;
					listProducao.Add((ApontamentoProducao)item);
				}
			}

			producao.MaioresProducoes = listProducao.GroupBy(p => p.NumeroLote)
								.Select(q => new ApontamentoProducao(q.First().IdApontamento, q.First().DataInicio, q.First().DataFim, q.First().IdEvento, q.First().NumeroLote.Value, q.Sum(c => c.Quantidade))).OrderByDescending(x => x.Quantidade).Take(3);

			return producao;
		}

		public GapModel GetGAP()
		{
			GapModel gap = new GapModel();
			for (int i = 0; i < apontamentos.Count; i++)
			{
				DateTime dataInicio = apontamentos[i].DataFim;
				DateTime dataFim;
				if (apontamentos.Count > i + 1)
				{
					dataFim = apontamentos[i + 1].DataInicio;

					if (dataFim > dataInicio && dataFim.ToString("dd/MM/yyyy") == dataInicio.ToString("dd/MM/yyyy"))
					{
						gap.QuantidadeGapsDiario += 1;
						gap.PeriodoGapsDiario = gap.PeriodoGapsDiario.Add(dataFim - dataInicio);
					}
					if(dataFim > dataInicio)
					{
						gap.QuantidadeGaps += 1;
						gap.PeriodoGap = gap.PeriodoGap.Add(dataFim - dataInicio);
					}
				}

			}

			return gap;
		}


		public TimeSpan GetManutencao()
		{
			TimeSpan totalHoras = new TimeSpan();
			foreach(var item in apontamentos)
			{
				if(item is ApontamentoManutencao)
				{
					totalHoras = totalHoras.Add(item.DataFim - item.DataInicio);
				}
			}
			return totalHoras;
		}

	}
}
