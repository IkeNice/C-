using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class First
    {
        private readonly int p;
        public int GetP(){ 
            return p; 
        }
        public First(int i){
            this.p = i; 
        }
    }

    class Second
    {
        private readonly int l;

        public int GetL(){ 
            return l; 
        }

        public Second(int i){
            if (i > 99 && i < 1000)
                this.l = i;
            else
            {
                Console.WriteLine("Введено неправильное число ");
                if (i < 99)
                    this.l = 100;
                else
                    this.l = 999;
            }
        }

    }

    class Third
    {
        [STAThread]
        static void Main(string[] args)
        {
            First[] obj = new First[10];
            for (int i = 0; i < 10; i++)
            {
                obj[i] = new First(i);
                Console.WriteLine("obj[{0}] = {1}", i, obj[i].GetP());
            }
            Console.WriteLine();

            Second[] obj1 = new Second[3];
            obj1[0] = new Second(66);
            Console.WriteLine(obj1[0].GetL());
            Console.WriteLine();

            obj1[1] = new Second(777);
            Console.WriteLine(obj1[1].GetL());
            Console.WriteLine();

            obj1[2] = new Second(1001);
            Console.WriteLine(obj1[2].GetL());
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    /*
     class CA
    {
        public int x, y, z;
        public readonly int rd;
        public CA()
        {
            x = 3;
            y = 2;
            z = x + y;
            rd = x + y + z;

        }
        public CA(int a, int b)
        {
            x = a;
            y = b;
            z = a + b;
            rd = x + y + z;

        }
        public CA(int a, int b, int c) : this(a, b)
        {
            z = c;
            rd = x + y + z;
        }

    }

    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            CA obj = new CA();
            Console.WriteLine("x={0,2} y={1,2} z={2,2}", obj.x, obj.y, obj.z);
            CA obj1 = new CA(5, 7);
            Console.WriteLine("x={0,2} y={1,2} z={2,2}", obj1.x, obj1.y, obj1.z);
            CA obj2 = new CA(8, 9, 25);
            Console.WriteLine("x={0,2} y={1,2} z={2,2}", obj2.x, obj2.y, obj2.z);
            Console.WriteLine("поля для чтения  {0,2}  {1,2}  {2,2}", obj.rd, obj1.rd, obj2.rd);
            Console.ReadKey();
        }
    }
    */
}
