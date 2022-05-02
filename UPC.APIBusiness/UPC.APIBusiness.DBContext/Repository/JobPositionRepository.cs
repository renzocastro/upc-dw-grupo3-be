using Microsoft.Extensions.Configuration;
using System;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace DBContext
{
    public class JobPositionRepository : BaseRepository, IJobPositionRepository
    {
        public ResponseBase createJobPosition(EntityJobPosition entity)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var param = new DynamicParameters();
                    param.Add(name: "@code", dbType: DbType.String, direction: ParameterDirection.Output);
                    param.Add(name: "@name", value: entity.No_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add(name: "@descripcion", value: entity.No_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add(name: "@user", value: entity.No_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);

                    const string sql = @"usp_Insertar_Funcion";
                    db.Query<EntityJobPosition>(
                        sql: sql,
                        param: param,
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();

                    string code = param.Get<string>("@code");

                    returnEntity.isSuccess = true;
                    returnEntity.errorCode = "0000";
                    returnEntity.errorMessage = string.Empty;
                    returnEntity.data = code;
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase deleteJobPosition(string code)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var param = new DynamicParameters();
                    param.Add(name: "@rowAffected", dbType: DbType.UInt16, direction: ParameterDirection.Output);
                    param.Add(name: "@code", value: code, dbType: DbType.String, direction: ParameterDirection.Input);

                    const string sql = @"usp_Borrar_Funcion";
                    db.Query<EntityJobPosition>(
                        sql: sql,
                        param: param,
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();

                    int rowAffected = param.Get<int>("@rowAffected");

                    returnEntity.isSuccess = true;
                    returnEntity.errorCode = "0000";
                    returnEntity.errorMessage = string.Empty;
                    returnEntity.data = (rowAffected == 1);
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase getJobPosition(string code)
        {
            var returnEntity = new ResponseBase();

            try
            {
                EntityJobPosition entity = null;

                using (var db = GetSqlConnection())
                {
                    var param = new DynamicParameters();
                    param.Add(name: "@code", value: code, dbType: DbType.String, direction: ParameterDirection.Input);

                    const string sql = @"usp_Obtener_Funcion";
                    entity = db.Query<EntityJobPosition>(
                        sql: sql,
                        param: param,
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();

                    returnEntity.isSuccess = true;
                    returnEntity.errorCode = "0000";
                    returnEntity.errorMessage = string.Empty;

                    if (entity != null)
                    {
                        returnEntity.data = entity;
                    }
                    else
                    {
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase getJobPositions()
        {
            var returnEntity = new ResponseBase();

            try
            {
                var entities = new List<EntityJobPosition>();

                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Funciones";
                    entities = db.Query<EntityJobPosition>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                    ).ToList();

                    returnEntity.isSuccess = true;
                    returnEntity.errorCode = "0000";
                    returnEntity.errorMessage = string.Empty;

                    if (entities.Count > 0)
                    {
                        returnEntity.data = entities;
                    }
                    else
                    {
                        returnEntity.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }

        public ResponseBase updateJobPosition(EntityJobPosition entity)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var param = new DynamicParameters();
                    param.Add(name: "@rowAffected", dbType: DbType.UInt16, direction: ParameterDirection.Output);
                    param.Add(name: "@code", value: entity.Co_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add(name: "@name", value: entity.No_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add(name: "@descripcion", value: entity.No_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add(name: "@user", value: entity.No_Funcion, dbType: DbType.String, direction: ParameterDirection.Input);

                    const string sql = @"usp_Actualizar_Funcion";
                    db.Query<EntityJobPosition>(
                        sql: sql,
                        param: param,
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();

                    int rowAffected = param.Get<int>("@rowAffected");

                    returnEntity.isSuccess = true;
                    returnEntity.errorCode = "0000";
                    returnEntity.errorMessage = string.Empty;
                    returnEntity.data = (rowAffected == 1);
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
    }
}
