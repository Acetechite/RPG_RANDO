using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using SQLite;
using System.IO;

namespace RPG_Rando
{
    [Activity(Label = "RPG_Rando", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //Load Ui content
        TextView testOutput;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Link UI element to ID
            testOutput = FindViewById<TextView>(Resource.Id.testOutputID);

            
            //Create type Person with constructor
            Person p1 = new Person
            {
                name = "Ryan",
                race = "Dwarf",
                age = 4
            };
            Person p2 = new Person
            {
                name = "Joseph",
                race = "Human",
                age = 24
            };
            Person p3 = new Person
            {
                name = "John",
                race = "Elf",
                age = 100
            };

            //Create a Village filled with people
            Village testVillage = new Village
            {
                government = "Monarchy",
                income = "Wealthy",
                people = new Person[]{ p1, p2, p3 }
            };

            //Convert the village object to a JSON string
            string json = JsonConvert.SerializeObject(testVillage, Formatting.Indented);

            //Convert a JSON string expected to be of type Village to a Village
            Village testVillage2 = JsonConvert.DeserializeObject<Village>(json);
            testOutput.Text = testVillage.people[1].name; //Access a variable of the JSON object

            //Create a database
            var databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DatabaseName.txt");
            //Connect to said database
            var db = new SQLiteConnection(databasePath);

            //Create a table based on this Model .cs file
            db.CreateTable<PersonTable>();

            //Add a new element to the file much like with regular constructor
            db.Insert(new PersonTable()
            {
                name = "Trevor"
            });
            db.Insert(new PersonTable()
            {
                name = "Johannson"
            });

            //Query that table for information
            var query = db.Table<PersonTable>().Where(v => v.name.StartsWith("J"));
            foreach (var person in query)
                testOutput.Append(person.name);
        }
    }
}

