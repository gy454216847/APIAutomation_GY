using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation_YG.Model
{
    
    
       

        /// <summary>
        /// Response model class for RegisterUser object
        /// </summary>
        public class RegisterUser
        {
            public int code { get; set; }
            public userDatas datas { get; set; }
            public string message { get; set; }
        }

        /// <summary>
        /// userDatas model class for the datas object within the RegisterUser Object
        /// </summary>
        public class userDatas
        {
            public string accountNumber { get; set; }
        }

        /// <summary>
        /// UnitTest class for creating unit tests for different types of requests and responses
        /// </summary
    
}
