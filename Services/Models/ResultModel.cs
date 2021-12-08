using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{ 
    public class ResultModel<T>
    {
        public ResultModel(T e)
        {
            result = true;
            message = "";
            value = e;
        }
        public ResultModel(Exception ex)
        {
            result = false;
            message = ex.Message;
        }

        public ResultModel()
        {
        }

        public string message { set; get; }
        public T value { set; get; }
        public bool result { set; get; }

    }
    public class ResultModel
    {

        public ResultModel(Exception ex)
        {
            result = false;
            message = ex.Message;
        }
        public ResultModel(bool r, string msg = "")
        {
            result = r;
            message = string.IsNullOrEmpty(msg) ? /*Tools.Language.Resource.DoneMsg*/ "done" : msg;
        }
        public ResultModel()
        {
        }

        public string message { set; get; }
        public bool result { set; get; }

    }
}
