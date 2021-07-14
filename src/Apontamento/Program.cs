using Apontamento.Domain.Entities;
using Apontamento.Service.Interfaces;
using Apontamento.Service.Services;
using System;

namespace Apontamento.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			IApontamentoService apontamentoService = new ApontamentoService();
			var manutencao = apontamentoService.GetManutencao();
			var quantidadeProduzida = apontamentoService.GetQuantidadeProducao();
			var gaps = apontamentoService.GetGAP();

			Console.WriteLine("COGTIVExperience");
			Console.WriteLine("\n");
			
			Console.WriteLine("1. Funcionalidade Calcular GAPs");
			Console.WriteLine($"Quantidade de GAPS diário: {gaps.QuantidadeGapsDiario}");
			Console.WriteLine($"Duração de Gaps diário: {Convert.ToInt32(gaps.PeriodoGapsDiario.TotalHours)}:{gaps.PeriodoGapsDiario.Minutes.ToString().PadLeft(2,'0')}:{gaps.PeriodoGapsDiario.Seconds.ToString().PadLeft(2, '0')}");
			Console.WriteLine($"Quantidade de GAPS total: {gaps.QuantidadeGaps}");
			Console.WriteLine($"Duração de Gaps total: {Convert.ToInt32(gaps.PeriodoGap.TotalHours)}:{gaps.PeriodoGap.Minutes.ToString().PadLeft(2, '0')}:{gaps.PeriodoGap.Seconds.ToString().PadLeft(2, '0')}");
			Console.WriteLine("\n");
			
			Console.WriteLine("2. Funcionalidade Calcular Quantidades Produzidas");
			Console.WriteLine($"Quantidade Produzida: {quantidadeProduzida.QuantidadeProduzida}");
			foreach (ApontamentoProducao item in quantidadeProduzida.MaioresProducoes)
			{
				Console.WriteLine($"Lote: {item.NumeroLote} produziu {item.Quantidade}");
			}
			Console.WriteLine("\n");
			
			Console.WriteLine("3. Funcionalidade Calcular Horas de Manutenção");
			Console.WriteLine($"Período Total De Manutenção: {Convert.ToInt32(manutencao.TotalHours)}:{manutencao.Minutes.ToString().PadLeft(2, '0')}:{manutencao.Seconds.ToString().PadLeft(2, '0')}");

			Console.ReadLine();
		}
	}
}
