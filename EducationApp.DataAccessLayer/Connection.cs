using EducationApp.PresentationLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer
{
    public class Connection
    {
        private string _connectionString;

        public string ConnectionString => _connectionString;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
