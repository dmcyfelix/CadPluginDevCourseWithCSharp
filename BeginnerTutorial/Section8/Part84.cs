namespace IFoxCADProgramming.Section8;

public class Part84
{
    [CommandMethod(nameof(TestAddDimStyle))]
    public static void TestAddDimStyle()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 添加自定义标注样式
        // 2. Add custom dimension style.
        if (tr.DimStyleTable.Has("CUSDIMSTYLE")) return;
        tr.DimStyleTable.Add("CUSDIMSTYLE", dimStyle =>
        {
            //标注缩放比例
            // Dimension scale.
            dimStyle.Dimlfac = 1;
            //定义为建筑标记
            // Define as architectural tick.
            dimStyle.Dimblk = Env.GetDimblkId(Env.DimblkType.ArchTick);
        });
    }

    [CommandMethod(nameof(TestQueryDimStyle))]
    public static void TestQueryDimStyle()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查询自定义标注样式
        // 2. Query custom dimension style.
        if (tr.DimStyleTable.Has("CUSDIMSTYLE"))
        {
            Env.Printl("查询到含有名为CUSDIMSTYLE的标注样式(The dimstyle named CUSDIMSTYLE has been found.)");
        }
    }

    [CommandMethod(nameof(TestRemoveDimStyle))]
    public static void TestRemoveDimStyle()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查卸载CENTER线型
        // 2. Unload CENTER line type.
        if (tr.DimStyleTable.Has("CUSDIMSTYLE"))
        {
            tr.LinetypeTable["CUSDIMSTYLE"].Erase();
        }
    }
}