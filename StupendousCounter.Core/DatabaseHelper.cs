using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupendousCounter.Core
{
	public class DatabaseHelper : IDatabaseHelper
	{
		public async Task AddOrUpdateCounterAsync(Counter counter)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Counter>> GetAllCountersAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<CounterIncrementHistory>> GetCounterHistoryAsync(int counterId)
		{
			throw new NotImplementedException();
		}

		public async Task IncrementCounterAsync(Counter counter)
		{
			throw new NotImplementedException();
		}

		public static void CreateDatabase(string dbPath)
		{

		}
	}
}
