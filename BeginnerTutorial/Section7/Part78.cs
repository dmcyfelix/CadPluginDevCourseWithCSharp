namespace IFoxCADProgramming.Section7;

public class Part78
{
    [CommandMethod(nameof(TestEraseMultiEntity))]
    public static void TestEraseMultiEntity()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans(docLock: true);
        // 2. 使用SSGet函数获取多个对象
        // 2. Use SSGet function to get multiple entities
        var tmpEnts = Env.Editor.SSGet("请选择多个对象(Please select entities):")?
            .Value?.GetEntities<Entity>().ToList();
        if (tmpEnts == null || tmpEnts.Count == 0) return;
        // 3. 遍历获取到的对象
        // 3. Traverse the obtained  objects
        foreach (var tmpEnt in tmpEnts)
        {
            // 4. 删除实体对象
            if (!tmpEnt.ObjectId.IsOk()) continue;
            tmpEnt.ObjectId.Erase();
        }
    }
}