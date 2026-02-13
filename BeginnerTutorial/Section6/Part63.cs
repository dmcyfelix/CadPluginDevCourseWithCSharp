namespace IFoxCADProgramming.Section6;

public class Part63
{
    [CommandMethod(nameof(TestFilter))]
    public static void TestFilter()
    {
        var acTypValAr = new TypedValue[2];
        acTypValAr.SetValue(new TypedValue((int)DxfCode.LayerName, "0"), 0);
        acTypValAr.SetValue(new TypedValue((int)DxfCode.Start, "LINE,CIRCLE,LWPOLYLINE"), 1);
        var filter = new SelectionFilter(acTypValAr);
        var psr = Env.Editor.SelectAll(filter);
        if (psr.Status != PromptStatus.OK) return;
        Env.Printl($"选中的实体个数为(Selected entity count is):{psr.Value.Count}");
    }

    [CommandMethod(nameof(TestFilterWithArithmetic))]
    public static void TestFilterWithArithmetic()
    {
        var acTypValAr = new TypedValue[3];
        acTypValAr.SetValue(new TypedValue((int)DxfCode.Start, "CIRCLE"), 0);
        acTypValAr.SetValue(new TypedValue((int)DxfCode.Operator, ">="), 1);
        acTypValAr.SetValue(new TypedValue((int)DxfCode.Real, 5), 2);
        var filter = new SelectionFilter(acTypValAr);
        var psr = Env.Editor.SelectAll(filter);
        if (psr.Status != PromptStatus.OK) return;
        Env.Printl($"选中的实体个数为(Selected entity count is):{psr.Value.Count}");
    }

    [CommandMethod(nameof(TestFilterWithLogical))]
    public static void TestFilterWithLogical()
    {
        TypedValue[] acTypValAr = {
            new TypedValue((int)DxfCode.Operator, "<or"),
            new TypedValue((int)DxfCode.Start, "TEXT"),
            new TypedValue((int)DxfCode.Start, "MTEXT"),
            new TypedValue((int)DxfCode.Operator, "or>")
        };
        var filter = new SelectionFilter(acTypValAr);
        var psr = Env.Editor.SelectAll(filter);
        if (psr.Status != PromptStatus.OK) return;
        Env.Printl($"选中的实体个数为(Selected entity count is):{psr.Value.Count}");
    }
}