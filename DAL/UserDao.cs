using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDao: AbstractDao, IUserDao
    {
       
        public void New(User user)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Create_User";

                var id = new SqlParameter("@Id", user.id);
                var email = new SqlParameter("@Email", user.email);
                var password = new SqlParameter("@Password", user.password);
                var name = new SqlParameter("@UserName", user.userName);
                var role = new SqlParameter("@UserRole", user.userRole);
                this.AddSqlParameters(command, new SqlParameter[] { email, password, name, role, id });

                cs.Open();
                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<User> List()
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                var result = new List<User>();

                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllUsers";

                cs.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new User()
                    {
                        email = (string)reader["Email"],
                        userRole = (int)reader["UserRole"],
                        id = (int)reader["Id"]
                    });
                }
                return result.ToList();
            }
        }

        public User Show(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUser";

                cs.Open();

                command.Parameters.Add(new SqlParameter("@ID", id));
                var reader = command.ExecuteReader();

                User result = new User();

                while (reader.Read())
                {
                    result = new User
                    {
                        email = (string)reader["Email"],
                        userName = (string)reader["UserName"],
                        password = (string)reader["User_password"],
                        userRole = (int)reader["UserRole"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        id = (int)reader["Id"]
                    };
                }
                return result;
            }
        }

        
        public User GetByEmail(string email)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserByEmail";

                System.Diagnostics.Debug.WriteLine(_connectionString);
                cs.Open();
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                var reader = command.ExecuteReader();

                User result = new User();

                while (reader.Read())
                {
                    result = new User
                    {
                        email = (string)reader["Email"],
                        password = (string)reader["User_password"],
                        userRole = (int)reader["UserRole"],
                        id = (int)reader["Id"]
                    };
                    if (reader["DateOfBirth"] != DBNull.Value) result.DateOfBirth = (DateTime)reader["DateOfBirth"]; 
                    if (reader["UserName"] != DBNull.Value) result.userName = (string)reader["UserName"];

                }

                return result;
            }
        }

        public string Login(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                   
                        cs.Open();
                    
                    
                    SqlCommand command = new SqlCommand("Login", cs);
                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@Id", id),
                        new SqlParameter("@bool", true)
                    });

                    var rowCount = command.ExecuteNonQuery();
                    return "Login!";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }

        public string Logout(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    cs.Open();
                    SqlCommand command = new SqlCommand("Logout", cs);
                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@Id", id),
                        new SqlParameter("@bool", false)
                    });

                    var rowCount = command.ExecuteNonQuery();
                    return "Logout!";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }
    }
}
