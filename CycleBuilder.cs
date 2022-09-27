using System.Runtime.CompilerServices;

namespace DeleteConsole
{
    internal class CycleBuilder
    {
        private List<int[]> _cycles =  new List<int[]>();
        private int _t;
        private string _rule;

        public CycleBuilder(int t, string rule)
        {
            _cycles.Add(Constants.StartLine);
            _t = t;
            _rule = rule;
        }

        public void Work()
        {
            Build();
            Show();
        }

        private void Build()
        {
            for (int i = 1; i < _t + 1; i++)
            {
                _cycles.Add(GetNewLine(i - 1));
            }
        }

        private int[] GetNewLine(int v)
        {
            var result = new int[Constants.StartLine.Length];

            FillDefaultValue(ref result, 0, v + 1, 2);

            FillCalculatedValue(ref result, v, Constants.StartLine.Length - v - 1);

            FillDefaultValue(ref result, Constants.StartLine.Length - v - 1, Constants.StartLine.Length, 2);

            return result;
        }

        private void FillCalculatedValue(ref int[] result, int v, int v2)
        {
            for (int i = v + 1; i < Constants.StartLine.Length - v - 1; i++)
            {
                result[i] = Calculate(v, i);
            }
        }

        private int Calculate(int lineIndex, int i)
        {
            int multiplier = 4;
            int ruleIndex = 0;
            for (int t = i - 1; t < i + 2; t++)
            {
                ruleIndex += _cycles[lineIndex][t] * multiplier;
                multiplier /= 2;
            }

            return Convert.ToInt32(_rule[ruleIndex].ToString());
        }

        private void Show()
        {
            foreach (var line in _cycles)
            {
                foreach (var symbol in line)
                {
                    Console.Write(symbol + " ");
                }

                Console.WriteLine();
            }
        }

        private void FillDefaultValue(ref int[] result, int startIndex, int endIndex, int value)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                result[i] = value;
            }
        }
    }
}
