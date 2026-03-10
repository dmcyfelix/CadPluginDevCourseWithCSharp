namespace IFoxCADProgramming.Section8;

public class Part86
{
    [CommandMethod(nameof(TestDefineBlockFirstMethod))]
    public static void TestDefineBlockFirstMethod()
    {
        // 1. 创建一个事务
        // 1. Create a transaction
        using var tr = new DBTrans();
        // 2. 创建一个块定义
        // 2. Create a block definition
        var line1 = new Line(new Point3d(0, 0, 0), new Point3d(1, 1, 0));
        var line2 = new Line(new Point3d(0, 0, 0), new Point3d(-1, 1, 0));
        var att1 = new AttributeDefinition()
            { Position = new Point3d(10, 10, 0), Tag = "tagTest1", Height = 1, TextString = "valueTest1" };
        var att2 = new AttributeDefinition()
            { Position = new Point3d(10, 12, 0), Tag = "tagTest2", Height = 1, TextString = "valueTest2" };
        tr.BlockTable.Add("TestBlockOne", line1, line2, att1, att2);
    }

    [CommandMethod(nameof(TestDefineBlockSecondMethod))]
    public static void TestDefineBlockSecondMethod()
    {
        using var tr = new DBTrans();
        var ents = new List<Entity>();
        var line1 = new Line(new Point3d(0, 0, 0), new Point3d(1, 1, 0));
        var line2 = new Line(new Point3d(0, 0, 0), new Point3d(-1, 1, 0));
        ents.Add(line1);
        ents.Add(line2);
        
        var atts = new List<AttributeDefinition>();
        var att1 = new AttributeDefinition()
            { Position = new Point3d(10, 10, 0), Tag = "tagTest1", Height = 1, TextString = "valueTest1" };
        var att2 = new AttributeDefinition()
            { Position = new Point3d(10, 12, 0), Tag = "tagTest2", Height = 1, TextString = "valueTest2" };
        atts.Add(att1);
        atts.Add(att2);
        tr.BlockTable.Add("TestBlockTwo", ents, atts);
    }

    [CommandMethod(nameof(TestInsertBlock))]
    public static void TestInsertBlock()
    {
        using var tr = new DBTrans();
        var def2 = new Dictionary<string, string>
        {
            { "tagTest1", "This is block test" },
            { "tagTest2", "This is block test" }
        };
        tr.CurrentSpace.InsertBlock(Point3d.Origin, "TestBlockTwo", atts: def2);
    }

    [CommandMethod(nameof(TestChangeBlock))]
    public static void TestChangeBlock()
    {
        using var tr = new DBTrans();
        tr.BlockTable.Change("TestBlockTwo", btr =>
        {
            foreach (var id in btr)
            {
                var ent = tr.GetObject<Entity>(id);
                if (ent == null) continue;
                using (ent.ForWrite())
                {
                    switch (ent)
                    {
                        case AttributeDefinition attdef:
                            attdef.TextString = "This is changed";
                            attdef.ColorIndex = 2;
                            break;
                        case Line line:
                            line.ColorIndex = 2;
                            break;
                    }
                }
            }
        });
        tr.Editor?.Regen();
    }
    
    [CommandMethod(nameof(TestRemoveBlock))]
    public static void TestRemoveBlock()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查卸载CENTER线型
        // 2. Unload CENTER line type.
        tr.BlockTable.Remove("TestBlockOne");
        tr.BlockTable.Remove("TestBlockTwo");
    }
}