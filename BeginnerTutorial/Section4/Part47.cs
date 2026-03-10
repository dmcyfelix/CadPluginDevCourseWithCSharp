namespace IFoxCADProgramming.Section4;

public class Part47
{
    [CommandMethod(nameof(AddDbTextByNativeApi))]
    public static void AddDbTextByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 创建一个DBText对象
        // 2. Create a DBText object
        var tmpDbText = new DBText();
        // 3. 设置DBText对象的属性
        // 3. Set the properties of the DBText object
        tmpDbText.TextString = "Hello World(您好,世界)";
        tmpDbText.Height = 10;
        tmpDbText.Rotation = Math.PI / 4;
        tmpDbText.Position = new Point3d(0, 0, 0); //set postion
        
        tmpDbText.Justify = AttachmentPoint.MiddleMid; //set justify mode
        tmpDbText.AlignmentPoint = new Point3d(0, 0, 0); //set alignment point
        tmpDbText.AdjustAlignment(Env.Database); // adjust alignment
        // 4. 设置DBText的颜色
        // 4. Set the color of the DBText object
        tmpDbText.ColorIndex = 3;
        // 5. 将DBText对象添加到当前空间（模型空间或图纸空间）
        // 5. Add the DBText object to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpDbText);
    }

    [CommandMethod(nameof(AddDbTextByCreateDbText))]
    public static void AddDbTextByCreateDbText()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD中DBTextEx类的CreateDBText创建一个DBText对象
        // 2. Use the CreateDBText method of the DBTextEx class in IFoxCAD to create a DBText object
        var tmpDbText = DBTextEx.CreateDBText(new Point3d(0, 0, 0), "Hello World(您好,世界)",
            10, AttachmentPoint.MiddleMid, null, txt =>
            {
                txt.ColorIndex = 1;
                txt.Rotation = Math.PI / 4;
            });
        // 3. 将DBText对象添加到当前空间（模型空间或图纸空间）
        // 3. Add the DBText object to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpDbText);
    }
}