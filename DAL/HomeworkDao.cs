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
    public class HomeworkDao : AbstractDao, IHomeworkDao
    {
        public void New(Homework homework)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Create_Homework";

                cs.Open();

                System.Diagnostics.Debug.WriteLine(homework.name, homework.text);

                this.AddSqlParameters(command, new SqlParameter[]
                  {
                        new SqlParameter("@Id", homework.id),
                        new SqlParameter("@Name", homework.name),
                        new SqlParameter("@Text", homework.text)
                  });

                command.ExecuteNonQuery();
            }
        }
        public string Delete(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand command = cs.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteHomework";

                    command.Parameters.Add(new SqlParameter("@ID", id));

                    cs.Open();
                    command.ExecuteNonQuery();
                    return "Homework deleted successfully!";
                }
                catch (SqlException e)
                {
                    return e.ToString();
                }
            }
        }

        public IEnumerable<Homework> List()
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                var result = new List<Homework>();

                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllHomework";

                cs.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Homework()
                    {
                        id = (int)reader["Id"],
                        name = (string)reader["Name"],
                        text = (string)reader["Text"]
                    });
                }
                return result.ToList();
            }
        }

        public Homework Show(int id)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                SqlCommand command = cs.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetHomework";

                cs.Open();

                command.Parameters.Add(new SqlParameter("@ID", id));
                var reader = command.ExecuteReader();

                Homework result = new Homework();

                while (reader.Read())
                {
                    result = new Homework
                    {
                        name = (string)reader["Name"],
                        text = (string)reader["Text"],
                        id = (int)reader["Id"]
                    };
                }
                return result;
            }
        }
    

        public string Edit(int id, string name)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    cs.Open();
                    SqlCommand command = cs.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Update_Homework";

                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@Name", name)
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
        public string Edit(int id, string name, string text)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    cs.Open();
                    SqlCommand command = cs.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Update_Homework";

                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@ID", id),
                        new SqlParameter("@Name", name),
                        new SqlParameter("@Text", text)
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

        public string Edit_Create_Grade(int studetId, int homeworkId, int grade)
        {
            using (SqlConnection cs = new SqlConnection(_connectionString))
            {
                try
                {
                    cs.Open();
                    SqlCommand command = cs.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Assign_Homework";
                    this.AddSqlParameters(command, new SqlParameter[]
                    {
                        new SqlParameter("@S", studetId),
                        new SqlParameter("@H", homeworkId),
                        new SqlParameter("@G", grade)
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
    }
}
