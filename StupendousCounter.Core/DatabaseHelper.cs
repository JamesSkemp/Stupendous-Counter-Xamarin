using SQLite;
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
			var connection = new SQLiteAsyncConnection(_dbPath);

			if (counter.Id == 0)
			{
				// Adding a new counter. This will update the Id on the counter with the new id.
				await connection.InsertAsync(counter);
			}
			else
			{
				// Update an existing counter.
				await connection.InsertOrReplaceAsync(counter);
			}
		}

		public async Task<IEnumerable<Counter>> GetAllCountersAsync()
		{
			var connection = new SQLiteAsyncConnection(_dbPath);
			return await connection.Table<Counter>().ToListAsync();
		}

		public async Task<IEnumerable<CounterIncrementHistory>> GetCounterHistoryAsync(int counterId)
		{
			var connection = new SQLiteAsyncConnection(_dbPath);
			return await connection.Table<CounterIncrementHistory>().Where(c => c.CounterId == counterId).ToListAsync();
		}

		public async Task IncrementCounterAsync(Counter counter)
		{
			var connection = new SQLiteAsyncConnection(_dbPath);

			counter.Value++;
			await AddOrUpdateCounterAsync(counter);
			var history = new CounterIncrementHistory
			{
				CounterId = counter.Id,
				IncrementDateTimeUtc = DateTime.UtcNow
			};

			await connection.InsertAsync(history);
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
