namespace IFoxCADProgramming.Section4;

public class Part46
{
    [CommandMethod(nameof(AddSplineByNativeApi))]
    public static void AddSplineByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 设置样条曲线的点集
        // 2. Set the point set of the spline
        var fitPoints = new List<Point3d>
        {
            new Point3d(0, 0, 0),
            new Point3d(10, 20, 0),
            new Point3d(30, 5, 0),
            new Point3d(40, 30, 0)
        };
        // 3. 设置样条曲线的起始和结束切线
        // 3. Set the start and end tangents of the spline
        var startTangent = new Vector3d(1, 0, 0);
        var endTangent = new Vector3d(1, 0, 0);
        // 4. 创建样条曲线对象
        // 4. Create the spline curve object
        var tmpSpline = new Spline(fitPoints.ToCollection(), startTangent, endTangent,
            KnotParameterizationEnum.Chord,
            3, 0);
        // 5. 设置样条曲线的颜色
        // 5. Set the color of the spline
        tmpSpline.ColorIndex = 3;
        // 6. 将样条曲线添加到当前空间中
        // 6. Add the spline curve to the current space
        tr.CurrentSpace.AddEntity(tmpSpline);
    }
}