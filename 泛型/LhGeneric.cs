using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    public class LhGeneric
    {
        public void Show()
        {
            Console.WriteLine("=================================");
            //int iValue = 123;
            //string sValue = "s456";
            //DateTime dtValue = DateTime.Now;
            //object oValue = "objectParameter";

            //CommonMethod.ShowInt(iValue);
            //CommonMethod.ShowString(sValue);
            //CommonMethod.ShowDateTime(dtValue);

            //任何父类出现的地方 都可以用子类代替
            //object 是所有类型的基类（父类）
            //CommonMethod.ShowObject(iValue);
            //CommonMethod.ShowObject(sValue);
            //CommonMethod.ShowObject(dtValue);
            //CommonMethod.ShowObject(oValue);

            Console.WriteLine("=================================");

            //调用时，一般要求指定类型参数，除非可以推算
            //类型参数必须和参数类型一致
            //GenericMethod.Show<int>(iValue);
            //GenericMethod.Show(iValue);
            //GenericMethod.Show<string>(sValue);
            //GenericMethod.Show<DateTime>(dtValue);
            //GenericMethod.Show<object>(oValue);

            Console.WriteLine("=================================");

            //for (int i = 0; i < 5; i++)
            //{
            //    GenericCache<int>.GetData();
            //    GenericCache<string>.GetData();
            //    GenericCache<DateTime>.GetData();
            //    GenericCache<object>.GetData();

            //}

            Console.WriteLine("=================================");
        }

        public void ShowNew()
        {
            People people = new People
            {
                Id = 1,
                Name = "张三"
            };
            Chinese chinese = new Chinese
            {
                Id = 2,
                Name = "里斯"
            };
            HuBei huBei = new HuBei
            {
                Id = 3,
                Name = "英雄"
            };
            Korean korean = new Korean()
            {
                Id = 4,
                Name = "车银优"
            };

            //GenericConstraint.Show<People>(people); //People没有实现ISport接口
            GenericConstraint.Show<Chinese>(chinese);
            GenericConstraint.Show<HuBei>(huBei);
            //GenericConstraint.Show<Korean>(korean); //Korean不是People子类，即使人模狗样，有同样的属性和方法，但就是不能用
        }

        public void ShowCC()
        {
            {
                Bird bird = new Bird();
                Bird bird1 = new Sparrow(); //Sparrow是个Bird，有父子关系
                Sparrow sparrow = new Sparrow();
                //Sparrow sparrow1 = new Bird(); //并不是所有的Bird都是Sparrow
            }
            {
                List<Bird> birds = new List<Bird>();
                //List<Bird> birds1 = new List<Sparrow>();//语义上，一堆Sparrow就是一堆Bird，是正确的  //语法上来说，List<Sparrow>是一个类，List<Bird>也是一个类，但是二者没有父子关系
                List<Bird> birds2 = new List<Sparrow>().Select(x => (Bird)x).ToList();
            }
            {
                //协变：可以左边类型参数是父类，右边类型参数是子类
                //要求T只能做返回值，不能做参数
                IEnumerable<Bird> birds = new List<Bird>();
                IEnumerable<Bird> birds1 = new List<Sparrow>();

                Func<Bird> func = new Func<Bird>(() => null);

                ICustomerListOut<Bird> customerListOut = new CustomerListOut<Bird>();
                Bird bird = customerListOut.Get();
                ICustomerListOut <Bird> customerListOut1 = new CustomerListOut<Sparrow>();
                Bird bird1 = customerListOut1.Get();//从右边来看，得到的是Sparrow，属于Bird，是没有运行风险的
            }
            {
                //逆变：可以左边类型参数是子类，右边类型参数是父类
                //要求T只能做参数，不能做返回值
                ICustomerListIn<Sparrow> customerListIn = new CustomerListIn<Sparrow>();
                customerListIn.Show(new Sparrow());
                ICustomerListIn<Sparrow> customerListIn1 = new CustomerListIn<Bird>();
                customerListIn1.Show(new Sparrow());//从右边出发，只要求是个Bird，而左边保证调用时一定是Sparrow ，是没有运行风险的   


                ICustomerListIn<Bird> customerListIn2 = new CustomerListIn<Bird>();
                customerListIn2.Show(new Bird());
                customerListIn2.Show(new Sparrow());

                Action<Sparrow> action = new Action<Bird>((Bird i) => { });
            }
            {
                IMyList<Sparrow, Bird> myList = new MyList<Sparrow, Bird>();
                IMyList<Sparrow, Bird> myList1 = new MyList<Bird, Bird>(); //逆变
                IMyList<Sparrow, Bird> myList2 = new MyList<Sparrow, Sparrow>(); //协变
                IMyList<Sparrow, Bird> myList3 = new MyList<Bird, Sparrow>();//逆变 + 协变
            }
        }
    }
}
