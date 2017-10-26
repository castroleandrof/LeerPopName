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
        private static ParallelQuery<PopName> _parQuery;

        static void Main(string[] args)
        {
            //LoadNames();
            PopNameRepository db = new PopNameRepository(false);
            var lista = db.All().Where(o => o.Name.Equals("Robert", StringComparison.InvariantCultureIgnoreCase) && o.State == "WA" && o.Year >= 1960 && o.Year <= 2016);
            Console.WriteLine("Se encontraron {0} registros", lista.Count());
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

        //    private void InitializeQuery() {
        //    _parQuery = from n in _names.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount)
        //                where n.Name.Equals(queryInfo.Name, StringComparison.InvariantCultureIgnoreCase) &&
        //                      n.State == queryInfo.State &&
        //                      n.Year >= YearStart && n.Year <= YearEnd
        //                orderby n.Year
        //                select n;
        //}


        }
    }
}
