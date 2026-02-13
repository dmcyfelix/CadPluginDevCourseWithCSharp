namespace IFoxCADProgramming.Section8;

public class Part81
{
    [CommandMethod(nameof(TestAddLayer))]
    public static void TestAddLayer()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 创建一个新图层
        // 2. Create a new layer.
        var newLayerId = tr.LayerTable.AddOrChange("NewLayer", lt =>
        {
            lt.Color = Color.FromColorIndex(ColorMethod.ByAci, 1);
            lt.LineWeight = LineWeight.LineWeight030;
            lt.IsPlottable = true;
        });
    }

    [CommandMethod(nameof(TestQueryLayerByName))]
    public static void TestQueryLayerByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查询是否还有名为NewLayer的图层
        // 2. Query whether there is a layer named NewLayer.
        if (tr.LayerTable.Has("NewLayer"))
        {
            Env.Printl("查询到含有名为NewLayer的图层(The layer named NewLayer has been found.)");
        }
    }

    [CommandMethod(nameof(TestChangeLayerByName))]
    public static void TestChangeLayerByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 将名为NewLayer的图层名修改为ChangeLayer，并将颜色修改为2号色
        // 2. Rename the layer named NewLayer to UpdateLayer and change its color to 2.
        if (tr.LayerTable.Has("NewLayer"))
        {
            tr.LayerTable.Change("NewLayer", lt =>
            {
                lt.Name = "ChangeLayer";
                lt.Color = Color.FromColorIndex(ColorMethod.ByAci, 2);
            });
        }
    }

    [CommandMethod(nameof(TestRemoveLayerByName))]
    public static void TestRemoveLayerByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 将名为ChangeLayer的图层删除
        // 2. Remove the layer named ChangeLayer.
        if (tr.LayerTable.Has("ChangeLayer"))
        {
            tr.LayerTable.Remove("ChangeLayer");
        }
    }
}