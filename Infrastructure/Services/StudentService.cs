using Dapper;
using DapperContexts;
using Npgsql;

namespace Infrastructure;
using Domains;



public class StudentService: IStudentService
{
    private readonly DapperContext _contexts;

    public StudentService()
    {
        _contexts = new DapperContext();
    }
    public void AddStudent(Student student)
    {
        try
        {
            string cmd = "insert into students (student_code,student_full_name,gender,dob,email,phone,school_id,stage,section,is_active,join_date,created_at,updated_at) values (@student_code,@student_full_name,@gender,@dob,@email,@phone,@school_id,@stage,@section,@is_active,@join_date,@created_at,@updated_at)";
            int effect = _contexts.GetConnection().Execute(cmd);
            if (effect != 0)
            {
                Console.WriteLine("Effect was successful");
            }
            else
            {
                Console.WriteLine("Effect was not successful");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdaetStudent(Student student)
    {
        string cmd = "Update students set student_code= @student_code,student_full_name = @student_full_name,gender = @gender,dob = @dob,email =@email,phone = @phone,school_id = @school_id,stage = @stage,section =@section,is_active =@is_active,join_date = @join_date,created_at=@created_at,updated_at=@updated_at where student_id = @id";
        int effect = _contexts.GetConnection().Execute(cmd,student);
        if (effect != 0)
        {
            Console.WriteLine("Update was successful");
        }
        else
        {
            Console.WriteLine(" Update was not successful");
        }
    }

    public void DeleteStudent(int id)
    {
        string cmd = "delete from students where student_id = @id";
        int effect = _contexts.GetConnection().Execute(cmd);
        if (effect != 0)

        {
            Console.WriteLine(" Delete was successful");
        }
        else
        {
            Console.WriteLine(" Delete was not successful");
        }
    }

    public void GetStudent()
    {
        string cmd = "select * from students";
        List<Student> students = _contexts.GetConnection().Query<Student>(cmd).ToList();
        foreach (var s in students)
        {
            Console.WriteLine($"student_code: {s.student_code}, student_full_name: {s.student_full_name} ,gender: {s.gender}, dob: {s.dob} ,email: {s.email} ,phone: {s.phone} ,school_id: {s.school_id} ,stage {s.stage} ,section : {s.section}, is_active: {s.is_active}, created_at : {s.created_at}, updated_at {s.updated_at}");
        }
    }
}