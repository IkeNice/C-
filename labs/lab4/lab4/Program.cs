using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    // First example

    // class MathOprt
    // {
    //     public static double Mul2(double val)
    //     {
    //         return val * 2;
    //     }
    //     public static double Sqr(double val)
    //     {
    //         return val * val;
    //     }
    // }
    // delegate double DblOp(double x);//объявление делегата

    // class Class1
    // {
    //     /// <summary>
    //     /// The main entry point for the application.
    //     /// </summary>
    //     [STAThread]
    //     static void Main(string[] args)
    //     {
    //         // TODO: Add code to start application here
    //         DblOp[] operation = // создание экземпляров делегата
    //{
    //                 new DblOp(MathOprt.Mul2),
    //                 new DblOp(MathOprt.Sqr)
    //         };
    //         for (int j = 0; j < operation.Length; j++)
    //         {
    //             Console.WriteLine("Резльтаты операции[{0}]:", j);
    //             Prc(operation[j], 4.0);
    //             Prc(operation[j], 9.94);
    //             Prc(operation[j], 3.143);
    //         }
    //         Console.ReadKey();
    //     }
    //     static void Prc(DblOp act, double val)
    //     {
    //         double rslt = act(val);
    //         Console.WriteLine("Исходное значение {0}, результат  {1}",
    //                 val, rslt);
    //     }
    // }

    // Second example

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    /// 
    class MathOprt
    {
        public static void Mul2(double val)
        {
            double rslt = val * 2;
            Console.WriteLine("Mul2 bсходное значение {0},результат  {1}",
                    val, rslt);
        }
        public static void Sqr(double val)
        {
            double rslt = val * val;
            Console.WriteLine("Sqr исходное значение {0}, результат  {1}",
                    val, rslt);
        }
    }
    delegate void DblOp(double x);//объявление делегата

    class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // TODO: Add code to start application here
            DblOp operations = new DblOp(MathOprt.Mul2);
            operations += new DblOp(MathOprt.Sqr);

            Prc(operations, 4.0);
            Prc(operations, 9.94);
            Prc(operations, 3.143);
            Console.ReadKey();
        }
        static void Prc(DblOp act, double val)
        {
            Console.WriteLine("\n*********\n");
            act(val);
        }
    }


    // Third example

    //class ChangeEventArgs : EventArgs
    //{
    //    string str;
    //    public string Str
    //    {
    //        get
    //        {
    //            return str;
    //        }
    //    }
    //    int change;
    //    public int Change
    //    {
    //        get
    //        {
    //            return change;
    //        }
    //    }
    //    public ChangeEventArgs(string str, int change)
    //    {
    //        this.str = str;
    //        this.change = change;
    //    }
    //}
    //class GenEvent  // Генератор событий - издатель
    //{
    //    public delegate void ChangeEventHandler
    //        (object source, ChangeEventArgs e);

    //    public event ChangeEventHandler OnChangeHandler;

    //    public void UpdateEvent(string str, int change)
    //    {
    //        if (change == 0)
    //            return;
    //        ChangeEventArgs e =
    //        new ChangeEventArgs(str, change);

    //        if (OnChangeHandler != null)
    //            OnChangeHandler(this, e);
    //    }

    //}

    ////Подписчик
    //class RecEvent
    //{
    //    //Обработчик события	
    //    void OnRecChange(object source, ChangeEventArgs e)
    //    {
    //        int change = e.Change;
    //        Console.WriteLine("Вес груза '{0}' был {1} на {2} тонны",
    //            e.Str, change > 0 ? "увеличен" : "уменьшен",
    //            Math.Abs(e.Change));
    //    }

    //    GenEvent gnEvent;
    //    // в конструкторе класса осуществляется подписка
    //    public RecEvent(GenEvent gnEvent)
    //    {
    //        this.gnEvent = gnEvent;
    //        gnEvent.OnChangeHandler +=  //здесь осуществляется подписка
    //                new GenEvent.ChangeEventHandler(OnRecChange);
    //    }
    //}

    //class Class1
    //{
    //    [STAThread]
    //    static void Main(string[] args)
    //    {
    //        GenEvent gnEvent = new GenEvent();
    //        RecEvent inventoryWatch = new RecEvent(gnEvent);
    //        gnEvent.UpdateEvent("грузовика", -2);
    //        gnEvent.UpdateEvent("автопоезда", 4);
    //        Console.ReadKey();

    //    }
    //}

}
