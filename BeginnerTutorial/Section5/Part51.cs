namespace IFoxCADProgramming.Section5;

public class Part51
{
    [CommandMethod(nameof(TestGetInteger))]
    public static void TestGetInteger()
    {
        var result = Env.Editor.GetInteger("\n请输入一个整数(Enter an integer): ");
        if (result.Status != PromptStatus.OK) return;
        Env.Printl($"您输入的是(You entered): {result.Value}");
    }

    [CommandMethod(nameof(TestGetDouble))]
    public static void TestGetDouble()
    {
        var pdo = new PromptDoubleOptions("\n请输入一个实数(Enter an double): ");
        var result = Env.Editor.GetDouble(pdo);
        if (result.Status != PromptStatus.OK) return;
        Env.Printl($"您输入的是(You entered): {result.Value}");
    }

    [CommandMethod(nameof(TestGetAngle))]
    public static void TestGetAngle()
    {
        var pao = new PromptAngleOptions("\n请输入一个角度(Enter an angle): ");
        var result = Env.Editor.GetAngle(pao);
        if (result.Status != PromptStatus.OK) return;
        Env.Printl($"您输入的是(You entered): {result.Value}");
    }

    [CommandMethod(nameof(TestGetDistance))]
    public static void TestGetDistance()
    {
        var pdo = new PromptDistanceOptions("\n指定距离或拾取两点(Specify distance or pick two points): ");
        var result = Env.Editor.GetDistance(pdo);
        if (result.Status != PromptStatus.OK) return;
        Env.Printl($"您输入的是(You entered): {result.Value}");
    }
}