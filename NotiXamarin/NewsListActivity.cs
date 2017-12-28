using Android.App;
using Android.OS;
using Android.Widget;
using NotiXamarin.Core.Services;
using NotiXamarin.Adapters;
using Android.Content;
using SQLite;
using NotiXamarin.Core.Models;
using System.Linq;

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
        private void TestDb()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string rutaDb = System.IO.Path.Combine(folder, "notiXamarinDb.db");

            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);

            // Crea la tabla si no existe
            db.CreateTable<News>();

            var news1 = new News
            {
                Id = 1,
                Title = "titulo 1",
                ImageName = "image name 1",
                Body = "body 1"
            };

            var news2 = new News
            {
                Id = 5,
                Title = "Creando apps multiplataforma con Xamarin",
                ImageName = "image name 2",
                Body = "body 2"
            };

            var news3 = new News
            {
                Id = 8,
                Title = "Usar Xamarin con c# o desarrollar con Java?",
                ImageName = "image name 3",
                Body = "body 3"
            };

            //// Inserta elementos en la tabla (uno a uno)
            //db.Insert(news1);
            //db.Insert(news2);
            //db.Insert(news3);

            //// Reemplaza el elemento si no existe
            //news1.Title = "nuevo titulo";
            //db.InsertOrReplace(news1);

            //// Si queremos insertar varios elementos a la vez
            ////db.InsertAll(new List<News>() { news1, news2, news3 });

            //// Obtener una noticia por su Id
            //var news1_fromDb = db.Get<News>(news1.Id);

            //// Obtener todas las noticias
            //var news_todas = db.Table<News>().ToList();

            //// Obtener un listado de noticias
            //var news_xmarin = db.Table<News>().Where(x => x.Title.Contains("Xamarin")).ToList();

            //var cantidadDeNoticias = db.Table<News>().Count();

            //// Borra el elemento de Id 1 de la tabla
            //db.Delete<News>(1);

            //// Borrar todos los elementos de la tabla
            //db.DeleteAll<News>();

            //// Borrar la tabla
            //db.DropTable<News>();
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