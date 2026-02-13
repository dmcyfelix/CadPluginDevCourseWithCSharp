namespace IFoxCADProgramming.Section8;

public class Part85
{
    [CommandMethod(nameof(TestZoomWindow))]
    public static void TestZoomWindow()
    {
        // 选择第一个点
        // pick first point
        var ptFirstRes = Env.Editor.GetPoint("\nPick a point: ");
        if (ptFirstRes.Status != PromptStatus.OK) return;
        // 选择第二个点
        // pick second point
        var ptSecondRes = Env.Editor.GetPoint("\nPick another point: ");
        if (ptSecondRes.Status != PromptStatus.OK) return;
        // 缩放窗口
        Env.Editor.ZoomWindow(ptFirstRes.Value.Ucs2Wcs(), ptSecondRes.Value.Ucs2Wcs());
    }

    [CommandMethod(nameof(TestZoomExtents))]
    public static void TestZoomExtents()
    {
        // 根据图形边界进行缩放
        // zoom to extents
        Env.Editor.ZoomExtents();
    }

    [CommandMethod(nameof(TestZoomObject))]
    public static void TestZoomObject()
    {
        // 选择一个对象并缩放
        // pick an object and zoom
        using var tr = new DBTrans();
        var per = Env.Editor.GetEntity("\nPick an entity: ");
        if (per.Status != PromptStatus.OK) return;
        var tmpEnt = tr.GetObject<Entity>(per.ObjectId);
        if (tmpEnt == null) return;
        // 缩放对象
        // zoom to object
        Env.Editor.ZoomObject(tmpEnt);
    }
}