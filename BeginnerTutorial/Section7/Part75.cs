namespace IFoxCADProgramming.Section7;

public class Part75
{
    [CommandMethod(nameof(TestMoveEntity))]
    public static void TestMoveEntity()
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
        // 4. 设置移动起始点和终点
        // 4. Set the start point and end point of the movement.
        var startPoint = new Point3d(0, 0, 0);
        var endPoint = new Point3d(10, 10, 0);
        // 5. 移动实体
        // 5. Move the entity.
        tmpEnt.Move(startPoint, endPoint);
    }
}