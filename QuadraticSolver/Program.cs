using QuadraticSolver;

var solver = new QuadraticEquationSolver();

var demos = new (double a, double b, double c, string label)[]
{
    (1,  -5,   6,  "x² - 5x + 6 = 0"),
    (1,  -2,   1,  "x² - 2x + 1 = 0"),
    (1,   0,   1,  "x² + 1 = 0"),
    (2,  -4,   2,  "2x² - 4x + 2 = 0"),
    (1,  -3,  -10, "x² - 3x - 10 = 0"),
};

Console.WriteLine("=== Quadratic Equation Solver ===\n");

foreach (var (a, b, c, label) in demos)
{
    Console.WriteLine($"  {label}");
    Console.WriteLine($"  → {solver.Solve(a, b, c)}\n");
}

Console.WriteLine("Enter your own values (leave blank to quit):");
while (true)
{
    Console.Write("  a = "); if (!TryRead(out double a)) break;
    Console.Write("  b = "); if (!TryRead(out double b)) break;
    Console.Write("  c = "); if (!TryRead(out double c)) break;

    try { Console.WriteLine($"  → {solver.Solve(a, b, c)}\n"); }
    catch (ArgumentException ex) { Console.WriteLine($"  Error: {ex.Message}\n"); }
}

static bool TryRead(out double value)
{
    value = 0;
    string? line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line)) return false;
    return double.TryParse(line, System.Globalization.NumberStyles.Any,
                           System.Globalization.CultureInfo.InvariantCulture, out value);
}
