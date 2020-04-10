using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P01_HelloCodeFirst
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Context : DbContext
    {
        public Context() : base("name=S03_connectionString")
        {

        }

        public DbSet<Person> People { get; set; }
    }
    

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();

                Console.WriteLine("Before:");
                Retrieve(context);
                Update(context);
                Console.WriteLine("After:");
                Retrieve(context);

            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void Update(Context context)
        {
            var person = context.People.FirstOrDefault();
            if (person != null)
            {
                person.FirstName = "Barrack";
                person.LastName = "Obama";
                context.SaveChanges();
            }
        }
        private static void Retrieve(Context context)
        {
            var people = context.People;
            foreach (var person in people)
            {
                Console.WriteLine($"[{person.PersonId}] {person.FirstName} {person.LastName}" + "    dddd");
            }
        }
    }
    
   
}
