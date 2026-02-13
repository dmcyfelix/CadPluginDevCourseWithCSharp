namespace IFoxCADProgramming.Section6;

public class Part62
{
    [CommandMethod(nameof(TestSelectImplied), CommandFlags.UsePickSet)]
    public static void TestSelectImplied()
    {
        var psr = Env.Editor.SelectImplied();
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"当前已选择的实体个数(Selected entity count):{ss.Count.ToString()}");
    }

    [CommandMethod(nameof(TestSelectWindow))]
    public static void TestSelectWindow()
    {
        var ppr = Env.Editor.GetPoint("\n指定第一个角点(first corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p1 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第二个角点(second corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p2 = ppr.Value.Ucs2Wcs();
        var psr = Env.Editor.SelectWindow(p1, p2);
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"当前已选择的实体个数(Selected entity count):{ss.Count.ToString()}");
    }

    [CommandMethod(nameof(TestSelectCrossingWindow))]
    public static void TestSelectCrossingWindow()
    {
        var ppr = Env.Editor.GetPoint("\n指定第一个角点(first corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p1 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第二个角点(second corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p2 = ppr.Value.Ucs2Wcs();
        var psr = Env.Editor.SelectCrossingWindow(p1, p2);
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"当前已选择的实体个数(Selected entity count):{ss.Count.ToString()}");
    }


    [CommandMethod(nameof(TestSelectWindowPolygon))]
    public static void TestSelectWindowPolygon()
    {
        var ppr = Env.Editor.GetPoint("\n指定第一个角点(first corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p1 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第二个角点(second corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p2 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第三个角点(third corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p3 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第四个角点(fourth corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p4 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第五个角点(fifth corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p5 = ppr.Value.Ucs2Wcs();
        var wpList = new List<Point3d>() { p1, p2, p3, p4, p5 };
        var psr = Env.Editor.SelectWindowPolygon(wpList.ToCollection());
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"当前已选择的实体个数(Selected entity count):{ss.Count.ToString()}");
    }

    [CommandMethod(nameof(TestSelectCrossingPolygon))]
    public static void TestSelectCrossingPolygon()
    {
        var ppr = Env.Editor.GetPoint("\n指定第一个角点(first corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p1 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第二个角点(second corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p2 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第三个角点(third corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p3 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第四个角点(fourth corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p4 = ppr.Value.Ucs2Wcs();
        ppr = Env.Editor.GetPoint("\n指定第五个角点(fifth corner point):");
        if (ppr.Status != PromptStatus.OK) return;
        var p5 = ppr.Value.Ucs2Wcs();
        var wpList = new List<Point3d>() { p1, p2, p3, p4, p5 };
        var psr = Env.Editor.SelectCrossingPolygon(wpList.ToCollection());
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"当前已选择的实体个数(Selected entity count):{ss.Count.ToString()}");
    }
}