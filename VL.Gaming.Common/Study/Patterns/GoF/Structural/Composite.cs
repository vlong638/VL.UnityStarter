using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Study.Patterns
{
    /// <summary>
    /// Composite 聚合结构，将他们进行抽象化的统一定义，从而使得他们可以以相同的结构进行集合处理
    /// 要点：提炼抽象，对抽象对象集合聚合处理，集合分层处理
    /// </summary>
    public class SampleComposite
    {
        public void Test()
        {
            List<IEmployee> employees= new List<IEmployee>();
            employees.Add(new Developer("John", "developed for 10 years"));
            employees.Add(new Developer("John", "developed for 3 years,Great Job done!"));
            employees.Add(new Manager("Bob", "ZJUT"));
            employees.Add(new Manager("Alice", "ZJU"));
            employees.ForEach(c => c.PrintDetails());
        }
    }

    interface IEmployee
    {
        void PrintDetails();
    }
    public class Developer : IEmployee
    {
        private string _name;
        private string _description;

        public Developer(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name:{_name},Description:{_description}");
            
        }
    }
    public class Manager : IEmployee
    {
        private string _name;
        private string _education;

        public Manager(string name, string education)
        {
            _name = name;
            _education = education;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name:{_name},Education:{_education}");

        }
    }
}
