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

        

    }
}
