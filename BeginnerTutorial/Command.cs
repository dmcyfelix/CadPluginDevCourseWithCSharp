namespace IFoxCADProgramming;

public class Command
{
    [CommandMethod(nameof(HelloWorld))]
    public void HelloWorld()
    {
        using var tr = new DBTrans();
        Env.Editor.WriteMessage("hello world!");
        Env.Printl("开始画线：");
        Line line = new(new(0, 0, 0), new(1, 1, 0));
        tr.CurrentSpace.AddEntity(line);
        Env.Printl("画线结束");
        var tmpExtends = line.GeometricExtents;
        Env.Editor.ZoomWindow(tmpExtends.MinPoint, tmpExtends.MaxPoint);
    }

    

    
}