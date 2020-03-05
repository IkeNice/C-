using System;

namespace spiral {
    class Program {
        static void Main(string[] args) {
            int n;
            Console.Write("Enter dimension: ");
            n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            int k = 1;
            int r1 = 0, r2 = n - 1;
            while (k <= n * n) {
                for (int i = r1; i <= r2; i++) {
                    arr[r1, i] = k++;
                    //Console.WriteLine(k);
                    
                }
                for (int i = r1 + 1; i <= r2; i++) {
                    arr[i, r2] = k++;
                    //Console.WriteLine(k);
                }
                for (int i = r2 - 1; i >= r1; i--) {
                    arr[r2, i] = k++;
                    //Console.WriteLine(k);
                }
                for (int i = r2 - 1; i >= r1 + 1; i--) {
                    arr[i, r1] = k++;
                    //Console.WriteLine(k);
                }
                r1++;
                r2--;
            }

            Console.WriteLine();
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write("{0,5} ", arr[i, j]);
                }
                Console.WriteLine();
            }
            
        }
    }

}