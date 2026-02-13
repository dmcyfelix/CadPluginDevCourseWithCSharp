namespace IFoxCADProgramming.Section4;

public class Part43
{
    [CommandMethod(nameof(AddCircleByNativeApi))]
    public static void AddCircleByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用原生API创建一个圆
        // 2. Use native API to create a circle
        var tmpCircle = new Circle(new(0, 0, 0), new Vector3d(0, 0, 1), 5);
        // 3. 设置圆的颜色
        // 3. Set the color of the circle
        tmpCircle.ColorIndex = 3;
        // 4. 将圆添加到当前空间
        // 4. Add the circle to the current space
        tr.CurrentSpace.AddEntity(tmpCircle);
    }

    [CommandMethod(nameof(AddCircleByCreateCircleFuncFromCenterAndRadius))]
    public static void AddCircleByCreateCircleFuncFromCenterAndRadius()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD的CreateCircle方法创建一个圆，参数为圆心和半径
        // 2. Use IFoxCAD's CreateCircle method to create a circle, with parameters center and radius
        var tmpCircle = CircleEx.CreateCircle(new(0, 0, 0), 5);
        // 3. 设置圆的颜色
        // 3. Set the color of the circle
        tmpCircle.ColorIndex = 3;
        // 4. 将圆添加到当前空间
        // 4. Add the circle to the current space
        tr.CurrentSpace.AddEntity(tmpCircle);
    }

    [CommandMethod(nameof(AddCircleByCreateCircleFuncFromTwoPoints))]
    public static void AddCircleByCreateCircleFuncFromTwoPoints()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD的CreateCircle方法创建一个圆，参数为startPoint和endPoint,两点中心为圆心
        // 2. Use IFoxCAD's CreateCircle method to create a circle, with parameters startPoint and endPoint, the center of the two points as the center of the circle
        var tmpCircle = CircleEx.CreateCircle(new(0, 0, 0), new(10, 10, 0));
        // 3. 设置圆的颜色
        // 3. Set the color of the circle
        tmpCircle.ColorIndex = 3;
        // 4. 将圆添加到当前空间
        // 4. Add the circle to the current space
        tr.CurrentSpace.AddEntity(tmpCircle);
    }

    [CommandMethod(nameof(AddCircleByCreateCircleFuncFromThreePoints))]
    public static void AddCircleByCreateCircleFuncFromThreePoints()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD的CreateCircle方法创建一个圆,参数为3个Point，如果3个点都在圆上，则返回圆对象，否则返回null
        // 2. Use IFoxCAD's CreateCircle method to create a circle, with parameters 3 points, if the 3 points are all on the circle, return the circle object, otherwise return null
        var tmpCircle = CircleEx.CreateCircle(new(-10, 0, 0), new(0, 10, 0), new(10, 0, 0));
        if (tmpCircle == null) return;
        // 3. 设置圆的颜色
        // 3. Set the color of the circle
        tmpCircle.ColorIndex = 3;
        // 4. 将圆添加到当前空间
        // 4. Add the circle to the current space
        tr.CurrentSpace.AddEntity(tmpCircle);
    }
}