namespace IFoxCADProgramming.Section4;

public class Part41
{
    [CommandMethod(nameof(AddLine))]
    public static void AddLine()
    {
        // 1. 向命令行输出文本，进行初步的用户交互
        // 1. Output text to the command line for initial user interaction
        Env.Printl("[中文]: 开始创建单条直线");
        Env.Printl("[English]: Start creating a single line");
        // 2. 使用using语句创建数据库事务对象
        // 2. Use using statement to create database transaction object
        using var tr = new DBTrans();
        // 3. 创建直线
        // 3. Create a line
        var line = new Line(new(0, 0, 0), new(1, 1, 0));
        // 4. 将直线添加到当前空间
        // 4. Add the line to the current space
        tr.CurrentSpace.AddEntity(line);
        // 5. 向命令行输出文本，表示直线已经成功添加到图形中
        // 5. Output text to the command line to indicate that the line has been successfully added to the drawing
        Env.Printl("[中文]: 直线已经成功添加到图形中。");
        Env.Printl("[English]: A line has been successfully added to the drawing.");
    }

    [CommandMethod(nameof(AddMutipleLine))]
    public static void AddMutipleLine()
    {
        // 1. 向命令行输出文本，进行初步的用户交互
        // 1. Output text to the command line for initial user interaction
        Env.Printl("[中文]: 开始创建多条直线");
        Env.Printl("[English]: Start creating multiple lines");
        // 1. 向命令行输出文本，进行初步的用户交互
        // 1. Output text to the command line for initial user interaction
        Env.Printl("[中文]: 嗨，这是一个使用IFoxCAD的示例。");
        Env.Printl("[English]: Hello, This is a IFoxCAD example.");
        // 1. 使用using语句创建数据库事务对象
        // 1. Use using statement to create database transaction object
        using var tr = new DBTrans();
        // 2.创建多条直线
        // 2. Create multiple lines
        var line1 = new Line(new Point3d(0, 0, 0), new Point3d(10, 0, 0));
        var line2 = new Line(new Point3d(0, 0, 0), new Point3d(0, 10, 0));
        var line3 = new Line(new Point3d(0, 0, 0), new Point3d(10, 10, 0));
        // 3. 将直线添加到当前空间
        // 3. Add the line to the current space
        tr.CurrentSpace.AddEntity(line1, line2, line3);
        // 4. 向命令行输出文本，表示多条直线已经成功添加到图形中
        // 4. Output text to the command line to indicate that multiple lines have been successfully added to the drawing
        Env.Printl("[中文]: 多条直线已经成功添加到图形中。");
        Env.Printl("[English]: Multiple lines have been successfully added to the drawing.");
    }
}