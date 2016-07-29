CREATE TABLE COACHES(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	COACH_FFM TEXT NOT NULL
);

INSERT INTO COACHES VALUES(NULL, "Терехов Е.А.");
INSERT INTO COACHES VALUES(NULL, "Марченко В.Е.");

CREATE TABLE SPORTS(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	SPORT_NAME TEXT NOT NULL
);

INSERT INTO SPORTS VALUES(NULL, "Баскетбол");
INSERT INTO SPORTS VALUES(NULL, "Волейбол");
INSERT INTO SPORTS VALUES(NULL, "Лыжи");
INSERT INTO SPORTS VALUES(NULL, "Бокс");
INSERT INTO SPORTS VALUES(NULL, "Футбол");

CREATE TABLE SCHOOLS(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	SCHOOL_NAME TEXT NOT NULL
);

INSERT INTO SCHOOLS VALUES(NULL, "СОШ №2 Долинск");
INSERT INTO SCHOOLS VALUES(NULL, "СОШ №1 Долинск");

CREATE TABLE CLASSES(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	CLASS_NAME TEXT NOT NULL
);

INSERT INTO CLASSES VALUES(NULL, "4");
INSERT INTO CLASSES VALUES(NULL, "5");
INSERT INTO CLASSES VALUES(NULL, "6");
INSERT INTO CLASSES VALUES(NULL, "7");
INSERT INTO CLASSES VALUES(NULL, "8");
INSERT INTO CLASSES VALUES(NULL, "9");
INSERT INTO CLASSES VALUES(NULL, "10");
INSERT INTO CLASSES VALUES(NULL, "11");
INSERT INTO CLASSES VALUES(NULL, "Iк");
INSERT INTO CLASSES VALUES(NULL, "IIк");
INSERT INTO CLASSES VALUES(NULL, "IIIк");
INSERT INTO CLASSES VALUES(NULL, "IVк");
INSERT INTO CLASSES VALUES(NULL, "Vк");

CREATE TABLE GENDERS(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	GENDER TEXT NOT NULL
);

INSERT INTO GENDERS VALUES(NULL, "М");
INSERT INTO GENDERS VALUES(NULL, "Ж");

CREATE TABLE STAGES(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	STAGE_NAME TEXT NOT NULL
);

INSERT INTO STAGES VALUES(NULL, "НП-1");
INSERT INTO STAGES VALUES(NULL, "НП-2");
INSERT INTO STAGES VALUES(NULL, "ТГ-1");
INSERT INTO STAGES VALUES(NULL, "ТГ-2");

CREATE TABLE STUDENTS(
	ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	FAMILY_NAME TEXT NOT NULL,
	FIRST_NAME TEXT NOT NULL,
	BIRTH_DATE TEXT NOT NULL,
	GENDER_ID INTEGER NOT NULL REFERENCES GENDERS(ID),
	SCHOOL_ID INTEGER NOT NULL REFERENCES SCHOOLS(ID),
	CLASS_ID INTEGER NOT NULL REFERENCES CLASSES(ID),
	SPORT_ID INTEGER NOT NULL REFERENCES SPORTS(ID),
	COACH_ID INTEGER NOT NULL REFERENCES COACHES(ID),
	STAGE_ID INTEGER NOT NULL REFERENCES STAGES(ID)
);

INSERT INTO STUDENTS VALUES(NULL, "Терехов", "Михаил", "2005-03-17", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Смирнова", "Олеся", "2005-09-17", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Евпак", "Александр", "2005-06-09", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Ким", "Владислав", "2004-01-24", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Большаков", "Лев", "2004-09-25", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Екименко", "Егор", "2005-04-12", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Рудик", "Александр", "2005-03-01", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Брух", "Иван", "2002-05-05", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Пачуев", "Алексей", "2003-06-02", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Гаврилюк", "Александр", "1999-01-01", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Волков", "Никита", "1999-05-13", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Гулюшев", "Константин", "1995-06-04", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Шубин", "Никита", "2007-10-17", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Мотора", "Юрий", "1996-07-21", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Крепс", "Андрей", "2000-11-10", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Золотухин", "Николай", "2001-07-18", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Самородина", "Софья", "2001-02-02", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Шумеева", "Арина", "2000-03-08", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Ионова", "Александра", "2005-06-25", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Горбачева", "Екатерина", "2005-12-08", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Осипчук", "Софья", "1999-10-12", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Джуманова", "Екатерина", "2000-04-24", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Ким", "Ангелина", "2000-08-13", 2, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Восканян", "Раффи", "2005-12-19", 1, 1, 1, 1, 1, 1);
INSERT INTO STUDENTS VALUES(NULL, "Костолев", "Артём", "2006-08-03", 1, 1, 1, 1, 1, 1);