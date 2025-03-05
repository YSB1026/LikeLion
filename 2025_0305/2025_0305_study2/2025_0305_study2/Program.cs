using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0305_study2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] data = { 1, 2, 3, 4, 5, 6, 7, 8,9,10 };
            //int sum = 0;

            //foreach (int i in data)
            //{
            //    sum += i;
            //}
            //Console.WriteLine(sum);

            //int[] data = { 1, 2, 3, 4 };
            //int count = data.Length;

            //Console.WriteLine($"Count : {data.Length}");

            //double avg = data.Average();
            //Console.WriteLine(avg);

            //int max = data.Max();
            //Console.WriteLine(max);

            //근삿값 구하기 : Near 알고리즘
            //int[] data = { 10, 12, 50, 20, 32, 7 };
            //int target = 22;
            //int nearest = data[0];
            //foreach (var d in data)
            //{
            //    if (Math.Abs(d-target)<Math.Abs(nearest-target))
            //        nearest = d;
            //}

            //Console.WriteLine($"Nearest to {target} : {nearest}");

            //순위 구하기, rank 알고리즘
            //int[] scores = { 87, 50, 55, 92, 78 };

            //for (int i = 0; i < scores.Length; i++)
            //{
            //    int rank = 1;

            //    for (int j = 0; j < scores.Length; j++)
            //    {
            //        if (scores[j] > scores[i]) rank++;
            //    }
            //    Console.WriteLine($"{scores[i]}, Rank : {rank}");
            //}

            //foreach (int i in scores) Console.WriteLine(i);

            //int[] data = { 5, 2, 8, 1, 0 };
            //Array.Sort(data);
            //foreach (int i in data)
            //{
            //    Console.WriteLine(i);
            //}

            //int[] data = { 5, 2, 8, 1, 9 };
            //int target = 5;
            //int index = -1;

            //for (int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] == target)
            //    {
            //        index = i;
            //        break;
            //    }
            //}

            //Console.WriteLine(index>=0 ? $"Found at index {index}" : "Not Found");

            //그룹화하기 : Group 알고리즘
            //데이터를 특정 기준으로 그룹화하기
            string[] fruits = { "apple", "banana", "blueberry", "cherry", "apricot" };
            var groups = fruits.GroupBy(f => f[0]);
            foreach (var group in groups)
            {
                Console.WriteLine($"key : {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
