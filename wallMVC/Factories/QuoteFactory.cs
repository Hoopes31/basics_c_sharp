using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Linq;
using Dapper;
using scaffold.Models;

namespace DbConnection
{
    public class QuoteFactory
    {
        //MySqlOptions was added to IOptions in services.Configure?
        //Did the Options keyword determine this or does services.Configure only related
        //to IOptions
        private readonly IOptions<MySqlOptions> MySqlConfig;
        public QuoteFactory(IOptions<MySqlOptions> config)
        {
            //Figure out what is happening here
            //confusing as it looks like IOptions = IOptions
            //Are we establishing IOptions from services should be the 
            //IOptions used here?
            //If so why would I have to override IOptions?
            //What happens with default IOptions
            MySqlConfig = config;
        }
    }
}