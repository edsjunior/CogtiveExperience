using Apontamento.Domain.Entities;
using Apontamento.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Apontamento.Infra.Data.Repository
{
	public class ApontamentoRepository : IApontamentoRepository
	{
		public IList<ApontamentoBase> listaApontamentos;

		public IEnumerable<ApontamentoBase> GetAll()
		{
			StreamReader reader = new StreamReader(@"C:\Users\esdra\Downloads\data.csv", Encoding.UTF8, true);

			listaApontamentos = new List<ApontamentoBase>();
			while (!reader.EndOfStream)
			{

				string linha = reader.ReadLine();

				if (linha == null) break;
				string[] linhaseparada = linha.Split(';');
				int idApontamento = Convert.ToInt32(linhaseparada[0]);
				DateTime dataInicio = DateTime.ParseExact(linhaseparada[1], "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture);
				DateTime dataFim = DateTime.ParseExact(linhaseparada[2], "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture);
				string idEvento = linhaseparada[4];

				if (linhaseparada[4] == "19")
				{
					var apontamento = new ApontamentoManutencao(idApontamento, dataInicio, dataFim, idEvento);
					listaApontamentos.Add(apontamento);
				}
				else if (linhaseparada[4] == "1" || linhaseparada[4] == "2")
				{
					int numeroLote = Convert.ToInt32(linhaseparada[3]);
					int quantidade = Convert.ToInt32(linhaseparada[5]);

					var apontamento = new ApontamentoProducao(idApontamento, dataInicio, dataFim, idEvento, numeroLote, quantidade);
					listaApontamentos.Add(apontamento);

				}
				else
				{
					var apontamento = new ApontamentoBase(idApontamento, dataInicio, dataFim, idEvento);
					listaApontamentos.Add(apontamento);
				}


			}
			return listaApontamentos.ToList();

		}
	}
}
