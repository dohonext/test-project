using System;

namespace ProgExWeek3
{
	class Student
	{
		public string Name;
		public int Korean;
		public int English;
		public int Mathmatics;
		public int Science;

		public Student(string _Name, int _Korean, int _English, int _Mathmatics, int _Science)
		{
			Name = _Name;
			Korean = _Korean;
			English = _English;
			Mathmatics = _Mathmatics;
			Science = _Science;

			// 이름, 국어, 영어, 수학, 과학 점수를 
			// 인자로 받는 생성자를 만드세요
		}
		public int Average() {
			// 평균을 구하세요.
			return (Korean + English + Mathmatics + Science) / 4;
		}
	}

	class Average
	{
		public static void Main (string[] args)
		{
			Student student = new Student ("조영호", 10, 20, 30, 40);
			// 이름과 평균을 출력하세요. 
			Console.WriteLine ("이름 : {0}, 평균: {1}", student.Name, student.Average() );
		}
	}
}
