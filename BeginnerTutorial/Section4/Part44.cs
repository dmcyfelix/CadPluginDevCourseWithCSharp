namespace IFoxCADProgramming.Section4;

public class Part44
{
    [CommandMethod(nameof(AddArcByNativeApi))]
    public static void AddArcByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用原生API创建一段圆弧，从0°到90°
        // 2. Use native API to create an arc from 0° to 90°
        var tmpArc = new Arc(new Point3d(0, 0, 0), 10, 0, Math.PI / 2);
        // 3. 设置圆弧的颜色
        // 3. Set the color of the arc
        tmpArc.ColorIndex = 3;
        // 4. 将圆弧添加到当前空间
        // 4. Add the arc to the current space
        tr.CurrentSpace.AddEntity(tmpArc);
    }

    [CommandMethod(nameof(AddArcByCreateArcSce))]
    public static void AddArcByCreateArcSce()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD中ArcEx的CreateArcSCE创建一段圆弧，从0°到90°
        // 2. Use IFoxCAD's ArcEx to create an arc from 0° to 90°
        var tmpArc = ArcEx.CreateArcSCE(new Point3d(10, 0, 0), new Point3d(0, 0, 0), new Point3d(0, 10, 0));
        // 3. 设置圆弧的颜色
        // 3. Set the color of the arc
        tmpArc.ColorIndex = 3;
        // 4. 将圆弧添加到当前空间
        // 4. Add the arc to the current space
        tr.CurrentSpace.AddEntity(tmpArc);
    }

    [CommandMethod(nameof(AddArcByCreateArcFromThreePoints))]
    public static void AddArcByCreateArcFromThreePoints()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD中ArcEx的CreateArc创建一段圆弧，接收圆弧上的三点
        // 2. Use IFoxCAD's ArcEx to create an arc, receiving three points on the arc
        var tmpArc = ArcEx.CreateArc(new Point3d(10, 0, 0), new Point3d(0, 10, 0), new Point3d(-10, 0, 0));
        // 3. 设置圆弧的颜色
        // 3. Set the color of the arc
        tmpArc.ColorIndex = 3;
        // 4. 将圆弧添加到当前空间
        // 4. Add the arc to the current space
        tr.CurrentSpace.AddEntity(tmpArc);
    }

    [CommandMethod(nameof(AddArcByCreateArcFromStartAndCenterAndAngle))]
    public static void AddArcByCreateArcFromStartAndCenterAndAngle()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD中ArcEx的CreateArc创建一段圆弧，接收起始点、圆心和角度三个参数
        // 2. Use IFoxCAD's ArcEx to create an arc, receiving three parameters: start point, center, and angle
        var tmpArc = ArcEx.CreateArc(new Point3d(10, 0, 0), new Point3d(0, 0, 0), Math.PI / 2);
        // 3. 设置圆弧的颜色
        // 3. Set the color of the arc
        tmpArc.ColorIndex = 3;
        // 4. 将圆弧添加到当前空间
        // 4. Add the arc to the current space
        tr.CurrentSpace.AddEntity(tmpArc);
    }

    [CommandMethod(nameof(ConvertArcToPolyline))]
    public static void ConvertArcToPolyline()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD中ArcEx的CreateArc创建一段圆弧，接收起始点、圆心和角度三个参数
        // 2. Use IFoxCAD's ArcEx to create an arc, receiving three parameters: start point, center, and angle
        var tmpArc = ArcEx.CreateArc(new Point3d(10, 0, 0), new Point3d(0, 0, 0), Math.PI / 2);
        // 3. 设置圆弧的颜色
        // 3. Set the color of the arc
        tmpArc.ColorIndex = 3;
        // 4. 将圆弧转换为多段线
        // 4. Convert the arc to a polyline
        var tmpPl = tmpArc.ToPolyline();
        // 5. 将多段线添加到当前空间
        // 5. Add the polyline to the current space
        tr.CurrentSpace.AddEntity(tmpPl);
    }
}