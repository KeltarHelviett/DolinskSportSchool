using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolinskSportSchool
{
    static class main
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            initMetaData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }

        static void initMetaData()
        {
            int count = 0;

            MetaData.AddTable("GENDERS", "");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count++, "GENDER", "Пол", "string", -1);

            MetaData.AddTable("SCHOOLS", "Школы");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count++, "SCHOOL_NAME", "Школа", "string", -1);

            MetaData.AddTable("CLASSES", "Классы");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count++, "CLASS_NAME", "Класс", "string", -1);

            MetaData.AddTable("SPORTS", "Виды Спорта");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count++, "SPORT_NAME", "Вид Спорта", "string", -1);

            MetaData.AddTable("COACHES", "Тренеры");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count, "FAMILY_NAME", "Фамилия", "string", -1);
            MetaData.AddField(count, "FIRST_NAME", "Имя", "string", -1);
            MetaData.AddField(count++, "SECOND_NAME", "Отчество", "string", -1);

            MetaData.AddTable("STAGES", "Этапы");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count++, "STAGE_NAME", "Этап", "string", -1);

            MetaData.AddTable("STUDENTS", "Обучающиеся");
            MetaData.AddField(count, "ID", "", "integer", -1);
            MetaData.AddField(count, "FAMILY_NAME", "Фамилия", "string", -1);
            MetaData.AddField(count, "FIRST_NAME", "Имя", "string", -1);
            MetaData.AddField(count, "SECOND_NAME", "Отчество", "string", -1);
            MetaData.AddField(count, "GENDER_ID", "Пол", "integer", 0);
            MetaData.AddField(count, "SCHOOL_ID", "Школа", "string", 1);
            MetaData.AddField(count, "CLASS_ID", "Класс", "string", 2);
            MetaData.AddField(count, "SPORT_ID", "Вид Спорта", "string", 3);
            MetaData.AddField(count, "COACH_ID", "Имя", "string", 4);
            MetaData.AddField(count++, "STAGE_ID", "Этап", "string", 5);
        }
    }
}
