using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace StupendousCounter.Droid.Fragments
{
	public class CountersFragment : Fragment
	{
		private RecyclerView _recyclerView;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public static CountersFragment NewInstance()
		{
			var frag1 = new CountersFragment { Arguments = new Bundle() };
			return frag1;
		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);
			return inflater.Inflate(Resource.Layout.counters_fragment, null);
		}
	}
}