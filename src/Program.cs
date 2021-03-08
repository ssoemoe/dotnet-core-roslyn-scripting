using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace Scripting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var input = string.Empty;
            var code = string.Empty;
            while (!input.Trim().Equals("run"))
            {
                code += input;
                Console.Write("> ");
                input = Console.ReadLine();
            }
            var scriptOptions = ScriptOptions.Default;
            scriptOptions = scriptOptions.AddReferences("System");
            code = "using System;" + code;
            var result = await CSharpScript.EvaluateAsync(code, scriptOptions);

            /*
            Compile once. Run many times.
            var script = CSharpScript.Create(code);
            for(var i =0; i < 100;i++) { var result = await script.RunAsycn(); }
            */

            Console.ReadLine();
        }
    }
}
