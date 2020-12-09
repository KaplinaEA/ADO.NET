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
    public class TeacherDao : AbstractDao, ITeacherDao
    {
        public string Edit(int id, DateTime birthday, int experience)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    cs.Open();
                    SqlCommand command = cs.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Update_Teacher_Profile";

                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@birsday", birthday),
                        new SqlParameter("@experience", experience)
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
        public Teacher Show(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                cs.Open();
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetTheacher";

                command.Parameters.Add(new SqlParameter("@ID", id));
                var reader = command.ExecuteReader();

                Teacher result = new Teacher();

                while (reader.Read())
                {
                    result = new Teacher
                    {
                        email = (string)reader["Email"],
                        userName = (string)reader["UserName"],
                        password = (string)reader["User_password"],
                        userRole = (int)reader["UserRole"],
                        experience = (int)reader["experience"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        id = (int)reader["Id"]
                    };
                }
                return result;
            }
        }
    }
}
