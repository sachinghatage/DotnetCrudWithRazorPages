using System.Data.SqlClient;
using System.Data;

namespace StudentApplication.Model
{
    public class DataAccessLayer
    {
        public List<Students> getStudents(IConfiguration configuration)
        {
            List<Students> listStudents = new List<Students>();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from student", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Students students = new Students();
                        students.Id = Convert.ToString(dataTable.Rows[i]["Id"]);
                        students.FirstName = Convert.ToString(dataTable.Rows[i]["FirstName"]);
                        students.LastName = Convert.ToString(dataTable.Rows[i]["LastName"]);
                        students.Email = Convert.ToString(dataTable.Rows[i]["Email"]);

                        listStudents.Add(students);
                    }
                }
            }

            return listStudents;
        }

        public int AddStudent(Students student, IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("insert into student values('" + student.FirstName + "','" + student.LastName + "','" + student.Email + "')", connection);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            return i;


        }

        public Students getStudent(string id, IConfiguration configuration)
        {
            Students student = new Students();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from student where id='" + id + "'", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {

                    {
                                                
                            student.Id = Convert.ToString(dataTable.Rows[0]["Id"]);
                            student.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                            student.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                            student.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                                                                 

                    }
                }
            }

            return student;
        }

        public int updateStudent(Students student, IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("update student set FirstName='" + student.FirstName + "',LastName='" + student.LastName + "',Email='" + student.Email + "' where id='" + student.Id + "'", connection);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            return i;


        }

        public int deleteStudent(string id, IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("delete from student where id='" + id + "'", connection);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            return i;

        }

        /*public Students GetStudent(string id, IConfiguration configuration)
        {
            Students student = new Students();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string query = "SELECT * FROM student WHERE Id = '"+id+"'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlParameter parameter = new SqlParameter(id, SqlDbType.NVarChar, 50);
                    parameter.Value = id;
                    command.Parameters.Add(parameter);

                    using (SqlDataReader reader = command.ExecuteReader(parameter))
                    {
                        if (reader.Read())
                        {
                            student.Id = Convert.ToString(reader["Id"]);
                            student.FirstName = Convert.ToString(reader["FirstName"]);
                            student.LastName = Convert.ToString(reader["LastName"]);
                            student.Email = Convert.ToString(reader["Email"]);

                            // Other property assignments...
                        }
                    }
                }
            }
            return student;
        }*/
        }


}
