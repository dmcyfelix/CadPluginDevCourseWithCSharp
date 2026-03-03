namespace IFoxCADProgramming.Section4;

public class Part45
{
    [CommandMethod(nameof(AddEllipseByNativeApi))]
    public static void AddEllipseByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 设置圆弧的圆心
        // 2. Set the center of the Ellipse
        var centerPoint = new Point3d(0, 0, 0);
        // 3. 设置椭圆的长轴
        // 3. Set the major axis of the ellipse
        var majorAxis = new Vector3d(20, 0, 0);
        // 4. 设置椭圆的短轴与长轴的比例
        // 4. Set the ratio of the minor axis to the major axis of the ellipse
        var radiusRatio = 10.0 / 20.0;
        // 5. 创建椭圆对象
        // 5. Create an ellipse object
        var tmpEllipse = new Ellipse(centerPoint, Vector3d.ZAxis,
            majorAxis, radiusRatio, 0, 2 * Math.PI);
        // 6. 设置椭圆的颜色
        // 6. Set the color of the ellipse
        tmpEllipse.ColorIndex = 3;
        // 7. 将椭圆对象添加到当前空间
        // 7. Add the ellipse object to the current space
        tr.CurrentSpace.AddEntity(tmpEllipse);
    }
}