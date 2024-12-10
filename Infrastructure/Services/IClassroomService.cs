namespace Infrastructure;
using Domains;
public interface IClassroomService
{
    public void AddClassroom(classroom classroom);
    public void DeleteClassroom(int id);
    public classroom GetClassroomById(int id);
    public List<classroom> GetClassrooms();
    public void UpdateClassroom(classroom classroom);
    
}