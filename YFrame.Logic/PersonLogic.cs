using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YFrame.Data;
using YFrame.Logic.Base;
using YFrame.Model;

namespace YFrame.Logic
{
    public class PersonLogic : BaseLogic<PersonData>
    {
        public List<Person> GetAll()
        {
            return Data.GetAll();
        }

        public Person GetModel(string kwd)
        {
            return Data.GetFirst(p => p.Name.Contains(kwd));
        }

        public int AddModel(Person model)
        {
            return Data.Insert(model);
        }

        public bool UpdateModel(Person model)
        {
            return Data.Update(model) > 0;
        }

        public bool DelModel(int id)
        {
            return Data.Delete(p => p.Id == id) > 0;
        }

        public List<Person> Query()
        {
            int total = 0;
            return Data.Query(p => p.Id > 0, 1, 3, out total);
        }
    }
}

