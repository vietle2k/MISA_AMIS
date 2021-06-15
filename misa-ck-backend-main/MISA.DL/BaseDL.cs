using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using MISA.DL.Interfaces;

namespace MISA.DL
{
    public class BaseDL:IBaseDL
    {
        protected string _connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database= 15B_MS243_CukCuk_LXVIET;" +
            "User Id = dev;" +
            "Password= 12345678";
        protected IDbConnection _dbConnection;


        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var sqlCommand = $"Proc_Get{tableName}s";
                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }

        public MISAEntity GetById<MISAEntity>(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var storeName = $"Proc_Get{tableName}ById";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(storeName, param: dynamicParameters , commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public int Insert<MISAEntity>(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                var tableName = typeof(MISAEntity).Name;
                var storeName = $"Proc_Insert{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Update<MISAEntity>(MISAEntity entity, Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                //
                //var entityIdPropertyName = $"{tableName}Id";
                //var entityIdProperty = typeof(MISAEntity).GetProperty(entityIdPropertyName);
                //if (entityIdProperty != null) typeof(MISAEntity).GetProperty(entityIdPropertyName).SetValue(entity, entityId);
                //

                var tableName = typeof(MISAEntity).Name;
                var storeName = $"Proc_Update{tableName}";
                var rowsAffect = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Delete<MISAEntity>(Guid entityId)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {

                var tableName = typeof(MISAEntity).Name;
                //var sqlCommand = $"DELETE FROM {tableName} WHERE {tableName}Id = '{entityId.ToString()}'";
                //var rowsAffect = _dbConnection.Execute(sqlCommand);
                var storeName = $"Proc_Delete{tableName}";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@m_{tableName}Id", entityId);
                var rowsAffect = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
    }
}
