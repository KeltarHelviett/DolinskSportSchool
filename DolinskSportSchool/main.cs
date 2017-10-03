using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

            MetaData.GetDBName();

            MetaData.AddTable("GENDERS", "");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count++, "GENDER", "Пол", DataType.String, -1, DataGridViewContentAlignment.MiddleCenter);

            MetaData.AddTable("SCHOOLS", "Школы");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count++, "SCHOOL_NAME", "Школа", DataType.String, -1, DataGridViewContentAlignment.MiddleCenter);

            MetaData.AddTable("CLASSES", "Классы");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count++, "CLASS_NAME", "Класс", DataType.String, -1, DataGridViewContentAlignment.MiddleCenter);

            MetaData.AddTable("SPORTS", "Виды Спорта");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count++, "SPORT_NAME", "Вид Спорта", DataType.String, -1, DataGridViewContentAlignment.MiddleCenter);

            MetaData.AddTable("COACHES", "Тренеры");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count++, "COACH_FFM", "Тренер", DataType.String, -1, DataGridViewContentAlignment.MiddleCenter);

            MetaData.AddTable("STAGES", "Этапы");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count++, "STAGE_NAME", "Этап", DataType.String, -1, DataGridViewContentAlignment.MiddleCenter);

            MetaData.AddTable("STUDENTS", "Обучающиеся", "FAMILY_NAME, FIRST_NAME");
            MetaData.AddField(count, "ID", "", DataType.Integer, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count, "FAMILY_NAME", "Фамилия", DataType.String, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count, "FIRST_NAME", "Имя", DataType.String, -1, DataGridViewContentAlignment.MiddleLeft);
            MetaData.AddField(count, "BIRTH_DATE", "Дата рождения", DataType.Date, -1, DataGridViewContentAlignment.MiddleCenter);
            MetaData.AddField(count, "GENDER_ID", "Пол", DataType.Integer, 0, DataGridViewContentAlignment.MiddleCenter);
            MetaData.AddField(count, "SCHOOL_ID", "Образовательное учреждение", DataType.String, 1, DataGridViewContentAlignment.MiddleCenter);
            MetaData.AddField(count, "CLASS_ID", "Класс", DataType.String, 2, DataGridViewContentAlignment.MiddleCenter);
            MetaData.AddField(count, "SPORT_ID", "Вид спорта", DataType.String, 3, DataGridViewContentAlignment.MiddleCenter);
            MetaData.AddField(count, "COACH_ID", "Тренер-преподаватель", DataType.String, 4, DataGridViewContentAlignment.MiddleCenter);
            MetaData.AddField(count++, "STAGE_ID", "Группа", DataType.String, 5, DataGridViewContentAlignment.MiddleCenter);
        }
    }
}
