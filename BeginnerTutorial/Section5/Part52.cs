namespace IFoxCADProgramming.Section5;

public class Part52
{
    [CommandMethod(nameof(TestGetString))]
    public static void TestGetString()
    {
        var pso = new PromptStringOptions("\n请输入字符(Please enter a string): ");
        var result = Env.Editor.GetString(pso);
        if (result.Status != PromptStatus.OK) return;
        Env.Printl($"您输入的是(You entered): {result.StringResult}");
    }

    [CommandMethod(nameof(TestGetKeyWords))]
    public static void TestGetKeyWords()
    {
        //1.初始化 PromptKeywordOptions，设置提示信息
        //1. Initialize PromptKeywordOptions, set prompt message
        var pko = new PromptKeywordOptions("\n请选择绘图模式(Choose drawing mode):");
        //2.添加关键字，设置默认关键字和属性
        //2. Add keywords, set default keyword
        pko.Keywords.Add("Line", "L", "直线(L)");
        pko.Keywords.Add("Circle", "C", "圆(C)");
        pko.Keywords.Add("Arc", "A", "弧(A)");
        pko.Keywords.Default = "Line";
        pko.AllowNone = true;
        pko.AppendKeywordsToMessage = true;
        //3.获取关键字
        var result = Env.Editor.GetKeywords(pko);
        if (result.Status == PromptStatus.OK)
        {
            //4.处理结果
            var choice = result.StringResult;
            switch (choice)
            {
                case "Line":
                    Env.Printl("你选择了直线(Line selected).");
                    break;
                case "Circle":
                    Env.Printl("你选择了圆(Circle selected).");
                    break;
                case "Arc":
                    Env.Printl("你选择了弧(Arc selected).");
                    break;
            }
        }
        else
        {
            Env.Printl("用户取消了操作(User canceled).");
        }
    }
}