using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DolinskSportSchool
{
    struct Field
    {
        public string name;
        public string displayName;
        public DataType type;
        public DataGridViewContentAlignment aligment;
        public int referenceTable;
    }

    struct Table
    {
        public string name;
        public string displayName;
        public List<Field> fields;
    }
    static class MetaData
    {
        public static List<Table> tables = new List<Table>();
        public static void AddTable(string name, string displayName)
        {
            Table t = new Table() ;
            t.name = name;
            t.displayName = displayName;
            t.fields = new List<Field>();
            tables.Add(t);
        }
        public static void AddField(int ind, string name, string displayName, DataType type, int refereneTable, DataGridViewContentAlignment aligment)
        {
            Field f = new Field();
            f.name = name;
            f.displayName = displayName;
            f.type = type;
            f.referenceTable = refereneTable;
            f.aligment = aligment;
            tables[ind].fields.Add(f);
        }

        public static void GetDBName()
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\config", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string filename = "";
            if ((filename = sr.ReadLine()) != null)
                DBName = filename;
            else
                DBName = Application.StartupPath + "\\dss.db";
            fs.Close();
            sr.Close();

        }

        public static string DBName = Application.StartupPath + "\\dss.db";
    }
}
