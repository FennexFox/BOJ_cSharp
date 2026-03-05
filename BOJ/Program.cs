using System.Reflection;
using System.Text.RegularExpressions;

namespace BOJ
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var solverMap = BuildSolverMap();

            if (args.Length == 0)
            {
                Console.Error.WriteLine("Usage: dotnet BOJ.dll <problem-id>");
                Console.Error.WriteLine($"Available: {string.Join(", ", solverMap.Keys.OrderBy(x => int.Parse(x)))}");
                return 1;
            }

            var problemId = args[0];
            if (!solverMap.TryGetValue(problemId, out var solverType))
            {
                Console.Error.WriteLine($"Unknown problem id: {problemId}");
                Console.Error.WriteLine($"Available: {string.Join(", ", solverMap.Keys.OrderBy(x => int.Parse(x)))}");
                return 1;
            }

            var mainMethod = solverType.GetMethod(
                "Main",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                binder: null,
                types: Type.EmptyTypes,
                modifiers: null);

            if (mainMethod is null)
            {
                Console.Error.WriteLine($"Solver type '{solverType.Name}' does not have static Main().");
                return 1;
            }

            try
            {
                mainMethod.Invoke(null, null);
                return 0;
            }
            catch (TargetInvocationException ex) when (ex.InnerException is not null)
            {
                Console.Error.WriteLine(ex.InnerException.Message);
                return 1;
            }
        }

        private static Dictionary<string, Type> BuildSolverMap()
        {
            var asm = Assembly.GetExecutingAssembly();
            var regex = new Regex("^Program(\\d+)$", RegexOptions.CultureInvariant);

            return asm.GetTypes()
                .Select(t => new { Type = t, Match = regex.Match(t.Name) })
                .Where(x => x.Match.Success)
                .ToDictionary(
                    x => x.Match.Groups[1].Value,
                    x => x.Type);
        }
    }
}
