using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLXeMay.dto;
namespace QLXeMay
{
    internal class UsersRepository
    {
        private SqlCommand command;
        private SqlDataReader dataReader;

        public UsersRepository() { }

        public List<Users> users(string query)
        {
            List<Users> users = new List<Users>();

            using (SqlConnection sqlConnection = DatabaseUtils.connection())
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    users.Add(new Users(dataReader.GetInt32(0),dataReader.GetString(1), dataReader.GetString(2)));
                }

                sqlConnection.Close();  
            }
                return users;
        }

        public void save(UserRegister user)
        {
            string query = "INSERT INTO users (username, passwrd, phoneNumber, email, id_nv) VALUES (@username, @passwrd, @phoneNumber, @email, @id_nv)";

            using (SqlConnection sqlConnection = DatabaseUtils.connection())
            {
                sqlConnection.Open();
                command = new SqlCommand(query, sqlConnection);

                // Thêm các tham số
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@passwrd", user.Password);
                command.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber); // Kiểm tra null
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@id_nv", user.IdNv); // Kiểm tra null

                // Thực thi câu lệnh
                command.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
