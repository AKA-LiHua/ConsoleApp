using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Linq
{
    public class DataInit
    {
        public static List<Student> GetStudentsList()
        {
            List<Student> studentsList = new List<Student>()
            {
                new Student()
                {
                    Id="1",
                    Name="zhangsan",
                    ClassId=1,
                    Age=13
                },
                new Student()
                {
                    Id="2",
                    Name="lisi",
                    ClassId=1,
                    Age=13
                },
                new Student()
                {
                    Id="3",
                    Name="wangwu",
                    ClassId=2,
                    Age=15
                },
                new Student()
                {
                    Id="4",
                    Name="zhaoliu",
                    ClassId=3,
                    Age=18
                },
                new Student()
                {
                    Id="5",
                    Name="ritian",
                    ClassId=5,
                    Age=20
                }
            };
            return studentsList;
        }
    }
}
