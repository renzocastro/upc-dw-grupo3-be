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
        //public ResponseBase getProject(int id)
        //public EntityService getService(int id)
        //{
        //    //throw new NotImplementedException();
        //    var service = new EntityService();

        //    try
        //    {
                
        //        using (var db = GetSqlConnection())
        //        {
        //            //const string sql = "usp_ObtenerProyecto";

        //            //var p = new DynamicParameters();
        //            //p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //            //service = db.Query<EntityProject>(
        //            //    sql: sql,
        //            //    param: p,
        //            //    commandType: CommandType.StoredProcedure
        //            //).FirstOrDefault();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return service;
        //}

        public ResponseBase getServices()
        {
            var returnEntity = new ResponseBase();
            var entitiesServices = new List<EntityService>();
            
            try
            {
                using (var db = GetSqlConnection())
                {
                    //const string sql = @"usp_ListarProyectos";
                    const string sql = @"grupo3.usp_Listar_Servicios";
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

        //public EntityProject getServices(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<EntityProject> GetServices()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<EntityProject> GetProjects()
        //{
        //    //throw new NotImplementedException();

        //    var projects = new List<EntityProject>();

        //    try
        //    {
        //        using (var db = GetSqlConnection())
        //        {
        //            const string sql = "usp_ListarProyectos";
        //            projects = db.Query<EntityProject>(
        //                sql: sql,
        //                commandType: CommandType.StoredProcedure
        //            ).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return projects;
        //}
    }
}
