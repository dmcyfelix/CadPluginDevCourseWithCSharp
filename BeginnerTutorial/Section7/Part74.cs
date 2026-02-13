namespace IFoxCADProgramming.Section7;

public class Part74
{
    [CommandMethod(nameof(TestScaleEntity))]
    public static void TestScaleEntity()
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
        // 4. 设置缩放基点和缩放比例
        // 4. Set the scale base point and scale ratio.
        var scalePoint = new Point3d(0, 0, 0);
        var scaleRatio = 2;
        // 5. 缩放实体
        // 5. Scale the entity.
        tmpEnt.Scale(scalePoint, scaleRatio);
    }
}