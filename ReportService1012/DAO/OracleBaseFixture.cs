using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Dapper;

namespace ReportService1012.DAO
{
    public class OracleBaseFixture : IDisposable
    {
        private string connstr = string.Empty;
        private OracleConnection connection;
        protected IDatabase Db;
        public OracleBaseFixture()
        {
            this.connstr = ConfigurationManager.AppSettings["mes1012"]?.ToString();
            InitDB();
        }
        public OracleBaseFixture(string connstr)
        {
            this.connstr = ConfigurationManager.AppSettings[connstr]?.ToString();
            InitDB();
        }

        public void Dispose()
        {
            connection.Dispose();
            Db.Dispose();
        }

        private void InitDB()
        {
            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new OracleDialect());
            var sqlGenerator = new SqlGeneratorImpl(config);
            connection = new OracleConnection(this.connstr);
            Db = new Database(connection, sqlGenerator);
        }

        protected string OraPager(string sql)
        {
            StringBuilder tsql = new StringBuilder();
            tsql.Append(" SELECT * ");
            tsql.Append(" FROM   (SELECT ROWNUM RN, XX.*");
            tsql.Append("          FROM   ( ");
            tsql.Append(sql);
            tsql.Append("         ) XX");
            tsql.Append("          WHERE  ROWNUM <= :pagesize * :pageindex)");
            tsql.Append(" WHERE  RN > (:pageindex - 1) * :pagesize");
            return tsql.ToString();

        }
    }
}