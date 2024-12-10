using Dapper;

namespace Infrastructure;
using Domains;
using DapperContexts;
public class ClassroomService : IClassroomService
{
    private readonly DapperContext _contexts;

    public ClassroomService()
    {
        _contexts = new DapperContext();
    }

    public void AddClassroom(classroom classroom)
    {
        string sql = @"INSERT INTO Classroom (capacity, room_type,description,created_at,updated_at) VALUES (@capacity, @room_type,@description,@created_at,@updated_at);";
        int effect = _contexts.GetConnection().Execute(sql,classroom);
        if (effect != 0)
        {
            Console.WriteLine("Classroom is  added");
        }
        else
        {
            Console.WriteLine("Classroom is  NOT added");
        }
    }

    public void DeleteClassroom(int id)
    {
        string sql = @"DELETE FROM Classroom WHERE classroom_id = @id;";
        int effect = _contexts.GetConnection().Execute(sql,new { id });
        if (effect != 0)
        {
            Console.WriteLine(" Classroom is  deleted");
        }
        else
        {
            Console.WriteLine(" Classroom is  NOT deleted");
        }
    }

    public classroom GetClassroomById(int id)
    {
        string sql = @"SELECT * FROM Classroom WHERE classroom_id = @id;";
        return _contexts.GetConnection().Query<classroom>(sql,new { id }).FirstOrDefault();
    }

    public List<classroom> GetClassrooms()
    {
        string sql = @"SELECT * FROM Classroom;";
        List<classroom> classrooms = _contexts.GetConnection().Query<classroom>(sql).ToList();
        return classrooms;
    }

    public void UpdateClassroom(classroom classroom)
    {
        string sql = "Update from classroms set capacity = @capacity,room_type  = @room_type, description = @description, updated_at = @updated_at where classroom_id = @id;";
        int effect = _contexts.GetConnection().Execute(sql,classroom);
        if (effect != 0)
        {
            Console.WriteLine("classroom is  updated");
        }
        else
        {
            Console.WriteLine("classroom is  NOT updated");
        }
    }   
}