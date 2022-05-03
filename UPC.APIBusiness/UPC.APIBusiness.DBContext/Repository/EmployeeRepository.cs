using System;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;


namespace DBContext
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {

        public ResponseBase getEmployees()
        {
            var returnEntity = new ResponseBase();
            var entities = new List<EntityEmployee>();
            
            try
            {
                using (var db = GetSqlConnection())
                {
                    //const string sql = @"usp_ListarProyectos";
                    const string sql = @"grupo3.usp_Listar_Servicios";
                    entities = db.Query<EntityEmployee>(sql: sql,
                        commandType: CommandType.StoredProcedure).ToList();

                    if (entities.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entities;
                    }
                    else
                    {
                        returnEntity.isSuccess = true;
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

        public ResponseBase login(string email, string pw)
        {
            var returnEntity = new ResponseBase();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var p = new DynamicParameters();
                    p.Add(name: "@email", value: email, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@pw", value: pw, dbType: DbType.String, direction: ParameterDirection.Input);

                    const string sql = @"grupo3.usp_login";
                    var count = db.Query(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                    ).ToList().Count;

                    if (count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = true;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = false;
                    }
                }
            }
            catch (Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = false;
            }

            return returnEntity;
        }

    }
}
