namespace DeleteConsole
{
    internal class CycleBuilder
    {
        private List<int[]> _cycles =  new List<int[]>();
        private int _t;
        private string _rule;
        private int _length;

        public CycleBuilder(Parser settings)
        {
            _cycles.Add(settings.FirstLine);
            _t = settings.ShiftCount;
            _rule = settings.Rule;
            _length = _cycles.First().Length;
        }

        public void Work()
        {


            if (_t > _cycles[0].Length)
            {
                AddZero();
            }
            else
            {
                Build();
            }

            Console.WriteLine();
            Show();
        }

        private void AddZero()
        {
            _cycles.Add(new int[_cycles.First().Length]);   
        }

        private void Show()
        {
            var lastLine = _cycles.Last();

            foreach (var symbol in lastLine)
            {
                Console.Write(symbol + " ");
            }
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
            var result = new int[_length];

            FillDefaultValue(ref result, 0, v + 1, 0);

            FillCalculatedValue(ref result, v, _length - v - 1);

            FillDefaultValue(ref result, _length - v - 1, _length, 0);

            return result;
        }

        private void FillCalculatedValue(ref int[] result, int v, int v2)
        {
            for (int i = v + 1; i < _length - v - 1; i++)
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

        private void FillDefaultValue(ref int[] result, int startIndex, int endIndex, int value)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                result[i] = value;
            }
        }
    }
}
