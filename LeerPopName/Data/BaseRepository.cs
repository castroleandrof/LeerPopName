using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerPopName.Data
{
    public class BaseRepository
    {

        protected readonly string Path = @"D:\dbase\dbase.db4o";

        protected void ObjectMapper<T>(T model, T proto)
        {
            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                var property = proto.GetType().GetProperty(propertyInfo.Name);
                if (property != null)
                    property.SetValue(proto, propertyInfo.GetValue(model, null), null);
            }
        }

    }
}
