namespace IFoxCADProgramming.Section4;

public class Part42
{
    [CommandMethod(nameof(AddPlByNativeApi))]
    public static void AddPlByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用原生API创建一个多段线
        // 2. Create a polyline using native API
        var tmpPl = new Polyline();
        tmpPl.AddVertexAt(0, new(0, 0), 0, 0, 0);
        tmpPl.AddVertexAt(1, new(1, 0), 0, 0, 0);
        tmpPl.AddVertexAt(2, new(1, 1), 0, 0, 0);
        // 3. 设置多段线的属性
        // 3. Set polyline properties
        tmpPl.Closed = true;
        tmpPl.ConstantWidth = 0.2;
        tmpPl.ColorIndex = 3;
        // 4. 将多段线添加到当前空间（模型空间或图纸空间）
        // 4. Add the polyline to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpPl);
    }

    [CommandMethod(nameof(AddPlByCreatePolylineFunc))]
    public static void AddPlByCreatePolylineFunc()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 创建多段线的点集合
        // 2. Create a point collection for the polyline
        var pts = new List<Point3d>
        {
            new(0, 0, 0),
            new(0, 1, 0),
            new(1, 1, 0),
            new(1, 0, 0)
        };
        // 3. 使用IFoxCAD的CreatePolyline函数进行多段线创建并设置多段线的属性
        // 3. Use IFoxCAD's CreatePolyline function to create the polyline and set the polyline properties
        var tmpPl = pts.CreatePolyline(p =>
        {
            p.Closed = true;
            p.ConstantWidth = 0.2;
            p.ColorIndex = 3;
        });
        // 4. 将多段线添加到当前空间（模型空间或图纸空间）
        // 4. Add the polyline to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpPl);
    }

    [CommandMethod(nameof(AddPlByToPolylineFunc))]
    public static void AddPlByToPolylineFunc()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 创建多段线的点集合
        // 2. Create a point collection for the polyline
        var pts = new List<Point3d>
        {
            new(0, 0, 0),
            new(0, 1, 0),
            new(1, 1, 0),
            new(1, 0, 0)
        };
        // 3. 使用IFoxCAD的ToPolyline函数进行多段线创建并设置多段线的属性(只能设置线宽和是否闭合，不能设置颜色)
        // 3. Use IFoxCAD's ToPolyline function to create the polyline and set the polyline properties (only width and closed can be set, not color)
        var tmpPl = pts.ToPolyline(0.2, true);
        // 4. 将多段线添加到当前空间（模型空间或图纸空间）
        // 4. Add the polyline to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpPl);
    }
}