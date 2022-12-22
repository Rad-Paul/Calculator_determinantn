namespace Determinant
{
    class Program
    {

        static void sign(int[] v)
        {
            int grad = 0;
            float produs = 1;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (v[i] > v[j]) grad++;
            for (int i = 0; i < n; i++)
            {
                produs *= m[i, v[i]];
            }
            if (grad % 2 == 0) determinant += produs;
            else determinant -= produs;
        }

        static float determinant = 0;
        static int n;
        static int[,] m;

        static void Main(string[] args)
        {
            Console.WriteLine("Dupa introducerea numarului de randuri si de coloane, programul va genera aleatoriu elementele matricei.");
            Console.Write("Introduceti numarul de randuri si de coloane (maxim 10x10) : ");
            n = int.Parse(Console.ReadLine());
            m = new int[n, n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j] = r.Next(10);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            int[] sol = new int[n];
            bool[] b = new bool[n];
            Perm(0, n, sol, b);
            Console.WriteLine($"Rezultatul este: {determinant} ");
            Console.ReadKey();
        }

        static void Perm(int k, int n, int[] sol, bool[] b)
        {
            int[] v = new int[n];
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    v[i] = sol[i];
                sign(v);
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Perm(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }

       
    }
}