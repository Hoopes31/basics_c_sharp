// using System.Collections.Generic;
// using System.Data;
// using Microsoft.Extensions.Options;
// using MySql.Data.MySqlClient;
// using System.Linq;
// using Dapper;
// using scaffold.Models;

// namespace DbConnection
// {
//     public class DbConnector
//     {
//         private readonly IOptions<MySqlOptions> MySqlConfig;
 
//         public DbConnector(IOptions<MySqlOptions> config)
//         {
//             MySqlConfig = config;
//         }
//         internal IDbConnection Connection {
//             get {
//                 return new MySqlConnection(MySqlConfig.Value.ConnectionString);
//             }
//         }
        
//         //This method runs a query and stores the response in a list of dictionary records
//         public void AddNewUser(User user)
//         {
//             using(IDbConnection dbConnection = Connection)
//             {
//                 string query = "INSERT INTO users(first_name, last_name, email, password, created_date, updated_date)" +
//                                "VALUES (@firstName, @lastName, @email, @password, NOW(), NOW()";
//                 dbConnection.Open();
//                 dbConnection.Execute(query);
//             }
//         }
//         public User FindById(int id)
//         {
//             using (IDbConnection dbConnection = Connection)
//             {
//                 string query = $"SELECT * FROM users WHERE id = {id}";
//                 dbConnection.Open();
//                 return dbConnection.Query<User>(query).FirstOrDefault();
//             }
//         }
//         public IEnumerable<User> GetAllUsers()
//         {
//             using (IDbConnection dbConnection = Connection)
//             {
//                 string query = "SELECT * from users";
//                 dbConnection.Open();
//                 return dbConnection.Query<User>(query);
//             }
//         }

//     }
// }