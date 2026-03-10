namespace IFoxCADProgramming.Section8;

public class Part82
{
    [CommandMethod(nameof(TestAddTextStyleByFontName))]
    public static void TestAddTextStyleByFontName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 添加名为arial的字体样式
        // 2. Add a text style named arial.
        tr.TextStyleTable.Add("arial", "arial.ttf", 0.8);
    }

    [CommandMethod(nameof(TestAddTextStyleByFontTtf))]
    public static void TestAddTextStyleByFontTtf()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 添加名为arial2的字体样式
        // 2. Add a text style named arial2.
        tr.TextStyleTable.Add("arial2", FontTTF.Arial, 0.8);
    }

    [CommandMethod(nameof(TestAddTextStyleByBigFont))]
    public static void TestAddTextStyleByBigFont()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 添加名为daziti的字体样式,其中大字体为gbcbig.shx
        // 2. Add a text style named daziti, where the big font is gbcbig.shx.
        tr.TextStyleTable.Add("daziti", ttr =>
        {
            ttr.FileName = "romans.shx";
            ttr.BigFontFileName = "gbcbig.shx";
        });
    }

    [CommandMethod(nameof(TestQueryTextStyleByName))]
    public static void TestQueryTextStyleByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 查询是否有名为daziti的字体样式、
        // 2. Query whether there is a text style named daziti, and if so, print a message.
        if (tr.TextStyleTable.Has("daziti"))
        {
            Env.Printl("查询到含有名为daziti的字体样式(The textstyle named daziti has been found.)");
        }
    }

    [CommandMethod(nameof(TestChangeTextStyleByName))]
    public static void TestChangeTextStyleByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 将名为daziti的字体样式修改为dazitinew,其中大字体为hzdx.shx
        // 2. Change the text style named daziti to dazitinew, where the big font is Sd_hzxh.shx.
        if (tr.TextStyleTable.Has("daziti"))
        {
            tr.TextStyleTable.AddWithChange("dazitinew", "SD_NUM_NEW.shx", 
                "Sd_hzxh.shx", 0.8, 2.5, true);
        }
    }

    [CommandMethod(nameof(TestRemoveTextStyleByName))]
    public static void TestRemoveTextStyleByName()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 删除名为dazitinew的字体样式
        // 2. Delete the text style named dazitinew.
        if (tr.TextStyleTable.Has("dazitinew"))
        {
            tr.TextStyleTable.Remove("dazitinew");
        }
    }
}