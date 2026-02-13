using IFoxCAD.Cad.Assoc;

namespace IFoxCADProgramming.Section5;

public class Part54
{
    [CommandMethod(nameof(TestGetEntity))]
    public static void TestGetEntity()
    {
        var peo = new PromptEntityOptions("\n请选择一个圆(Please select a circle):");
        peo.SetRejectMessage("\n错误：选中的对象不是圆，请重新选择！(Error: The selected object is not a circle. Please select again.)");
        peo.AddAllowedClass(typeof(Circle), true);

        var per = Env.Editor.GetEntity(peo);
        if (per.Status == PromptStatus.OK)
        {
            using var tr = new DBTrans();
            var tmpCircle = tr.GetObject<Circle>(per.ObjectId, OpenMode.ForWrite);
            if (tmpCircle != null)
            {
                tmpCircle.ColorIndex = 2;
                Env.Printl($"圆的半径是(Radius of circle): {tmpCircle.Radius}");
            }
        }
    }

    [CommandMethod(nameof(TestGetNestedEntity))]
    public static void TestGetNestedEntity()
    {
        var pneo = new PromptNestedEntityOptions("\n请选择一个嵌套在块或参照中的实体(Select an entity nested in a block or xref): ");
        var pner = Env.Editor.GetNestedEntity(pneo);
        if (pner.Status != PromptStatus.OK) return;
        using var tr = new DBTrans();
        var tmpNestedEntity = tr.GetObject<Entity>(pner.ObjectId);
        if (tmpNestedEntity == null) return;
        var transform = pner.Transform;
        Env.Printl($"\n选中的实体类型(Selected entity type): {tmpNestedEntity.GetType().Name}");
        
        if (tmpNestedEntity is Line line)
        {
            // 将圆心点从块坐标系 (OCS) 转换为世界坐标系 (WCS)
            var wcsStartPoint = line.EndPoint.TransformBy(transform);
            Env.Printl($"\n嵌套直线的WCS起始坐标(the line startpoint): {wcsStartPoint.ToString()}");
            Env.Printl($"\n嵌套直线的长度(the length of line): {line.Length}");
        }
        else if (tmpNestedEntity is DBText dbText)
        {
            // 从块坐标系 (OCS) 转换为世界坐标系 (WCS)
            var wcsTextPosition = dbText.Position.TransformBy(transform);
            Env.Printl($"\n嵌套文字的WCS位置(Text Position): {wcsTextPosition.ToString()}");
            Env.Printl($"\n嵌套文字的内容(The content): {dbText.TextString}");
        }
    }

    [CommandMethod(nameof(TestGetAllSubentities))]
    public static void TestGetAllSubentities()
    {
        var peo = new PromptEntityOptions("\n请选择一条多段线(Please select a polyline):");
        peo.SetRejectMessage("\n错误：选中的对象不是多段线，请重新选择！(Error: The selected object is not a polyline. Please select again.)");
        peo.AddAllowedClass(typeof(Polyline), true);

        var per = Env.Editor.GetEntity(peo);
        if (per.Status != PromptStatus.OK) return;
        using var tr = new DBTrans();
        var tmpEnt = tr.GetObject<Polyline>(per.ObjectId);
        if (tmpEnt == null) return;
        var subEnts = tmpEnt.GetAllSubentities(SubentityType.Edge);
        Env.Printl($"{subEnts.Count}");
        foreach (var subEnt in subEnts)
        {
            if (subEnt is Line line)
            {
                Env.Printl($"{line.StartPoint.ToString()}:{line.EndPoint.ToString()}");
            }
        }
    }
}