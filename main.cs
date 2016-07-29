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
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count++, "GENDER", "Пол", DataType.String, -1);

            MetaData.AddTable("SCHOOLS", "Школы");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count++, "SCHOOL_NAME", "Школа", DataType.String, -1);

            MetaData.AddTable("CLASSES", "Классы");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count++, "CLASS_NAME", "Класс", DataType.String, -1);

            MetaData.AddTable("SPORTS", "Виды Спорта");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count++, "SPORT_NAME", "Вид Спорта", DataType.String, -1);

            MetaData.AddTable("COACHES", "Тренеры");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count++, "COACH_FFM", "Тренер", DataType.String, -1);

            MetaData.AddTable("STAGES", "Этапы");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count++, "STAGE_NAME", "Этап", DataType.String, -1);

            MetaData.AddTable("STUDENTS", "Обучающиеся");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1);
            MetaData.AddField(count, "FAMILY_NAME", "Фамилия", DataType.String, -1);
            MetaData.AddField(count, "FIRST_NAME", "Имя", DataType.String, -1);
            MetaData.AddField(count, "BIRTH_DATE", "Дата рождения", DataType.Date, -1);
            MetaData.AddField(count, "GENDER_ID", "Пол", DataType.Integer, 0);
            MetaData.AddField(count, "SCHOOL_ID", "Школа", DataType.String, 1);
            MetaData.AddField(count, "CLASS_ID", "Класс", DataType.String, 2);
            MetaData.AddField(count, "SPORT_ID", "Вид Спорта", DataType.String, 3);
            MetaData.AddField(count, "COACH_ID", "Тренер", DataType.String, 4);
            MetaData.AddField(count++, "STAGE_ID", "Этап", DataType.String, 5);
        }
    }
}
