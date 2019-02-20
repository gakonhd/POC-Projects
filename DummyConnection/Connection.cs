using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DummyConnection
{
    public class Connection
    {
        public Connection()
        {
            var cs = ConfigurationManager.ConnectionStrings["POSUSER"];
            ConnectionString = cs.ConnectionString;
            var providerFactory = DbProviderFactories.GetFactory(cs.ProviderName);
            this.DbProviderFactory = providerFactory;
        }

        public IDbConnection CreateConnection()
        {
            IDbConnection newConnection = _dbProviderFactory.CreateConnection();
            if (newConnection != null)
            {
                newConnection.ConnectionString = ConnectionString;
                return newConnection;
            }

            return null;
        }

        public IDbCommand GetSqlStringCommand(string query)
        {
            return CreateCommandByCommandType(CommandType.Text, query);
        }

        public virtual IDbCommand GetStoredProcCommand(string storedProcedureName)
        {
            IDbCommand command = CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName);
            return command;
        }

        public virtual IDataReader ExecuteReader(IDbCommand command, IDbTransaction transaction)
        {
            IDataReader reader = null;
            if (command.Connection == null)
                command.Connection = this.OpenConnection();

            try
            {
                if (command.Transaction == null)
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                else
                {
                    reader = command.ExecuteReader(CommandBehavior.Default);
                }
            }
            catch (Exception ex)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Command Text: " + command.CommandText + "\n");
                foreach (IDbDataParameter param in command.Parameters)
                {
                    message.Append("\nParameter: " + param.ParameterName + "=" + param.Value);
                }
                ex.Data.Add("Database Command", message.ToString());
                throw ex;
            }
            return reader;
        }

        public virtual object ExecuteScalar(IDbCommand command, IDbTransaction transaction)
        {
            object result = null;
            try
            {
                //if (command.Connection == null)
                //{
                //    using (IDbConnection connection = this.OpenConnection())
                //    {
                //        command.Connection = connection;
                //        result = command.ExecuteScalar();
                //    }
                //}
                //else
                //{
                //    result = command.ExecuteScalar();
                //}
                using (IDbConnection connection = this.OpenConnection())
                {
                    command.Connection = connection;
                    result = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Command Text: " + command.CommandText + "\n");
                foreach (IDbDataParameter param in command.Parameters)
                    message.Append("\nParameter: " + param.ParameterName + "=" + param.Value);
                ex.Data.Add("Database Command", message.ToString());
                throw ex;
            }
            return result;
        }

        public IDbConnection OpenConnection()
        {
            IDbConnection connection = null;
            try
            {
                connection = CreateConnection();
                connection.Open();
            }
            catch
            {
                if (connection != null)
                    connection.Close();
                throw;
            }
            return connection;
        }

        private IDbCommand CreateCommandByCommandType(CommandType commandType, string commandText)
        {
            IDbCommand command = this._dbProviderFactory.CreateCommand();
            if (command != null)
            {
                command.CommandType = commandType;
                command.CommandText = commandText;
                return command;
            }

            return null;
        }

        protected string ConnectionString = string.Empty;
        public DbProviderFactory DbProviderFactory
        {
            get => _dbProviderFactory;
            set => _dbProviderFactory = value;
        }
        private DbProviderFactory _dbProviderFactory;

    }
}
