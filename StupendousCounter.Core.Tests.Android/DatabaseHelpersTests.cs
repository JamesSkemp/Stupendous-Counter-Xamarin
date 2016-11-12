using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using System.IO;
using StupendousCounter.Core;
using System.Threading.Tasks;
using FluentAssertions;

namespace StupendousCounter.Core.Tests.Android
{
	[TestFixture]
	public class DatabaseHelpersTests
	{
		private static readonly string RootPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		[Test]
		public void InsertingACounterShouldSetItsIdAsync()
		{
			var dbfile = Path.Combine(RootPath, Guid.NewGuid().ToString("N") + ".db3");

			DatabaseHelper.CreateDatabase(dbfile);

			var db = new DatabaseHelper();
			var counter = new Counter
			{
				Name = "TestCounter",
				Description = "A test counter"
			};

			counter.Id.Should().Be(0);

			// Per tutorial, workaround for possible simulator bug.
			var res = Task.Run(async () =>
			{
				await db.AddOrUpdateCounterAsync(counter);
				return 0;
			}).Result;

			counter.Id.Should().Be(1);
		}
	}
}