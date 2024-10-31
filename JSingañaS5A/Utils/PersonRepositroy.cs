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

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    conn.Delete(person);
                    StatusMessage = "Persona eliminada correctamente.";
                }
                else
                {
                    StatusMessage = "Persona no encontrada.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error al eliminar: " + ex.Message;
            }
        }

        public Persona GetPersonById(int id)
        {
            try
            {
                Init();
                return conn.Find<Persona>(id);
            }
            catch (Exception ex)
            {
                StatusMessage = "Error al obtener persona: " + ex.Message;
                return null;
            }
        }

        public void UpdatePerson(int id, string newName)
        {
            try
            {
                Init();
                var person = conn.Find<Persona>(id);
                if (person != null)
                {
                    person.Name = newName;
                    conn.Update(person);
                    StatusMessage = "Persona actualizada correctamente.";
                }
                else
                {
                    StatusMessage = "Persona no encontrada.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error al actualizar: " + ex.Message;
            }
        }

    }
}
