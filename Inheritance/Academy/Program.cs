//#define INHERITANCE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //input/output
using System.Diagnostics;

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
			//for (int i = 0; i < group.Length; i++)
			//{
			//	Console.WriteLine(group[i]);
			//	group[i].Info();
			//	Console.WriteLine(delimiter);
			//}

			StreamWriter sw = new StreamWriter("Group.txt"); //создаем и открываем поток

			for (int i = 0; i < group.Length; i++)
			{ 
			  sw.WriteLine(group[i].ToFileString());
			}
			sw.Close();//потоки обязательно нужно закрывать

			string[] human2 = File.ReadAllLines("Group.txt");//все линии из файла в массив

			//  выводим массив на экран
			foreach (string s in human2)
			{
				Console.WriteLine(s);
			}
			//Process.Start("notepad.exe", "group.txt");

			//CSV - COMMA SEPARATOR VALUES значения разделенные запятой;
		} 
	}
}




