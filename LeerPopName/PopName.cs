using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerPopName
{
    public class PopName
    {
        // Fields:
        private string m_name;
        private NameGender m_gender;
        private string m_state;
        private int m_year;
        private int m_rank;
        private int m_count;

        // Properties:
        public string RowGuid { get; set; }
        internal string Name { get { return m_name; } set { m_name = value; } }
        internal NameGender Gender { get { return m_gender; } set { m_gender = value; } }
        internal string State { get { return m_state; } set { m_state = value; } }
        internal int Year { get { return m_year; } set { m_year = value; } }
        internal int Rank { get { return m_rank; } set { m_rank = value; } }
        internal int Count { get { return m_count; } set { m_count = value; } }

        public override string ToString()
        {
            return string.Format("{{ Name={0}, Gender={1}, State={2}, Year={3}, Rank={4}, Count={5} }}",
                Name, Gender, State, Year, Rank, Count);
        }

       
    }
}
