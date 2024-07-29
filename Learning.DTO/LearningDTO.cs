using System;
using System.Collections.Generic;


namespace Learning.DTO
{
    public class LearningDTO
    {
        public string Message { get; set; }
        public int Code { get; set; }

       

        public class LearningDetailEntity
        {
            public string id { get; set; }
            public string lastname { get; set; }
            public string firstname { get; set; }
            public string age { get; set; }



        }

        public List<LearningDTO.LearningDetailEntity> LearningList { get; set; }
      
    }
}
