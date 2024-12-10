namespace Infrastructure;
using Domains;

public interface  IStudentService
{
    public void AddStudent(Student student);
    public void UpdaetStudent(Student student);
    public void DeleteStudent(int id);
    public void GetStudent();
}