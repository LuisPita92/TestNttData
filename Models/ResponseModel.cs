using System;
using System.Collections.Generic;

namespace ntt.data.test.luis.pita.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            root = new List<Object>();
        }

        public int ErrorId { get; set; }

        public string ErrorMensaje { get; set; }

        public List<Object> root { get; set; }
    }
}
