using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.src
{
    public class DayOne
    {
        public int SolvePartOne(string file)
        {
            var masses = new List<int>();
            
            using var fileStream = new FileStream(file, FileMode.Open);
            using var reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                if(int.TryParse(reader.ReadLine(), out var mass))
                {
                    masses.Add(mass);
                }
            }

            return masses.Sum(m => m / 3 - 2);
        }

        public int SolvePartTwo(string file)
        {
            var masses = new List<int>();

            using var fileStream = new FileStream(file, FileMode.Open);
            using var reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                if (int.TryParse(reader.ReadLine(), out var mass))
                {
                    masses.Add(mass);
                }
            }

            return masses.SelectMany(m => {
                var fuelNeeds = new List<int>();
                while (m > 0)
                {
                    m = m / 3 - 2;
                    if (m > 0)
                    {
                        fuelNeeds.Add(m);
                    }
                }
                return fuelNeeds;
            }).Sum();
        }
    }
}