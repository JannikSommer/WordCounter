using System.Diagnostics;
using WordCounter;
using WordCounter.Counter;
using WordCounter.Input;
using WordCounter.Output;

const string EXCLUDE_FILENAME = "exclude.txt";

string inputPath;
string outputPath;
if (Debugger.IsAttached)
{
    inputPath = "/Users/jannik/Documents/GitHub/DBTask/WordCounter/TextInput";
    outputPath = "/Users/jannik/Documents/GitHub/DBTask/WordCounter/Results";
}
else
{
    if (args.Length < 2)
    {
        PrintErrorAndExit("Please provide the input and output destinations as arguments"); 
    }
    inputPath = args[1];
    outputPath = args[2];
}

try
{
    IEnumerable<string> excludedWords = new List<string>();
    excludedWords = File.ReadLines(EXCLUDE_FILENAME).ToList();

    Handler handler = new Handler(
        new WordFrequencyCounter(excludedWords))
        .AddInput(InputTypeResolver.ResolveInputType(inputPath))
        .AddOutput(OutputTypeResolver.ResolveOutputType(outputPath));
    handler.Process();
}
catch (Exception exception)
{
    PrintErrorAndExit(exception.ToString());
}

static void PrintErrorAndExit(string message)
{
    Console.WriteLine(message);
    Environment.Exit(1);
}