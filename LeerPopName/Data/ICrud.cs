using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LeerPopName.Data
{
    public interface ICrud<T> where T : class
    {
    
        void Add(T model);
        
        void Edit(T model);
        
        void Delete(T model);
        
        T Find(T model);
        ParallelQuery<T> ParallelQuery();
        
        List<T> All();
    }
}