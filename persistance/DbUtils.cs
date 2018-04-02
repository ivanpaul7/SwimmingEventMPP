using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace persistance {
    class DBUtils {
        private static IDbConnection instance = null;
        public static IDbConnection getConnection() {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed) {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection() {
            String connectionString = "Database=db_mpp_lab1;" +
                                        "Data Source=localhost;" +
                                        "User id=root;" +
                                        "Password=Hero;";
            return new MySqlConnection(connectionString);
        }
    }
}
