using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerPopName.Data
{
    public class PopNameRepository : BaseRepository, ICrud<PopName>
    {
        IObjectContainer db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// 
        public PopNameRepository() {
            db = Db4oFactory.OpenFile(Path);
        }
        public PopNameRepository(bool res)
        {
            
        }
        public void Add(PopName person)
        {

            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(person);
                db.Commit();
                db.Close();
            }
        }

        public void AddParallel(PopName person)
        {
                db.Store(person);
        }

        public void AddCommit()
        {
                db.Commit();
                db.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PopName> All()
        {
            var lista = new List<PopName>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new PopName());
                while (result != null && result.HasNext()) lista.Add((PopName)result.Next());

                db.Close();
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(PopName model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new PopName { RowGuid = model.RowGuid });
                var proto = (PopName)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Edit(PopName model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new PopName { RowGuid = model.RowGuid });
                var proto = (PopName)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PopName Find(PopName model)
        {
            PopName proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (PopName)result[0];
                db.Close();
            }
            return proto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ParallelQuery<PopName> ParallelQuery()
        {
            var lista = new List<PopName>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new PopName());
                while (result != null && result.HasNext()) lista.Add((PopName)result.Next());
                db.Close();
            }
            return lista.AsParallel();
        }




    }
}
