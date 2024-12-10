using Dapper;
using DapperContexts;

namespace Infrastructure;
using DapperContexts;
using Domains;
public class ClassService: IClassService
{  private readonly DapperContext _contexts;

    public ClassService()
    {
        _contexts = new DapperContext();
    }
    
    public void AddClass(Class1 class1)
    {
        string cmd = @"INSERT INTO Class ( class_name,subject_id,teacher_id,classroom_id,section,created_at,updated_at) VALUES ( @class_name,@subject_id,@teacher_id,@classroom_id,@section,@created_at,@updated_at)";
        int effect = _contexts.GetConnection().Execute(cmd);
        if (effect != 0)
        {
            Console.WriteLine("Class is already added");
        }
        else
        {
            Console.WriteLine("Error: Class is not added");
        }
    }

    public void DeleteClass(int id)
    {
        string cmd = @"DELETE FROM Class WHERE class_id=@id";
        int effect = _contexts.GetConnection().Execute(cmd);
        if (effect != 0)
        {
            Console.WriteLine("class is already deleted");
        }
        else
        {
            Console.WriteLine("Error: Class is not deleted");
        }
    }

    public Class1? GetClassById(int id)
    {
        string cmd = @"SELECT * FROM Class WHERE class_id=@id";
        Class1 class1 = _contexts.GetConnection().Query<Class1>(cmd, new { id = id }).FirstOrDefault();
        return class1;
        
    }

    public List<Class1> GetClasses()
    {
        string cmd = @"SELECT * FROM Class";
        List<Class1> classes = _contexts.GetConnection().Query<Class1>(cmd).ToList();
        return classes;
    }

    public void UpdateClass(Class1 class1)
    {
        string cmd = "Update Class set class_id=@class_id, class_name=@class_name,subject_id=@subject_id,teacher_id=@teacher_id,classroom_id=@classroom_id,section=@section,created_at=@created_at,updated_at = @updated_at ";
        int effect = _contexts.GetConnection().Execute(cmd);
        if (effect != 0)
        {
            Console.WriteLine("Class is already updated");
        }
        else
        {
            Console.WriteLine("Error: Class is not updated");
        }
        
    }
}