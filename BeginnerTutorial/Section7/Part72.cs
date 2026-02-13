namespace IFoxCADProgramming.Section7;

public class Part72
{
    [CommandMethod(nameof(TestMirrorEntityByPoint))]
    public static void TestMirrorEntityByPoint()
    {
        // 1. 使用GetEntity函数获取一个实体
        // 1. Use GetEntity function to get an entity.
        var per = Env.Editor.GetEntity("\n请选择一个图元实体(Please select an entity): ");
        if (per.Status != PromptStatus.OK) return;
        // 2. 开启事务
        // 2. Start a transaction.
        using var tr = new DBTrans();
        // 3. 使用GetObject函数获取实体
        // 3. Use GetObject function to get the entity.
        var tmpEnt = tr.GetObject<Entity>(per.ObjectId);
        if (tmpEnt == null) return;
        // 4. 设置镜像点
        // 4. Set the mirror point.
        var mirrorPoint = new Point3d(0, 0, 0);
        // 5. 镜像实体
        // 5. Mirror the entity.
        tmpEnt.Mirror(mirrorPoint);
    }
    
    [CommandMethod(nameof(TestMirrorEntityByLine))]
    public static void TestMirrorEntityByLine()
    {
        // 1. 使用GetEntity函数获取一个实体
        // 1. Use GetEntity function to get an entity.
        var per = Env.Editor.GetEntity("\n请选择一个图元实体(Please select an entity): ");
        if (per.Status != PromptStatus.OK) return;
        // 2. 开启事务
        // 2. Start a transaction.
        using var tr = new DBTrans();
        // 3. 使用GetObject函数获取实体
        // 3. Use GetObject function to get the entity.
        var tmpEnt = tr.GetObject<Entity>(per.ObjectId);
        if (tmpEnt == null) return;
        // 4. 设置两个镜像点
        // 4. Set two mirror points.
        var mirrorPoint1 = new Point3d(0, 0, 0);
        var mirrorPoint2 = new Point3d(0, 10, 0);
        // 5. 镜像实体
        // 5. Mirror the entity.
        tmpEnt.Mirror(mirrorPoint1, mirrorPoint2);
    }
    
    [CommandMethod(nameof(TestMirrorEntityByPlane))]
    public static void TestMirrorEntityByPlane()
    {
        // 1. 使用GetEntity函数获取一个实体
        // 1. Use GetEntity function to get an entity.
        var per = Env.Editor.GetEntity("\n请选择一个图元实体(Please select an entity): ");
        if (per.Status != PromptStatus.OK) return;
        // 2. 开启事务
        // 2. Start a transaction.
        using var tr = new DBTrans();
        // 3. 使用GetObject函数获取实体
        // 3. Use GetObject function to get the entity.
        var tmpEnt = tr.GetObject<Entity>(per.ObjectId);
        if (tmpEnt == null) return;
        // 4. 设置镜像面
        // 4. Set the mirror plane.
        var mirrorPlane = PlaneEx.X;
        // 5. 镜像实体
        // 5. Mirror the entity.
        tmpEnt.Mirror(mirrorPlane);
    }
}