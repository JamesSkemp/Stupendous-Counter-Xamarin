using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupendousCounter.Core
{
	public interface IDatabaseHelper
	{
		Task AddOrUpdateCounterAsync(Counter counter);
		Task IncrementCounterAsync(Counter counter);
		Task<IEnumerable<Counter>> GetAllCountersAsync();
		Task<IEnumerable<CounterIncrementHistory>> GetCounterHistoryAsync(int counterId);
	}
}
