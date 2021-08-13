using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PeopleModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchuEntryFile = "MatchuEntryModels.csv";
        public static IDataConnection Connection { get; private set; } 

        public static void InitializeConnections(DataBaseType db)
        {
            if(db == DataBaseType.Sql)
            {
                // TODO - SQL Connection -> set it up correctly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DataBaseType.TextFile)
            {
                // TODO - Create Text Connection
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
