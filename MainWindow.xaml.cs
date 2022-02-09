using System.Windows;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var setting = MongoClientSettings.FromConnectionString("mongodb+srv://mefostat:mefostat.234@cluster0.g4gtx.mongodb.net/Lesson401?retryWrites=true&w=majority");
            var client = new MongoClient(setting);
            var database = client.GetDatabase("Lesson401");
            var collection = database.GetCollection<BsonDocument>("student");
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                db.Text += ($"Запись:{document}\r\n");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var setting = MongoClientSettings.FromConnectionString("mongodb+srv://mefostat:mefostat.234@cluster0.g4gtx.mongodb.net/Lesson401?retryWrites=true&w=majority");
            var client = new MongoClient(setting);
            var database = client.GetDatabase("Lesson401");
            var collection = database.GetCollection<BsonDocument>("student");
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            var doc = new BsonDocument
            {
                {"First Name", FirstN.Text },
                {"Last Name", LastN.Text },
                {"Course Number", Group.Text },
                {"Direction", Specializ.Text }
            };
            collection.InsertOne(doc);
            b.Content = ("Запись добавленна");
            a.Content = ($"Всего записей:{collection.CountDocuments(new BsonDocument())}");
            foreach (var document in cursor.ToEnumerable())
            {
                db.Text += ($"{document}\n");
            }
        }

    }
};
