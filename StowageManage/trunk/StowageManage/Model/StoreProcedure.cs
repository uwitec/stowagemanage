using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace StowageManage.Model
{

    /// <summary>
    /// 存储过程。
    /// </summary>
    public class StoreProcedure
    {
        // 连接字符串。
        private string connectionString;
        // 存储过程名称。
        private string storeProcedureName;

        ////// <summary>
        ///// 初始化 DataAccessHelper.StoreProceduer 对象。
        ///// </summary>
        ///// <param name="connectionString">数据库连接字符串。</param>

        //public StoreProcedure(string connectionString) {
        //    this.connectionString = connectionString;

        //}
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        //public static string connectionString =  ConfigurationSettings.AppSettings["ConnectionString"];

        //// <summary>
        /// 初始化 DataAccessHelper.StoreProceduer 对象。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串。</param>
        /// <param name="storeProcedureName">存储过程名称。</param>
        public StoreProcedure(string connectionString, string storeProcedureName) {
            //this.connectionString = connectionString;
            this.storeProcedureName = storeProcedureName;
        }

        //// <summary>
        /// 获取或设置存储过程名称。
        /// </summary>
        public string StoreProcedureName {
            get { return this.storeProcedureName; }
            set { this.storeProcedureName = value; }
        }

        //// <summary>
        /// 执行操作类（Insert/Delete/Update）存储过程。
        /// </summary>
        /// <param name="paraValues">传递给存储过程的参数值列表。</param>
        /// <returns>受影响的行数。</returns>
        public int ExecuteNonQuery(params object[] paraValues) {

            using (SqlConnection connection = new SqlConnection(this.connectionString)) {

                SqlCommand command = this.CreateSqlCommand(connection);

                try {
                    this.DeriveParameters(command);
                    this.AssignParameterValues(command, paraValues);
                    connection.Open();
                    int affectedRowsCount = command.ExecuteNonQuery();
                    return affectedRowsCount;
                } catch {
                    throw;
                }
            }
        }

        //// <summary>
        /// 执行存储过程，返回 System.Data.DataTable。
        /// </summary>
        /// <param name="paraValues">传递给存储过程的参数值列表。</param>
        /// <returns>包含查询结果的 System.Data.DataTable。</returns>
        public DataTable ExecuteDataTable(params object[] paraValues) {

            using (SqlConnection connection = new SqlConnection(this.connectionString)) {

                SqlCommand command = this.CreateSqlCommand(connection);

                try {
                    this.DeriveParameters(command);
                    this.AssignParameterValues(command, paraValues);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                } catch {
                    throw;
                }
            }
        }

        //// <summary>
        /// 执行存储过程，填充指定的 System.Data.DataTable。
        /// </summary>
        /// <param name="dataTable">用于填充查询结果的 System.Data.DataTable。</param>
        /// <param name="paraValues">传递给存储过程的参数值列表。</param>
        public void ExecuteFillDataTable(DataTable dataTable, params object[] paraValues) {

            using (SqlConnection connection = new SqlConnection(this.connectionString)) {

                SqlCommand command = this.CreateSqlCommand(connection);

                try {
                    this.DeriveParameters(command);
                    this.AssignParameterValues(command, paraValues);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                } catch {
                    throw;
                }
            }
        }
        
        //// <summary>
        /// 执行存储过程返回 System.Data.SqlClient.SqlDataReader，
        /// 在 System.Data.SqlClient.SqlDataReader 对象关闭时，数据库连接自动关闭。
        /// </summary>
        /// <param name="paraValues">传递给存储过程的参数值列表。</param>
        /// <returns>包含查询结果的 System.Data.SqlClient.SqlDataReader 对象。</returns>
        public SqlDataReader ExecuteDataReader(params object[] paraValues) {

            using (SqlConnection connection = new SqlConnection(this.connectionString)) {

                SqlCommand command = this.CreateSqlCommand(connection);

                try {
                    this.DeriveParameters(command);
                    this.AssignParameterValues(command, paraValues);
                    connection.Open();
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                } catch {
                    throw;
                }
            }
        }

        //// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="paraValues">传递给存储过程的参数值列表。</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object ExecuteScalar(params object[] paraValues) {

            using (SqlConnection connection = new SqlConnection(this.connectionString)) {

                SqlCommand command = this.CreateSqlCommand(connection);

                try {
                    this.DeriveParameters(command);
                    this.AssignParameterValues(command, paraValues);
                    connection.Open();
                    return command.ExecuteScalar();
                } catch {
                    throw;
                }
            }
        }

        //// <summary>
        /// 从在 System.Data.SqlClient.SqlCommand 中指定的存储过程中检索参数信息并填充指定的 
        /// System.Data.SqlClient.SqlCommand 对象的 System.Data.SqlClient.SqlCommand.Parameters 集  合。
        /// </summary>
        /// <param name="sqlCommand">将从其中导出参数信息的存储过程的 System.Data.SqlClient.SqlCommand 对象。</param>
        internal void DeriveParameters(SqlCommand sqlCommand) {
            try {
                sqlCommand.Connection.Open();
                SqlCommandBuilder.DeriveParameters(sqlCommand);
                sqlCommand.Connection.Close();
            } catch {
                if (sqlCommand.Connection != null) {
                    sqlCommand.Connection.Close();
                }
                throw;
            }
        }

        // 用指定的参数值列表为存储过程参数赋值。
        private void AssignParameterValues(SqlCommand sqlCommand, params object[] paraValues) {
            if (paraValues != null) {
                if ((sqlCommand.Parameters.Count - 1) != paraValues.Length) {
                    throw new ArgumentNullException("The number of parameters does not match number of values for stored procedure.");
                }
                for (int i = 0; i < paraValues.Length; i++) {
                    sqlCommand.Parameters[i + 1].Value = (paraValues[i] == null) ? DBNull.Value : paraValues[i];
                }
            }
        }

        // 创建用于执行存储过程的 SqlCommand。
        private SqlCommand CreateSqlCommand(SqlConnection connection) {

            SqlCommand command = new SqlCommand(this.storeProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
    }

    
}