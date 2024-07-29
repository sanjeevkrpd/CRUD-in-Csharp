using Learning.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;


namespace Learning.DAL
{
    public class LearningDAL : DALBASE
    {
        LearningDTO objLearningDTO = new LearningDTO();

        public LearningDTO SelectLearning()
        {
            objLearningDTO.LearningList = new List<LearningDTO.LearningDetailEntity>();
            using (command = db.GetStoredProcCommand("SP_GetallStudent"))
            {
                db.AddInParameter(command, "@Action", DbType.String, "select");


            }
            try
            {
                string Retval = "";
                IDataReader reader = db.ExecuteReader(command);
                if (reader == null)
                {
                    objLearningDTO.Message = "Unsuccessfull";
                    objLearningDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                }
                else
                {
                    while (reader.Read())
                    {
                        Retval = reader["Retval"].ToString();

                        if (Retval == "SUCCESS")
                        {
                            objLearningDTO.LearningList.Add(new LearningDTO.LearningDetailEntity
                            {
                                id = reader["id"].ToString(),
                                lastname = reader["lastname"].ToString(),
                                firstname = reader["firstname"].ToString(),
                                age = reader["age"].ToString()

                            });
                            objLearningDTO.Message = "SUCCESS";
                            objLearningDTO.Code = (int)ErrorCode.ErrorType.SUCCESS;
                        }
                        else
                        {
                            objLearningDTO.Message = "No Records Found";
                            objLearningDTO.Code = (int)ErrorCode.ErrorType.DATANOTFOUND;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLearningDTO.Message = "Unsuccessful";
                objLearningDTO.Code = (int)ErrorCode.ErrorType.ERROR;
                ErrorLog("GetLearning", "LearningDAL", ex.ToString());
            }
            return objLearningDTO;
        }

        public bool AddLearning(string lastname, string firstname, int age)
        {
            bool isSuccess = false;
            using (DbCommand command = db.GetStoredProcCommand("SP_AddLearning"))
            {
                db.AddInParameter(command, "@lastname", DbType.String, lastname);
                db.AddInParameter(command, "@firstname", DbType.String, firstname);
                db.AddInParameter(command, "@age", DbType.Int32, age);

                try
                {
                    // Execute the command and check for success
                    int result = db.ExecuteNonQuery(command);
                    isSuccess = result > 0; // Assuming a successful insert affects one or more rows
                }
                catch
                {
                    isSuccess = false;
                }
            }

            return isSuccess;
        }
        public bool DeleteLearning(int id)
        {
            bool isSuccess = false;
            using (DbCommand cmd = db.GetStoredProcCommand("SP_DeleteLearning"))
            {
                db.AddInParameter(cmd, "@id", DbType.Int32, id);

                try
                {
                    int result = db.ExecuteNonQuery(cmd);
                    isSuccess = result > 0;
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    ErrorLog("DeleteLearning", "LearningDAL", ex.ToString());
                }
            }

            return isSuccess;
        }

        public bool UpdateLearning(int id, string lastname, string firstname, int age)
        {
            bool isSuccess = false;
            using (DbCommand cmd = db.GetStoredProcCommand("SP_UpdateLearning"))
            {
                db.AddInParameter(cmd, "@id", DbType.Int32, id);
                db.AddInParameter(cmd, "@lastname", DbType.String, lastname);
                db.AddInParameter(cmd, "@firstname", DbType.String, firstname);
                db.AddInParameter(cmd, "@age", DbType.Int32, age);


                try
                {
                    int result = db.ExecuteNonQuery(cmd);
                    isSuccess = result > 0;
                }
                catch (Exception ex)
                {
                    {
                        isSuccess = false;
                        ErrorLog("UpdateLearning", "LearningDAL", ex.ToString());

                    }
                }
                return isSuccess;
            }
        }
    }
}