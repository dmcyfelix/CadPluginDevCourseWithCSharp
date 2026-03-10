namespace IFoxCADProgramming.Section3;

public class Part32First
{
    [CommandMethod("TestNativeApi")]
    public static void TestNativeApi()
    {
        // 1. 获取当前活动文档、数据库和编辑器对象
        // 1. Get the current active document, database, and editor objects
        var doc = Acaop.DocumentManager.MdiActiveDocument;
        var db = doc.Database;
        var ed = doc.Editor;

        // 2. 向命令行输出文本，进行初步的用户交互
        // 2. Output text to the command line for initial user interaction
        ed.WriteMessage("\n[中文]: 嗨，这是一个C#和AutoCAD .NET API的示例。");
        ed.WriteMessage("\n[English]: Hello, This is a C# and AutoCAD .NET API example.");

        // 3. 开启事务，对数据库进行更改
        // 3. Start a transaction to modify the database
        using var tr = db.TransactionManager.StartTransaction();
        // 3.1 打开块表
        // 3.1 Open the block table
        var bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
        if (bt == null) return;
        // 3.2 打开模型空间块表记录
        // 3.2 Open the model space block table record
        var btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
        if (btr == null) return;
        // 3.3 创建一个直线对象
        // 3.3 Create a line object
        var line = new Line(new(0, 0, 0), new(1, 1, 0));
        // 3.4 将直线对象添加到块表记录中，并通知事务管理器
        // 3.4 Add the line object to the block table record and notify the transaction manager
        btr.AppendEntity(line);
        tr.AddNewlyCreatedDBObject(line, true);
        // 3.5 提交事务
        // 3.5 Commit the transaction
        tr.Commit();

        // 4. 向命令行输出文本，表示直线已经成功添加到图形中
        // 4. Output text to the command line to indicate that the line has been successfully added to the drawing
        ed.WriteMessage("\n[中文]: 直线已经成功添加到图形中。");
        ed.WriteMessage("\n[English]: A line has been successfully added to the drawing.");
    }
}