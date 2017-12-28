using Android.App;
using Android.OS;
using Android.Widget;
using NotiXamarin.Core.Services;
using NotiXamarin.Adapters;
using Android.Content;
using SQLite;
using NotiXamarin.Core.Models;
using System.Linq;
using NotiXamarin.Fragments;

namespace NotiXamarin
{
    [Activity(Label = "NotiXamarin", MainLauncher = true)]
    public class NewsListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsList);

            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.newsListFragmentContainer, new AllNewsListFragment());
            transaction.Commit();
        }
    }
}