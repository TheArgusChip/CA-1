using DeleteConsole;

Console.WriteLine("Введите операцию: ");

int number = 56;

Console.WriteLine(number.ToEightBitBinary());
string operation = $"{number}<<3";



var parser = new Parser(operation);

var cyclebuilder = new CycleBuilder(parser);

cyclebuilder.Work();
//var rule = Validator.GetValidRule(ConsoleInput.GetInfo("правило")).ToEightBitBinary();

//var T = Validator.GetValidT(ConsoleInput.GetInfo("количество проходов"));