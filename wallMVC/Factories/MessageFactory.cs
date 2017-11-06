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
                string query = $"INSERT INTO messages (body, users_id, created_date, updated_date) VALUES (@body, {id}, NOW(), NOW())";
                dbConnection.Execute(query, message);
            }
        }
        public void LikePost(LikeModel comment, int id)
        {
            // Method uses established internal connection
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"INSERT INTO likes (users_id, messages_id, created_date, updated_date) VALUES ({id}, @message_id, NOW(), NOW())";
                dbConnection.Execute(query, comment);
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
                var all_messages = dbConnection.Query<MessageModel, User, MessageModel>(query, (messages, user) => {messages.user = user; return messages;});

                foreach (var message in all_messages) {
                    query = $"SELECT * FROM likes WHERE likes.messages_id = {message.id}";
                    var likes = dbConnection.Query<LikeModel>(query).ToList();
                    message.likes = likes;
                }
                return all_messages;
            }
        }
        public MessageModel GetMessage(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = $"SELECT * FROM messages " +
                               $"WHERE messages.id = {id}"; 
                var message = dbConnection.Query<MessageModel>(query).FirstOrDefault();

                query = $"SELECT * FROM likes JOIN users ON likes.users_id WHERE likes.messages_id = {id}";
                var likedBy = dbConnection.Query<LikeModel, User, LikeModel>(query, (likes, user) => {likes.user = user; return likes;}).ToList();
                likedBy.Distinct();

                message.likes = likedBy;

                return message;
            }
        }
        public Dictionary<string, int> UsersMessages(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                Dictionary<string, int> info = new Dictionary<string, int>();

                string query = $"SELECT * FROM messages WHERE messages.users_id = {id}";
                var messages = dbConnection.Query<MessageModel>(query).ToList();

                info.Add("messages", messages.Count);
                
                query = $"SELECT * FROM likes WHERE likes.users_id = {id}";
                var likes = dbConnection.Query<LikeModel>(query).ToList();
                
                info.Add("likes", likes.Count);
                
                return info;
            } 
        }
        public LikeModel CheckLikes(int message_id, int user_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"SELECT * FROM likes WHERE likes.messages_id = {message_id} AND likes.users_id = {user_id}";
                var message = dbConnection.Query<LikeModel>(query).FirstOrDefault();
                return message;
            }
        }

        //Get all users that liked this message
        //Check if user has liked this message if null check
    }
}