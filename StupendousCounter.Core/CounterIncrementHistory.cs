using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupendousCounter.Core
{
	public class CounterIncrementHistory
	{
		[Indexed]
		public int CounterId { get; set; }
		public DateTime IncrementDateTimeUtc { get; set; }
	}
}
