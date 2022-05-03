using System;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace DBContext
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ResponseBase getServices()
        {
            var returnEntity = new ResponseBase();
            var entitiesServices = new List<EntityService>();
            
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Servicios";
                    entitiesServices = db.Query<EntityService>(sql: sql,
                        commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesServices.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesServices;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
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
