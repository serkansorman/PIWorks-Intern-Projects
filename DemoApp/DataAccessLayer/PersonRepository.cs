using DataAccessLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Windows;

namespace DataAccessLayer
{
    public class PersonRepository : IRepository<Person>
    {

       // private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Add(Person entity)
        {
            String query = "INSERT INTO people (lastname,firstname,email) VALUES (@lastname,@firstname,@email)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = "server=localhost;database=mydb;uid=srkn;password=1234;";
                    /*ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;*/
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstname", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", entity.LastName);
                    cmd.Parameters.AddWithValue("@email", entity.Email);
                    
                    cmd.ExecuteNonQuery();

                    //log.Info( entity.Email + " is added successfully");

                }
            }
            catch (MySqlException e)
            {
                // log.Error(e.Message);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {

            String query = "DELETE FROM people WHERE id=@id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = "server=localhost;database=mydb;uid=srkn;password=1234;";
                    /*ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;*/

                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                   // log.Info("ID: " + id + " is removed successfully");

                }
            }
            catch(MySqlException e)
            {
                // log.Error(e.Message);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

           
        }

        public void Edit(Person entity)
        {
            String query = "UPDATE people SET firstname = @firstname, lastname = @lastname, email = @email Where id = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = "server=localhost;database=mydb;uid=srkn;password=1234;";
                    /*ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;*/
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstname", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", entity.LastName);
                    cmd.Parameters.AddWithValue("@email", entity.Email);
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.ExecuteNonQuery();

                    //log.Info(entity.Email + " is updated successfully");
                    
                }
            }
            catch(MySqlException e)
            {
                //log.Error(e.Message);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            
        }

        public Person GetById(int id)
        {
            
            String query = "SELECT * FROM people WHERE id=@id";


            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = "server=localhost;database=mydb;uid=srkn;password=1234;";
                /*ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;*/
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id",id);
                MySqlDataReader reader = cmd.ExecuteReader();
                Person person = null;
                try
                {

                    if (reader.Read())
                    {
                        person = new Person
                        {
                            Id = (int)reader["id"],
                            LastName = reader["lastname"].ToString(),
                            FirstName = reader["firstname"].ToString(),
                            Email = reader["email"].ToString()
                        };

                       // log.Info(person.Email + " taken successfully");
                    }


                    reader.Close();


                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                     + e.ErrorCode + " - " + e.Message;

                    // log.Error(MessageString);
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    reader.Close();
                    conn.Close();

                }

                return person;

            }
        }

            public IEnumerable<Person> List()
        {
            var model = new List<Person>();
            String query = "SELECT * FROM people";


            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = "server=localhost;database=mydb;uid=srkn;password=1234;";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {

                    while (reader.Read())
                    {

                        model.Add(new Person
                        {
                            Id = (int)reader["id"],
                            LastName = reader["lastname"].ToString(),
                            FirstName = reader["firstname"].ToString(),
                            Email = reader["email"].ToString()
                        });
                    }


                    reader.Close();


                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                     + e.ErrorCode + " - " + e.Message;

                    //log.Error(MessageString);
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    reader.Close();
                    conn.Close();

                }
                return model;

            }
        }
    }
}