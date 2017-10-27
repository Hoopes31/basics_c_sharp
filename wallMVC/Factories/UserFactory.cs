using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using scaffold.Models;
using DbConnection;

namespace scaffold.Factory
{
    public class UserFactory
    {
        //Add secure connection capability
        private readonly DbConnector _dbConnector;
 
        public UserFactory(DbConnector connect)
        {
            _dbConnector = connect;
        }
        //Now add methods --->
        public void AddNewUser(User user) // Expects User object from the AddNewUser call in the controller
        {

        }
    }
}