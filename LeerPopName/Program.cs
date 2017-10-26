using LeerPopName.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace LeerPopName
{
    enum NameGender { Male, Female }
    class Program
    {
        static void Main(string[] args)
        {
            LoadNames();
        }

        static void LoadNames()
        {
            //const int recordSize = 32; // aprox. 32 bytes por registro.
            //var count = (int)((mbSize * 1024 * 1024) / recordSize);
            int i = 0, idx = 0, a=0;
            var path = @"D:\dbase\popnames.xml";
            PopNameRepository db = new PopNameRepository();
            try
            {
                Console.Write("Cargando nombres desde archivo XML ...");
                var doc = XDocument.Load(path);
                var root = doc.Root;
                if (root != null)
                    foreach (var child in root.Elements())
                    {
                        if (i == 10000)
                        {
                            db.AddCommit();
                            a += i;
                            Console.WriteLine("Se guardaron {0} nombres", a);
                            db = new PopNameRepository();
                            i = 0;
                        }
                        var name = new PopName
                        {
                            RowGuid = idx,
                            Name = child.Attribute("Name").Value,
                            Gender = (NameGender)Enum.Parse(typeof(NameGender), child.Attribute("Gender").Value),
                            State = child.Attribute("State").Value,
                            Year = int.Parse(child.Attribute("Year").Value),
                            Rank = int.Parse(child.Attribute("Rank").Value),
                            Count = int.Parse(child.Attribute("Count").Value)
                        };
                        db.AddParallel(name);
                        i++;
                        idx++;
                    }
               

               
            }
            finally
            {
            }
        }
    }
}
