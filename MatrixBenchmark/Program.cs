using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixBenchmark
{
    public class Matrix
    {
        public int Rows { get; }
        public int Cols { get; }
        public double[,] Data { get; }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Data = new double[rows, cols];
        }

        public void FillRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    Data[i, j] = rnd.NextDouble() * 10;
        }
    }

    public class MatrixMultiplier
    {
        public static Matrix MultiplyParallel(Matrix a, Matrix b, int threads)
        {
            Matrix result = new Matrix(a.Rows, b.Cols);
            ParallelOptions opt = new ParallelOptions { MaxDegreeOfParallelism = threads };

            Parallel.For(0, a.Rows, opt, i =>
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Cols; k++)
                        sum += a.Data[i, k] * b.Data[k, j];
                    result.Data[i, j] = sum;
                }
            });
            return result;
        }

        public static Matrix MultiplyThreads(Matrix a, Matrix b, int threadsCount)
        {
            Matrix result = new Matrix(a.Rows, b.Cols);
            Thread[] threads = new Thread[threadsCount];

            // Podzielenie wierszow pomiedzy watki
            int rowsPerThread = a.Rows / threadsCount;

            for (int t = 0; t < threadsCount; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow;

                // Jesli ostatni watek -> koncowy wiersz = ostatni wiersz
                if (t == threadsCount - 1) {
                    endRow = a.Rows;
                } else {
                    endRow = startRow + rowsPerThread;
                }

                threads[t] = new Thread(() =>
                {
                    for (int i = startRow; i < endRow; i++)
                    {
                        for (int j = 0; j < b.Cols; j++)
                        {
                            double sum = 0;
                            for (int k = 0; k < a.Cols; k++)
                                sum += a.Data[i, k] * b.Data[k, j];

                            result.Data[i, j] = sum;
                        }
                    }
                });
                threads[t].Start();
            }

            // Zakonczenie wszystkich watkow
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = { 100, 250, 500 };
            int[] threadCounts = { 2, 4, 8, 12, 16, 20};
            int attempts = 5;

            Console.WriteLine("Rozmiar | Wątki | Sekwencyjnie (ms) | Parallel (ms) | Thread (ms)");
            Console.WriteLine(new string('-', 75));

            foreach (int size in sizes)
            {
                Matrix a = new Matrix(size, size);
                Matrix b = new Matrix(size, size);
                a.FillRandom();
                b.FillRandom();

                foreach (int threads in threadCounts)
                {
                    long seqTime = 0, parTime = 0, thrTime = 0;
                    Stopwatch sw = new Stopwatch();

                    for (int i = 0; i < attempts; i++)
                    {
                        // Sekwencyjnie
                        sw.Restart();
                        MatrixMultiplier.MultiplyParallel(a, b, 1);
                        seqTime += sw.ElapsedMilliseconds;

                        // Parallel
                        sw.Restart();
                        MatrixMultiplier.MultiplyParallel(a, b, threads);
                        parTime += sw.ElapsedMilliseconds;

                        // Thread
                        sw.Restart();
                        MatrixMultiplier.MultiplyThreads(a, b, threads);
                        thrTime += sw.ElapsedMilliseconds;
                    }

                    Console.WriteLine($"{size,7} | {threads,5} | {seqTime / attempts,17} | {parTime / attempts,13} | {thrTime / attempts,11}");
                }
                Console.WriteLine(new string('-', 75));
            }
        }
    }
}
