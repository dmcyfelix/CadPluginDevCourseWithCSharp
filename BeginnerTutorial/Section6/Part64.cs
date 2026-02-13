namespace IFoxCADProgramming.Section6;

public class Part64
{
    [CommandMethod(nameof(TestFilterByOpFilter))]
    public static void TestFilterByOpFilter()
    {
        var filter = OpFilter.Build(e =>
            !(e.Dxf(0) == "LINE" & e.Dxf(8) == "0") |
            (e.Dxf(0) != "CIRCLE" & e.Dxf(8) == "2" & e.Dxf(10) >= new Point3d(10, 10, 0)));
        var psr = Env.Editor.SelectAll(filter);
        if (psr.Status != PromptStatus.OK) return;
        Env.Printl($"选中的实体个数为(Selected entity count is):{psr.Value.Count}");
    }

    [CommandMethod(nameof(TestFilterBySsget))]
    public static void TestFilterBySsget()
    {
        var filter = OpFilter.Build(e =>
            !(e.Dxf(0) == "LINE" & e.Dxf(8) == "0") |
            (e.Dxf(0) != "CIRCLE" & e.Dxf(8) == "2" & e.Dxf(10) >= new Point3d(10, 10, 0)));

        // var filter = OpFilter.Build(e => 
        //     e.Dxf(0) == "CIRCLE" & e.Dxf(8) == "0");
        var psr = Env.Editor.SSGet(filter: filter);
        if (psr.Status != PromptStatus.OK) return;
        Env.Printl($"选中的实体个数为(Selected entity count is):{psr.Value.Count}");
    }
}