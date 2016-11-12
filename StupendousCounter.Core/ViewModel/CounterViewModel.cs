using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupendousCounter.Core.ViewModel
{
	public class CounterViewModel : ViewModelBase
	{
		private readonly Counter _counter;
		private readonly IDatabaseHelper _databaseHelper;

		public CounterViewModel(Counter counter, IDatabaseHelper databaseHelper)
		{
			_counter = counter;
			_databaseHelper = databaseHelper;
		}

		public string Name => _counter.Name;
		public string Description => _counter.Description;
		public string Value => _counter.Value.ToString("N0");

		private RelayCommand _incrementCommand;
		public RelayCommand IncrementCommand => _incrementCommand ?? (_incrementCommand = new RelayCommand(async () => await IncrementAsync()));

		private async Task IncrementAsync()
		{
			await _databaseHelper.IncrementCounterAsync(_counter);
			RaisePropertyChanged(() => Value);
		}
	}
}
