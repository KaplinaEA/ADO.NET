using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDao : AbstractDao, IStudentDao
    {
        public string Edit(int id, DateTime birthday, string studentClass)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    cs.Open();

                    SqlCommand command = cs.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Update_Student_Profile";

                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@birsday", birthday),
                        new SqlParameter("@class", studentClass)
                    });

                    var rowCount = command.ExecuteNonQuery();
                    return "Student profile update successfully!";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }
        public IEnumerable<Journal> GetJournal(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                var result = new List<Journal>();

                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetJournalByStudent";

                cs.Open();

                command.Parameters.Add(new SqlParameter("@ID", id));
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Journal()
                    {
                        name = (string)reader["Name"],
                        text = (string)reader["Text"],
                        grade = (int)reader["grade"]
                    });
                }
                return result;
            }
        }

        public Student Show(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetStudent";

                cs.Open();

                command.Parameters.Add(new SqlParameter("@ID", id));
                var reader = command.ExecuteReader();

                Student result = new Student();

                while (reader.Read())
                {

                    result = new Student
                    {
                        email = (string)reader["Email"],
                        password = (string)reader["User_password"],
                        userRole = (int)reader["UserRole"],
                        id = (int)reader["Id"]
                    };
                    if (reader["DateOfBirth"] != DBNull.Value) result.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    if (reader["UserName"] != DBNull.Value) result.userName = (string)reader["UserName"];
                    if (reader["class"] != DBNull.Value) result.studentClass = (string)reader["class"];        
                }
                return result;
            }            
        }
    }
}
