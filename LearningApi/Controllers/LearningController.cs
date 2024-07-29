using Learning.DAL;
using Student.BAL;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LearningApi.Controllers
{
    public class LearningController : Controller
    {
        LearningBAL objLearningBAL = new LearningBAL();
        LearningDAL objLearningDAL = new LearningDAL();

        string Request = "";
        string Response = "";
        string Exception = "";

        JsonResult retobj = null;

        public JsonResult SelectLearning()
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                retobj = Json(objLearningBAL.SelectLearning(), JsonRequestBehavior.AllowGet);
                retobj.MaxJsonLength = int.MaxValue;
                Response = new JavaScriptSerializer().Serialize(retobj);
            }
            catch (Exception ex)
            {
                Exception = ex.ToString();
            }
            finally
            {
                
            }
            return retobj;
        }
        public JsonResult AddLearning(string lastname, string firstname, int age)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string resultMessage = "";
            int resultCode = (int)ErrorCode.ErrorType.ERROR;
            try
            {
                var result = objLearningBAL.AddLearning(lastname, firstname, age);
                resultMessage = result ? "Record added successfully" : "Failed to add record";
                resultCode = result ? (int)ErrorCode.ErrorType.SUCCESS : (int)ErrorCode.ErrorType.ERROR;
            }
            catch (Exception ex)
            {
                resultMessage = ex.ToString();
                Exception = ex.ToString();
            }
            finally
            {
                Response = new JavaScriptSerializer().Serialize(resultMessage);
            }

            return Json(new { Message = resultMessage, Code = resultCode });
        }



        public JsonResult DeleteLearning(int id)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string resultMessage = "";
            int resultCode = (int)ErrorCode.ErrorType.ERROR;
            try
            {
                var result = objLearningBAL.DeleteLearning(id);
                resultMessage = result ? "Record deleted successfully" : "Failed to delete record";
                resultCode = result ? (int)ErrorCode.ErrorType.SUCCESS : (int)ErrorCode.ErrorType.ERROR;
            }
            catch (Exception ex)
            {
                resultMessage = ex.ToString();
                Exception = ex.ToString();
               
            }
            finally
            {
                Response = new JavaScriptSerializer().Serialize(resultMessage);
            }

            return Json(new { Message = resultMessage, Code = resultCode });
        }

        public JsonResult UpdateLearning(int id, string lastname, string firstname, int age)
        {
            string ClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
            string MethodName = MethodBase.GetCurrentMethod().Name;
            string resultMessage = "";
            int resultCode = (int)ErrorCode.ErrorType.ERROR;
            try
            {
                var result = objLearningBAL.UpdateLearning(id, lastname, firstname, age);
                resultMessage = result ? "Record updated successfully" : "Failed to update record";
                resultCode = result ? (int)ErrorCode.ErrorType.SUCCESS : (int)ErrorCode.ErrorType.ERROR;
            }
            catch (Exception ex)
            {
                resultMessage = ex.ToString();
              
            }
            finally
            {
                Response = new JavaScriptSerializer().Serialize(resultMessage);
            }

            return Json(new { Message = resultMessage, Code = resultCode });
        }


    }
}