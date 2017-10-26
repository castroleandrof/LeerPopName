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
            var path = @"D:\dbase\popnames.xml";
            var db = new PopNameRepository();
            try
            {
              
                Console.Write("Cargando nombres desde archivo XML ...");
                var doc = XDocument.Load(path);
                var root = doc.Root;
                if (root != null)
                    foreach (var child in root.Elements())
                    {
                        var name = new PopName
                        {
                            Name = child.Attribute("Name").Value,
                            Gender = (NameGender)Enum.Parse(typeof(NameGender), child.Attribute("Gender").Value),
                            State = child.Attribute("State").Value,
                            Year = int.Parse(child.Attribute("Year").Value),
                            Rank = int.Parse(child.Attribute("Rank").Value),
                            Count = int.Parse(child.Attribute("Count").Value)
                        };
                        db.Add(name);
                    }
               

               
            }
            finally
            {
            }
        }
    }
}
