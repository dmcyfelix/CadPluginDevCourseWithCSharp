namespace IFoxCADProgramming.Section7;

public class Part77
{
    [CommandMethod(nameof(TestCopyMultiEntity))]
    public static void TestCopyMultiEntity()
    {
        // 1. 开启事务
        // 1. Start a transaction.
        using var tr = new DBTrans();
        // 2. 使用SSGet函数获取多个对象
        // 2. Use SSGet function to get multiple entities
        var tmpEnts = Env.Editor.SSGet("请选择多个对象(Please select entities):")?
            .Value?.GetEntities<Entity>().ToList();
        if (tmpEnts == null || tmpEnts.Count == 0) return;
        // 3. 遍历获取到的对象
        // 3. Traverse the obtained  objects
        var tmpCopyEnts = new List<Entity>();
        foreach (var tmpEnt in tmpEnts)
        {
            // 4. 复制对象并修改颜色，然后移动
            // 4. Copy the object, modify the color, and then move it
            var tmpCopyEnt = tmpEnt.Clone() as Entity;
            if (tmpCopyEnt == null) continue;
            tmpCopyEnt.ColorIndex = 2;
            tmpCopyEnt.Move(new Point3d(0, 0, 0), new Point3d(10, 10, 0));
            tmpCopyEnts.Add(tmpCopyEnt);
        }

        // 5. 将复制后的对象添加到数据库中
        // 5. Add the copied objects to the database.
        tr.CurrentSpace.AddEntity(tmpCopyEnts);
    }
}