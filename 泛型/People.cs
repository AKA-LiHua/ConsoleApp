using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    public interface ISport
    {
        void Walk();
    }
    public interface ITag
    {
        
    }
    public class People: ITag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Breath()
        {
            Console.WriteLine("呼吸");
        }
    }
    public class American : People, ISport
    {
        public void Walk()
        {
            Console.WriteLine("Walk");
        }
    }
    public class Chinese : People, ISport
    {
        public string PingPang { get; set; }
        public void Tradition()
        {
            Console.WriteLine("牛逼");
        }
        public void Walk()
        {
            Console.WriteLine("散步");
        }
    }
    public class HuBei : Chinese
    {
        public string Smart { get; set; }
        public void Majing()
        {
            Console.WriteLine($"{this.Name}打麻将");
        }
    }
    public class Korean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PickledCabbage { get; set; }
        public void Breath()
        {
            Console.WriteLine("FuXi");
        }
        public void Cosmetic()
        {
            Console.WriteLine($"{this.Name}整容了");
        }
    }
}
