namespace IFoxCADProgramming.Section8;

public class Part83
{
    [CommandMethod(nameof(TestAddLineTypeFromAcadIsoLin))]
    public static void TestAddLineTypeFromAcadIsoLin()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 检查是否已经存在CENTER线型
        // 2. Check if CENTER line type exists.
        if (tr.LinetypeTable.Has("CENTER")) return;
        // 3. 从acadiso.lin文件中加载CENTER线型
        // 3. Load CENTER line type from acadiso.lin file.
        tr.Database.LoadLineTypeFile("CENTER", "acadiso.lin");
        // 4. 将CENTER线型应用到新创建的直线
        // 4. Apply CENTER line type to the newly created line.
        tr.Database.Celtype = tr.LinetypeTable["CENTER"];
    }

    [CommandMethod(nameof(TestCreateLineType))]
    public static void TestCreateLineType()
    {
        try
        {
            // 1. 开启事务
            // 1. Start a transaction.
            using var tr = new DBTrans();
            // 2. 添加自定义线型
            // 2. Add custom line type.
            tr.LinetypeTable.Add("CUSTOMLINES", (ltr) =>
            {
                //线型说明
                // Line type description.
                ltr.AsciiDescription = "XX";
                //组成线型的图案长度（划线、空格、点）
                // Pattern length of the line type (dash, gap, dot).
                ltr.PatternLength = 0.95;
                //组成线型的图案数目
                // Number of patterns in the line type.
                ltr.NumDashes = 4;
                //0.5个单位的划线
                ltr.SetDashLengthAt(0, 0.5);
                //0.25个单位的空格
                ltr.SetDashLengthAt(1, -0.25);
                //一个点
                ltr.SetDashLengthAt(2, 0);
                //0.25个单位的空格
                ltr.SetDashLengthAt(3, -0.25);
            });
        }
        catch (Exception e)
        {
            Env.Printl(e.Message);
        }
    }

    [CommandMethod(nameof(TestCreateLineTypeWithText))]
    public static void TestCreateLineTypeWithText()
    {
        try
        {
            // 1. 开启事务
            // 1. Start a transaction.
            using var tr = new DBTrans();
            // 2. 添加自定义线型
            // 2. Add custom line type.
            tr.LinetypeTable.Add("WZXX", ltrText =>
            {
                ltrText.AsciiDescription = "WZXX";
                ltrText.PatternLength = 0.9;
                ltrText.NumDashes = 3;
                ltrText.SetDashLengthAt(0, 0.5);
                ltrText.SetDashLengthAt(1, -0.2);
                //设置文字的文字样式
                // Set text style.
                ltrText.SetShapeStyleAt(1, tr.TextStyleTable["Standard"]);
                ltrText.SetShapeOffsetAt(1, new Vector2d(-0.1, -0.05));
                ltrText.SetShapeScaleAt(1, 0.1);
                ltrText.SetShapeRotationAt(1, 0);
                ltrText.SetTextAt(1, "GAS");
                ltrText.SetDashLengthAt(2, -0.2);
            });
        }
        catch (Exception e)
        {
            Env.Printl(e.Message);
        }
    }

    [CommandMethod(nameof(TestQueryLineTypeByName))]
    public static void TestQueryLineTypeByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 检查是否已经存在CENTER线型
        // 2. Check if CENTER line type exists.
        if (tr.LinetypeTable.Has("CENTER"))
        {
            Env.Printl("查询到含有名为CENTER的线型样式(The linetype named CENTER has been found.)");
        }
    }

    [CommandMethod(nameof(TestQueryLineTypeListAllTypes))]
    public static void TestQueryLineTypeListAllTypes()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查询所有线型
        // 2. Query all line types.
        tr.LinetypeTable.GetRecordNames().ForEach(it => it.Print());
    }

    [CommandMethod(nameof(TestRemoveLineType))]
    public static void TestRemoveLineType()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查卸载CENTER线型
        // 2. Unload CENTER line type.
        tr.LinetypeTable["CENTER"].Erase();
    }
}