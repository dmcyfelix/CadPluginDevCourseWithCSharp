namespace IFoxCADProgramming.Section5;

public class Part53
{
    [CommandMethod(nameof(TestGetPoint))]
    public static void TestGetPoint()
    {
        var ppo = new PromptPointOptions("\n请输入第一个点<100,200>(Specify first point <100,200>).");
        ppo.AllowNone = true;
        var result = Env.Editor.GetPoint(ppo);
        if (result.Status != PromptStatus.OK) return;
        Env.Printl($"您输入的是(You entered): {result.Value.ToString()}");
    }

    [CommandMethod(nameof(TestGetCorner))]
    public static void TestGetCorner()
    {
        // 1. 首先获取第一个角点（基准点）
        var ppo = new PromptPointOptions("\n指定第一个角点(first corner point): ");
        ppo.AllowNone = true;
        var ppr = Env.Editor.GetPoint(ppo);
        if (ppr.Status != PromptStatus.OK) return;
        var firstCorner = ppr.Value;

        // 2. 获取第二个角点
        var pco = new PromptCornerOptions("\n指定第二个角点(second corner point): ", firstCorner);
        var pcr = Env.Editor.GetCorner(pco);
        if (pcr.Status != PromptStatus.OK) return;
        var secondCorner = pcr.Value;
        // 计算长、宽和面积 (忽略 Z 轴)
        var width = Math.Abs(secondCorner.X - firstCorner.X);
        var height = Math.Abs(secondCorner.Y - firstCorner.Y);
        var area = width * height;

        Env.Printl($"\n矩形尺寸(rectangle size): {width:F2} x {height:F2}");
        Env.Printl($"\n矩形面积(rectangle area): {area:F2}");
    }
}