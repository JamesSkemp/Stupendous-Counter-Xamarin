using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupendousCounter.Core
{
	public class DatabaseHelper : IDatabaseHelper
	{
		private static string _dbPath;

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
			_dbPath = dbPath;
			using (var connection = new SQLite.SQLiteConnection(dbPath, SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.ReadWrite))
			{
				connection.CreateTable<Counter>();
				connection.CreateTable<CounterIncrementHistory>();
			}
		}
	}
}
