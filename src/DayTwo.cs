using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.src
{
    public class DayTwo
    {
        public int SolvePartOne(string file, int noun = 12, int verb = 2)
        {
            var intcodes = new List<int>();

            using var fileStream = new FileStream(file, FileMode.Open);
            using var reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(line != null)
                {
                    intcodes.AddRange(line.Split(",").Select(i => int.Parse(i)));
                }
            }

            intcodes[1] = noun;
            intcodes[2] = verb;

            var opIndex = 0;
            var opCode = intcodes[opIndex];
            while(opCode != 99)
            {
                var a = intcodes[intcodes[opIndex + 1]];
                var b = intcodes[intcodes[opIndex + 2]];
                var c = intcodes[opIndex + 3];

                intcodes[c] = opCode == 1 ? a + b : a * b;
                opIndex += 4;
                opCode = intcodes[opIndex];
            }

            return intcodes[0];
        }

        public int SolvePartTwo(string file)
        {
            for (var noun = 0; noun <= 99; noun++)
            {
                for(var verb = 0;  verb <= 99; verb++)
                {
                    var result = SolvePartOne(file, noun, verb);
                    if (result == 19690720) 
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return -1;
        }
    }
}
