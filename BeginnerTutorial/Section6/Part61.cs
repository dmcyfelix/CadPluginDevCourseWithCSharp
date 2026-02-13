namespace IFoxCADProgramming.Section6;

public class Part61
{
    [CommandMethod(nameof(TestGetSelection))]
    public static void TestGetSelection()
    {
        var psr = Env.Editor.GetSelection();
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"选择集中实体的数量(Count of entities in the SelectionSet):{ss.Count.ToString()}");
    }

    [CommandMethod(nameof(TestSsGet))]
    public static void TestSsGet()
    {
        var psr = Env.Editor.SSGet();
        if (psr.Status != PromptStatus.OK) return;
        var ss = psr.Value;
        Env.Printl($"选择集中实体的数量(Count of entities in the SelectionSet):{ss.Count.ToString()}");
    }

    [CommandMethod(nameof(TestGetSelectionWithUnion))]
    public static void TestGetSelectionWithUnion()
    {
        var firstPsr = Env.Editor.GetSelection();
        if (firstPsr.Status != PromptStatus.OK) return;
        Env.Printl($"第一个选择集中的实体的数量(Count of entities in the first SelectionSet):{firstPsr.Value.Count.ToString()}");

        var sencondPsr = Env.Editor.GetSelection();
        if (sencondPsr.Status != PromptStatus.OK) return;
        Env.Printl($"第二个选择集中的实体的数量(Count of entities in the second SelectionSet):{sencondPsr.Value.Count.ToString()}");

        var mergeSs = firstPsr.Value.GetObjectIds().Union(sencondPsr.Value.GetObjectIds());
        Env.Printl($"合并后的选择集中的实体的数量(Count of entities in the merged SelectionSet):{mergeSs.Count().ToString()}");
    }

    [CommandMethod(nameof(TestGetSelectionWithExcept))]
    public static void TestGetSelectionWithExcept()
    {
        var firstPsr = Env.Editor.GetSelection();
        if (firstPsr.Status != PromptStatus.OK) return;
        Env.Printl($"第一个选择集中的实体的数量(Count of entities in the first SelectionSet):{firstPsr.Value.Count.ToString()}");

        var sencondPsr = Env.Editor.GetSelection();
        if (sencondPsr.Status != PromptStatus.OK) return;
        Env.Printl($"第二个选择集中的实体的数量(Count of entities in the second SelectionSet):{sencondPsr.Value.Count.ToString()}");

        var mergeSs = firstPsr.Value.GetObjectIds().Except(sencondPsr.Value.GetObjectIds());
        Env.Printl($"从第一个选择集中删除第二选择集后的实体数量The number of entities in the first SelectionSet minus the SelectionSet.:{mergeSs.Count().ToString()}");
    }

    [CommandMethod(nameof(TestGetSelectionWithIntersect))]
    public static void TestGetSelectionWithIntersect()
    {
        var firstPsr = Env.Editor.GetSelection();
        if (firstPsr.Status != PromptStatus.OK) return;
        Env.Printl($"第一个选择集中的实体的数量(Count of entities in the first SelectionSet):{firstPsr.Value.Count.ToString()}");

        var sencondPsr = Env.Editor.GetSelection();
        if (sencondPsr.Status != PromptStatus.OK) return;
        Env.Printl($"第二个选择集中的实体的数量(Count of entities in the second SelectionSet):{sencondPsr.Value.Count.ToString()}");

        var mergeSs = firstPsr.Value.GetObjectIds().Intersect(sencondPsr.Value.GetObjectIds());
        Env.Printl($"两个选择集中共有(Intersection of the two SelectionSets):{mergeSs.Count().ToString()}");
    }
}