using Android.App;
using Android.OS;
using Android.Widget;
using NotiXamarin.Core.Services;
using NotiXamarin.Adapters;
using Android.Content;

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

            var newsListView = FindViewById<ListView>(Resource.Id.newsListView);

            var newsService = new NewsService();
            var news = newsService.GetNews();
            newsListView.Adapter = new NewsListAdapter(this, news);

            newsListView.ItemClick += NewsListView_ItemClick;
        }

        private void NewsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            var id = (int)e.Id;
            intent.PutExtra(MainActivity.KEY_ID, id);
            StartActivity(intent);
        }
    }
}