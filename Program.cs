using DeleteConsole;

var rule = Validator.GetValidRule(ConsoleInput.GetInfo("правило")).ToEightBitBinary();

var T = Validator.GetValidT(ConsoleInput.GetInfo("количество проходов"));

var cycleBuilder = new CycleBuilder(T, rule);

cycleBuilder.Work();