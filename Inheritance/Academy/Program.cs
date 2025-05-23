//#define INHERITANCE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //input/output
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Academy
{
	class Program
	{
		static readonly string delimiter = "\n----------------------------------------------\n";
		static void Main(string[] args)
		{
#if INHERITANCE
			Human human = new Human("Montana", "Antonio", 25);
			human.Info();
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96);
			student.Info();
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Info();
			Console.WriteLine(delimiter);

			Human tommy = new Human("Vercetty", "Tommy", 30);
			tommy.Info();
			Console.WriteLine(delimiter);

			Student s_tommy = new Student(tommy, "Theft", "Vice", 95, 98);
			s_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			g_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate graduate = new Graduate("Shreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to cetch Hizenberg");
			graduate.Info();
			Console.WriteLine(delimiter); 
#endif
			//разнотипные в однотипные->generalization
			Human[] group = new Human[]
			{//upcast - преобразование объекта дочернего класса в объект базового класса
			new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96),
			new Teacher("White", "Walter", 50, "Chemistry", 25),
			new Graduate("Vercetty", "Tommy", 30, "Theft", "Voice", 95, 98, "How to make money"),
			new Graduate("Shreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to cetch Hizenberg"),
			new Teacher("Diaz", "Ricardo", 50, "Weapons Distribution", 25) };

			//specialization(уточнение):
			//Print(group);
			//Save(group,"Group.txt");
			//Load("Group.txt");
			//CSV - COMMA SEPARATOR VALUES значения разделенные запятой;

			Human[] group2 = Load("group.txt");
			Print(group2);
		} 
		public static void Print(Human[] group) 
		{
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
				group[i].Info();
				Console.WriteLine(delimiter);
			}
		}

		public static void Save(Human[] group,string filename) 
		{
			StreamWriter sw = new StreamWriter("Group.txt"); //создаем и открываем поток

			for (int i = 0; i < group.Length; i++)
			{
				sw.WriteLine(group[i].ToFileString());
			}
			sw.Close();//потоки обязательно нужно закрывать

			//string[] human2 = File.ReadAllLines("Group.txt");//все линии из файла в массив

			////выводим массив на экран
			//foreach (string s in human2)
			//{
			//	Console.WriteLine(s);
			//}
			//Process.Start("notepad.exe", filename);
		}

		public static Human[] Load(string filename)
		{
		    List<Human> group =new List<Human>();
			
			try 
			{
				StreamReader sr = new StreamReader(filename);

				while (!sr.EndOfStream)
				{
					string buffer = sr.ReadLine();
					//Console.WriteLine(buffer);
					Human human = HumanFactory(buffer.Split(':').First());
					human.Init(buffer.Split(':').Last().Split(','));
					group.Add(human);
				}

				sr.Close();
			}
			catch (Exception ex) 
			{
			 Console.WriteLine(ex.Message);
			}
			return group.ToArray();
		}

		public static Human HumanFactory (string type) 
		{
			Human human = null;
			switch (type) 
			{
				case "Human": human = new Human("", "", 0); break;
				case "Student": human = new Student("", "", 0, "", "", 0, 0); break;
				case "Graduate": human = new Graduate("", "", 0, "", "", 0, 0,"n/a"); break;
				case "Teacher": human = new Teacher("", "", 0, "", 0); break;

			}
				return human;
		}
	}
}




