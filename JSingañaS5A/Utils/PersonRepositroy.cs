using JSingañaS5A.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSingañaS5A.Utils
{
    public class PersonRepositroy
    {
        string dbPath;

        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();

        }

        public PersonRepositroy(string path) 
        {
            dbPath = path;
        }

        public void AddNewPerson(string name) 
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es un campo requerido");
                Persona person = new() { Name = name};
                result = conn.Insert(person);
                StatusMessage = string.Format("Dato insertado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error: " + ex.Message);
                
            }

        }

        public List<Persona> GetAllPeople() 
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error: " + ex.Message);
                
            }

            return new List<Persona>();
        }
    }
}
