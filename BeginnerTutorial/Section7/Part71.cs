namespace IFoxCADProgramming.Section7;

public class Part71
{
    [CommandMethod(nameof(TestEditCircleByGetEntity))]
    public static void TestEditCircleByGetEntity()
    {
        // 1. 使用GetEntity函数获取一个圆对象
        // 1. Use the GetEntity function to select a Circle object.
        var per = Env.Editor.GetEntity("\n请选择一个圆(Please select a circle): ");
        if (per.Status != PromptStatus.OK) return;
        // 2. 开启事务
        // 2. Start a transaction.
        using var tr = new DBTrans();
        // 3. 使用GetObject函数获取圆对象
        // 3. Use GetObject function to get the Circle object.
        var tmpCircle = tr.GetObject<Circle>(per.ObjectId);
        if (tmpCircle == null) return;
        // 4. 修改圆的颜色和半径
        // 4. Modify the color and radius of the circle.
        using (tmpCircle.ForWrite())
        {
            tmpCircle.ColorIndex = 2;
            tmpCircle.Radius = 10;
        }
    }

    [CommandMethod(nameof(TestEditBySsGet))]
    public static void TestEditBySsGet()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 使用SSGet函数获取多个圆对象
        // 2. Use SSGet function to select multiple Circle objects.
        var tmpCircles = Env.Editor.SSGet("请选择圆(Please select circles):")?.Value?.GetEntities<Circle>().ToList();
        if (tmpCircles == null || tmpCircles.Count == 0) return;
        // 3. 修改圆的颜色和半径
        // 3. Modify the color and radius of the circles.
        foreach (var tmpCircle in tmpCircles)
        {
            using (tmpCircle.ForWrite())
            {
                tmpCircle.ColorIndex = 2;
                tmpCircle.Radius = 10;
            }
        }
    }
}