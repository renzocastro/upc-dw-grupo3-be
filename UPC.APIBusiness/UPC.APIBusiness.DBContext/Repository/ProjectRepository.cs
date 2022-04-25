using System;
using DBEntity;
using Dapper;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace DBContext
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        //public ResponseBase getProject(int id)
        public EntityProject getProject(int id)
        {
            //throw new NotImplementedException();
            var project = new EntityProject();

            try
            {
                
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ObtenerProyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    project = db.Query<EntityProject>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return project;
        }

        public ResponseBase getProjects()
        {
            var returnEntity = new ResponseBase();
            var entitiesProjects = new List<EntityProject>();
            var imagesRepository = new ImageRepository();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarProyectos";
                    entitiesProjects = db.Query<EntityProject>(sql: sql,
                        commandType: CommandType.StoredProcedure).ToList();

                    foreach(var obj in entitiesProjects)
                    {
                        obj.images = imagesRepository.getImages(obj.idProyecto);
                    }

                    if(entitiesProjects.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesProjects;
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

        public List<EntityProject> GetProjects()
        {
            //throw new NotImplementedException();

            var projects = new List<EntityProject>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_ListarProyectos";
                    projects = db.Query<EntityProject>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return projects;
        }
    }
}
