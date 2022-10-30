using System;

using System.Data;
using System.Data.SqlClient;


namespace FundamentosSharp
{
    internal class Db : InterfaceName
    {
        private string stringConnection = "Data Source=localhost;Initial Catalog=dbperson;Integrated Security=True";

        public List<Person> getPersons()
        {
            List<Person> personList = new List<Person>();

            string query = "select id, name from person";

            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    personList.Add(new Person(reader.GetInt32(0), reader.GetString(1)));
                }
                connection.Close();
            }
            return personList;
        }
        public void addPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(null, connection);

                sqlCommand.CommandText = "Insert into person (name) values (@personName)";
                SqlParameter nameParameter = new SqlParameter("@personName", SqlDbType.VarChar, 30);

                nameParameter.Value = person.name;

                sqlCommand.Parameters.Add(nameParameter);
                sqlCommand.Prepare();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void deletePersonByName(string name)
        {
            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(null, connection);

                sqlCommand.CommandText = "delete from person where name = @name";
                SqlParameter nameParameter = new SqlParameter("@name", SqlDbType.VarChar, 30);

                nameParameter.Value = name;

                sqlCommand.Parameters.Add(nameParameter);

                sqlCommand.Prepare();
                sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
