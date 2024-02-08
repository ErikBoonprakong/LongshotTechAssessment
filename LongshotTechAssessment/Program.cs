using System.Linq.Expressions;

// define 16 registers
long[] registers = new long[16];
Console.WriteLine("Enter command list");
string commands = Console.ReadLine();
string[] commandList = commands.Split(',');
string action = string.Empty;
long value = 0;
long registerNumber = 0;
long secondRegisterNumber = 0;  
// Iterate through each command
foreach (string command in commandList)
{
    action = command.Split(' ')[0];
    switch (action)
    {
        case "ADD":
            value = Int64.Parse(command.Split(' ')[1]);
            registerNumber = Int64.Parse(command.Split(' ')[2].Substring(1, command.Split(' ')[2].Length - 1));
            secondRegisterNumber = Int64.Parse(command.Split(' ')[3].Substring(1, command.Split(' ')[3].Length - 1));
            // vvvvvvvvv Change this line depending on definition meaning vvvvvvvvv (+= --> =)
            registers[secondRegisterNumber] = registers[registerNumber] + value;
            // registers[registerNumber] += value;
            Console.WriteLine($"R{secondRegisterNumber} = {registers[secondRegisterNumber]}");
            break;
        case "MOV":
            registerNumber = Int64.Parse(command.Split(' ')[1].Substring(1, command.Split(' ')[1].Length - 1));
            secondRegisterNumber = Int64.Parse(command.Split(' ')[2].Substring(1, command.Split(' ')[2].Length - 1));
            registers[secondRegisterNumber] = registers[registerNumber];
            Console.WriteLine($"R{secondRegisterNumber} = {registers[secondRegisterNumber]}");
            break;
        case "STORE":
            value = Int64.Parse(command.Split(' ')[1]);
            registerNumber = Int64.Parse(command.Split(' ')[2].Substring(1, command.Split(' ')[2].Length - 1));
            registers[registerNumber] = value;
            Console.WriteLine($"R{registerNumber} = {registers[registerNumber]}");
            break;
        default:
            break;
    }
    action = string.Empty;
    value = 0;
    registerNumber = 0;
    secondRegisterNumber = 0;
}
Console.WriteLine("\n\n\n\n");
long registerSum = 0;
for (int i = 0; i < registers.Length; i++)
{
    registerSum += registers[i];
    Console.WriteLine($"R{i} = {registers[i]}");
}
Console.WriteLine($"\n\n\n\nSum of all registers = {registerSum}");






Console.ReadLine();
