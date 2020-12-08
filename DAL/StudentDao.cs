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
        public Journal GetJournal(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetJournalByStudent";

                cs.Open();

                command.Parameters.Add(new SqlParameter("@ID", id));
                var reader = command.ExecuteReader();

                var result = new Journal();

                while (reader.Read())
                {
                    result = new Journal
                    (
                        (string)reader["Name"],
                        (string)reader["Text"],
                        (int)reader["grade"]
                    );
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
                    result = new Student { 
                        email = (string)reader["Email"],
                        userName = (string)reader["UserName"],
                        password = (string)reader["User_password"],
                        userRole = (int)reader["UserRole"],
                        studentClass = (string)reader["class"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        id = (int)reader["Id"]
                    };                    
                }
                return result;
            }            
        }
    }
}
