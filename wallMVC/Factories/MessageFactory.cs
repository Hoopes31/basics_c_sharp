using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Linq;
using Dapper;
using scaffold.Models;

namespace DbConnection
{
    public class MessageFactory
    {
        //MySqlOptions was added to IOptions in services.Configure?
        //Did the Options keyword determine this or does services.Configure only related
        //to IOptions
        private readonly IOptions<MySqlOptions> MySqlConfig;
        public MessageFactory(IOptions<MySqlOptions> config)
        {
            //Figure out what is happening here
            //confusing as it looks like IOptions = IOptions
            //Are we establishing IOptions from services should be the 
            //IOptions used here?
            //If so why would I have to override IOptions?
            //What happens with default IOptions
            //Appears to overwrite normal IOptions for this Object Instance
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                // Create the IDbConnection for this instances use
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        //Run Methods
        public void AddNewMessage(MessageModel message, int id)
        {
            // Method uses established internal connection
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string queryMessage = $"INSERT INTO messages (body, users_id, created_date, updated_date) VALUES (@body, {id}, NOW(), NOW())";
                dbConnection.Execute(queryMessage, message);
                System.Console.WriteLine("Message Added!");
            }
        }
        public IEnumerable<MessageModel> GetAllMessages()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM messages " + 
                               "JOIN users ON messages.users_id " + 
                               "WHERE users.id = messages.users_id";
                dbConnection.Open();
                var data = dbConnection.Query<MessageModel, User, MessageModel>(query, (messages, user) => {messages.user = user; return messages;});
                return data;
            }
        }
    }
}