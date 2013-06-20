using System.IO;
using System.Collections.Generic;
using System;

public class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (null == line)
                continue;
            var result = EvaluatePrefixExpression(line);
            Console.WriteLine(result);
        }
    }

    public static int EvaluatePrefixExpression(string line)
    {
        var parsedSymbols = line.Split(' ');
        var resultStack = new Stack<int>();
        var validOperators = new List<string> { "+", "*", "/" };

        //Iterate backwards
        for (int i = parsedSymbols.Length - 1; i >= 0; i--)
        {
            var currentSymbol = parsedSymbols[i];
            
            //Time to evaluate
            if (validOperators.Contains(currentSymbol))
            {
                var num1 = resultStack.Pop();
                var num2 = resultStack.Pop();
                int result = 0;
                switch (currentSymbol)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    default:
                        throw new Exception("Unsupported operator found.");
                        break;
                }
                resultStack.Push(result);
            }
            else
            {
                try
                {
                    int intSymbol;
                    int.TryParse(currentSymbol, out intSymbol);
                    resultStack.Push(intSymbol);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught pushing operand on to stack. " + Environment.NewLine + ex.Message);
                }
            }
        }

        return resultStack.Pop();
    }
}