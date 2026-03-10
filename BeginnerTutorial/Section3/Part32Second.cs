namespace IFoxCADProgramming.Section3;

public class Part32Second
{
    [CommandMethod("TestIFoxCadapi")]
    public static void TestIFoxCadapi()
    {
        // 1. 向命令行输出文本，进行初步的用户交互
        // 1. Output text to the command line for initial user interaction
        Env.Printl("[中文]: 嗨，这是一个使用IFoxCAD的示例。");
        Env.Printl("[English]: Hello, This is a IFoxCAD example.");

        // 2. 开启事务，对数据库进行更改
        // 2. Start a transaction to modify the database
        using var tr = new DBTrans();
        // 3. 创建一个直线对象，并将其添加到数据库中
        // 3. Create a line object and add it to the database
        using var line = new Line(new Point3d(0, 0, 0), new Point3d(10, 10, 0));
        // 3. 将新直线添加到当前空间中
        // 3. Add the line object to the currentspace
        tr.CurrentSpace.AddEntity(line);

        // 4. 向命令行输出文本，表示直线已经成功添加到图形中
        // 4. Output text to the command line to indicate that the line has been successfully added to the drawing
        Env.Printl("[中文]: 直线已经成功添加到图形中。");
        Env.Printl("[English]: A line has been successfully added to the drawing.");
    }
}