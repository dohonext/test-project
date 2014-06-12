using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Week11_lab1
{
    class Student
    {
        private string Name;
        private string Subject;
        private int Score;

        public Student(string Name, string Subject, int Score)
        {
            this.Name = Name;
            this.Subject = Subject;
            this.Score = Score;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetSubject()
        {
            return Subject;
        }

        public int GetScore()
        {
            return Score;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ArrayList studentsToFile = new ArrayList();
            ArrayList studentsFromFile = new ArrayList();


            for (;;)
            {
                Console.WriteLine("학생 성적정보를 (성명/과목/점수) 순으로 입력하세요");
                Console.Write("성명: ");
                string name = Console.ReadLine();
                Console.Write("과목: ");
                string subject = Console.ReadLine();
                Console.Write("점수: ");
                int score = int.Parse(Console.ReadLine());
                Student student = new Student(name, subject, score);
                studentsToFile.Add(student);
                Console.WriteLine("더 입력하시겠습니까? (y/n)");
                string moreinput = Console.ReadLine();

                if (moreinput == "y")
                {
                }
                else if (moreinput == "n")
                {
                    break;
                }
            }
            
            
            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));
            foreach (Student studen in studentsFromFile)
            {
                bw.Write(studen.GetName());
                bw.Write(studen.GetSubject());
                bw.Write(studen.GetScore());
            }

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.dat",
                   FileMode.Open));
            foreach (Student studen in studentsFromFile)
            {
                Student stude = new Student(br.ReadString(), br.ReadString(), br.ReadInt32());
                studentsFromFile.Add(stude);
                Console.WriteLine("{0}\t{1}\t{2}", stude.GetName(),
                stude.GetSubject(), studen.GetScore());
            }

            br.Close(); 
        }
    }
}
