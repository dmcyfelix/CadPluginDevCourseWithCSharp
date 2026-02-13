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
        tmpDbText.Position = new Point3d(0, 0, 0);
        tmpDbText.Height = 10;
        tmpDbText.ColorIndex = 1;
        tmpDbText.Rotation = Math.PI / 4;
        // 4. 设置DBText对象的水平对齐方式和垂直对齐方式
        // 4. Set the horizontal and vertical alignment modes of the DBText object
        tmpDbText.HorizontalMode = TextHorizontalMode.TextCenter;
        tmpDbText.VerticalMode = TextVerticalMode.TextVerticalMid;
        // 5. 设置DBText对象的对齐点
        // 5. Set the alignment point of the DBText object
        tmpDbText.AlignmentPoint = new Point3d(0, 0, 0);
        // 6. 设置DBText的颜色
        // 6. Set the color of the DBText object
        tmpDbText.ColorIndex = 3;
        // 7. 将DBText对象添加到当前空间（模型空间或图纸空间）
        // 7. Add the DBText object to the current space (model space or paper space)
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
                txt.HorizontalMode = TextHorizontalMode.TextCenter;
                txt.VerticalMode = TextVerticalMode.TextVerticalMid;
                txt.AlignmentPoint = new Point3d(0, 0, 0);
            });
        // 3. 将DBText对象添加到当前空间（模型空间或图纸空间）
        // 3. Add the DBText object to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpDbText);
    }
}