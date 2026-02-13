namespace IFoxCADProgramming.Section7;

public class Part76
{
    [CommandMethod(nameof(TestCopyCircle))]
    public static void TestCopyCircle()
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
        // 4. 复制这个圆,然后修改复制圆的圆心、半径和颜色
        // 4. Copy this circle and modify its radius and color.
        var tmpCircleCopy = tmpCircle.Clone() as Circle;
        if (tmpCircleCopy == null) return;
        tmpCircleCopy.Center = new(10, 10, 0);
        tmpCircleCopy.Radius = 10;
        tmpCircleCopy.ColorIndex = 2;
        // 5. 将复制的圆添加到当前空间
        // 5. Add the copied circle to the current space.
        tr.CurrentSpace.AddEntity(tmpCircleCopy);
    }
}