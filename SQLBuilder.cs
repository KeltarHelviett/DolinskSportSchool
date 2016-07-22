using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolinskSportSchool
{
    static class SQLBuilder
    {
       static public string BuildSelectPart(int tag)
        {
            string s = " SELECT ";
            string inners = " ";
            Table t = MetaData.tables[tag];
            for (int i = 1; i < t.fields.Count; i++)
            {
                if (t.fields[i].referenceTable != -1)
                {
                    int reftag = t.fields[i].referenceTable;
                    Table reft = MetaData.tables[reftag];
                    inners += " INNER JOIN " + reft.name + " ON " + reft.name + ".ID = "
                                + t.name + "." + t.fields[i].name;
                    for (int j = 1; j < reft.fields.Count; j++)
                    {
                        s += reft.name + "." + reft.fields[j].name + ", ";
                    }
                }
                else
                {
                    s += t.name + "." + t.fields[i].name + ", ";
                }
            }
            s = s.Remove(s.Length - 2, 1) ;
            s += " FROM " + t.name;
            s += inners;
            return s;
        }
    }
}
