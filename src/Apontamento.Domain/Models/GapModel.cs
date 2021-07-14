using System;
using System.Collections.Generic;
using System.Text;

namespace Apontamento.Domain.Models
{
	public class GapModel
	{
		public int QuantidadeGaps { get; set; }
		public int QuantidadeGapsDiario { get; set; }
		public TimeSpan PeriodoGap { get; set; }
		public TimeSpan PeriodoGapsDiario { get; set; }
	}
}
