using Learning.DTO;
using Learning.DAL;


namespace Student.BAL
{
    public class LearningBAL
    {
       LearningDTO objLearningDTO = new LearningDTO();
       LearningDAL objLearningDAL = new LearningDAL();
       
        public LearningDTO SelectLearning()
        {
            objLearningDTO = objLearningDAL.SelectLearning();
            return objLearningDTO;
        }
        public bool AddLearning(string lastname, string firstname, int age)
        {
            return objLearningDAL.AddLearning(lastname, firstname, age);
        }

        public bool DeleteLearning(int id) 
        {
            return  objLearningDAL.DeleteLearning(id);
        }

        public bool UpdateLearning(int id , string lastname, string firstname, int age)
        {
            return objLearningDAL.UpdateLearning(id, lastname, firstname, age); 
        }
    }
}
