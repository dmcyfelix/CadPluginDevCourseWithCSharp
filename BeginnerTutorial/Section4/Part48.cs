namespace IFoxCADProgramming.Section4;

public class Part48
{
    [CommandMethod(nameof(AddMTextByNativeApi))]
    public static void AddMTextByNativeApi()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 创建一个MText对象
        // 2. Create an MText object
        var tmpMText = new MText();
        // 3. 设置MText对象的属性
        // 3. Set the properties of the MText object
        tmpMText.Contents = "这是多行文本的示例。多行文本可以自动换行，并且支持更丰富的格式控制，如字体、颜色和对齐方式。\n" +
                            "This is an example of MText, which supports automatic wrapping and rich formatting.";
        tmpMText.Location = new Point3d(0, 0, 0);
        tmpMText.Width = 50;
        tmpMText.TextHeight = 3;
        tmpMText.Attachment = AttachmentPoint.TopLeft;
        tmpMText.LineSpacingFactor = 1.5;
        tmpMText.ColorIndex = 3;
        tmpMText.Rotation = Math.PI / 4;
        // 4. 将MText对象添加到当前空间（模型空间或图纸空间）
        // 4. Add the MText object to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpMText);
    }

    [CommandMethod(nameof(AddMTextByCreateMText))]
    public static void AddMTextByCreateMText()
    {
        // 1. 使用using语句创建数据库事务对象，确保资源正确释放
        // 1. Use using statement to create database transaction object, ensuring proper resource disposal
        using var tr = new DBTrans();
        // 2. 使用IFoxCAD中MTextEx类的CreateMText创建一个MText对象
        // 2. Use the CreateMText method of the MTextEx class in IFoxCAD to create an MText object
        const string txtContent = "这是多行文本的示例。多行文本可以自动换行，并且支持更丰富的格式控制，如字体、颜色和对齐方式。\n" +
                                  "This is an example of MText, which supports automatic wrapping and rich formatting.";
        var tmpMText = MTextEx.CreateMText(new Point3d(0, 0, 0), txtContent,
            3,  null, mtxt =>
            {
                mtxt.Width = 50;
                mtxt.Attachment = AttachmentPoint.TopLeft;
                mtxt.LineSpacingFactor = 1.5;
                mtxt.ColorIndex = 3;
                mtxt.Rotation = Math.PI / 4;
            });
        // 3. 将DBText对象添加到当前空间（模型空间或图纸空间）
        // 3. Add the DBText object to the current space (model space or paper space)
        tr.CurrentSpace.AddEntity(tmpMText);
    }
}