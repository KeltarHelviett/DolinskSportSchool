﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolinskSportSchool
{
    enum DataType
    {
        String = 0,
        Date,
        Integer,
        Float
    }

    struct ParameterInfo
    {
        public DataType type;
        public string value;
        public string id;
    }

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

        static public string BuildFiltersWherePart(FilterList ft, out List<ParameterInfo> parameters)
        {
            List<Filter> lf = ft.getFilters();
            string res = "";
            Random rnd = new Random();
            parameters = new List<ParameterInfo>();

            for (int i = 0; i < lf.Count; i++)
            {
                string[] tmp = new string[1];
                switch (lf[i].Type)
                {
                    case EditorType.DropDownCheckList:
                        tmp = lf[i].CheckList.Summary.Text.Split(",".ToCharArray());
                        for (int j = 0; j < tmp.Count(); j++)
                            tmp[j] = tmp[j].Trim();
                        break;
                    case EditorType.TextBox:
                        tmp[0] = lf[i].Text.Text.Trim();
                        break;
                }
                res += " ( ";
                string tname = MetaData.tables[lf[i].Info.tableTag].name;
                string fname = MetaData.tables[lf[i].Info.tableTag].fields[lf[i].Info.fieldNum].name;
                for (int j = 0; j < tmp.Count(); j++)
                {
                    ParameterInfo pi = new ParameterInfo();
                    pi.type = MetaData.tables[lf[i].Info.tableTag].fields[lf[i].Info.fieldNum].type;
                    pi.value = tmp[j];
                    pi.id = "@" + tname + fname + rnd.Next().ToString() + rnd.Next().ToString();
                    parameters.Add(pi);
                    res += tname + "." + fname + " = " + "\"" + pi.value + "\"" + " OR "; //@[TableName][FieldName][randomint]
                }
                res = res.Remove(res.Length - 3, 3);
                res += " ) AND ";
            }
            if (res.Length - 4 > 0)
                res = res.Remove(res.Length - 4, 4);

            return res;
        }
    }
}
