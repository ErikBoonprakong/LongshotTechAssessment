using System.Buffers.Text;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

// define 16 registers
long[] registers = new long[16];
Console.WriteLine("Enter encoded command list");
string encodedCommands = Console.ReadLine().Trim();
encodedCommands = encodedCommands.Replace("ok:10 ", ",");
Console.WriteLine("\n\n\nEncoded commands:\n"+encodedCommands);
string[] encodedCommandList = encodedCommands.Split(',');
Console.WriteLine("\n\n\n");
List<string> commandList = new List<string>();
byte[] data;
string decodedCommand = string.Empty;
foreach (string encodedCommand in encodedCommandList)
{
    data = Convert.FromBase64String(encodedCommand.Trim());
    Console.WriteLine($"Byte: {data.Length}");
    decodedCommand = System.Text.Encoding.UTF8.GetString(data);
    commandList.Add(decodedCommand);
    Console.WriteLine($"Decoded command: {decodedCommand}");
    Console.WriteLine($"Number of commands: {commandList.Count}");
}
string action = string.Empty;
long value = 0;
long registerNumber = 0;
long secondRegisterNumber = 0;
// Iterate through each command
foreach (string com in commandList)
{
    string command = com.Replace("\"", string.Empty);
    Console.WriteLine(command);
    action = command.Split(' ')[0];
    switch (action)
    {
        case "ADD":
            value = Int64.Parse(command.Split(' ')[1]);
            registerNumber = Int64.Parse(command.Split(' ')[2].Substring(1, command.Split(' ')[2].Length - 1));
            secondRegisterNumber = Int64.Parse(command.Split(' ')[3].Substring(1, command.Split(' ')[3].Length - 1));
            // vvvvvvvvv Remove this line depending on definition meaning and then change line 47 vvvvvvvvv
            registers[registerNumber] += value;
            // vvvvvvvvv Change this line depending on definition meaning vvvvvvvvv (+= <--> =)
            registers[secondRegisterNumber] = registers[registerNumber];
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
string sumString = registerSum.ToString();
//byte[] textAsBytes = Encoding.GetBytes(sumString);
//string encodedSum = System.Convert.ToBase64String(textAsBytes);
var textBytes = System.Text.Encoding.UTF8.GetBytes(sumString);
string encodedSum = System.Convert.ToBase64String(textBytes);
Console.WriteLine($"\n\n\n\nEncoded sum of all registers = {encodedSum}");






Console.ReadLine();
