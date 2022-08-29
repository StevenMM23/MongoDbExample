using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDbExample.Models;

namespace MongoDbExample
{
    internal class Program
    {
        public static readonly MongoClient Client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase Database = Client.GetDatabase("school");
        public static IMongoCollection<People> PeopleDb = Database.GetCollection<People>("people");
        public static int Id { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Elija una opcion: ");
            Console.WriteLine("1 - Insertar");
            Console.WriteLine("2 - Mostrar");
            Console.WriteLine("1 - Actualizar");

            var decision = Convert.ToInt32(Console.ReadLine());


            switch (decision)
            {
                case 1:
                    Console.WriteLine("Insertar el Nombre");
                    var nombre = Console.ReadLine();
                    Console.WriteLine("Insertar la Edad");
                    var edad = Convert.ToInt32(Console.ReadLine());


                    var people = new People()
                    {
                        Nombre = nombre,
                        Edad = edad
                    };

                    Insert(people);
                    break;
                case 2:
                    ShowAll();
                    break;
                case 3: 
                    break;
                default:
                    Console.WriteLine("Elija una opcion valida");
                    Console.ReadKey();
                    break;
            }
            
        }
        public static void Insert(People people)
        {
            PeopleDb.InsertOne(people);

        }

        public static void ShowAll()
        {
           var listPeople =  PeopleDb.Find(d => true).ToList();
           foreach (var people in listPeople)
           {
               Console.WriteLine($"Nombre: {people.Nombre}\nEdad: {people.Edad} ");
           }

           Console.ReadKey();
           Console.Clear();
        }
    }
}

    
