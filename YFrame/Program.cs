using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YFrame.Logic;
using YFrame.Logic.Base;
using YFrame.Model;
using YFrame.Tools.Common;
using YFrame.Tools.Excel;

namespace YFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic = UnitySetup.Instance.Resolve<PersonLogic>();
            //for (int i = 0; i < 6; i++)
            //{
            //    var model = new Person
            //    {
            //        Name = "test" + i,
            //        Age = 11 + i,
            //        Sex = "男",
            //        Datetime = DateTime.Now
            //    };
            //    var result = logic.AddModel(model);
            //}

            var result = logic.GetAll();
            //Console.WriteLine(JsonConvert.SerializeObject(result));
            //var dt = result.ToDataTable(true);
            //ExcelNpoiHelper.Export(dt, "E:/execl", DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls");

            Console.ReadKey();
        }
    }
}
