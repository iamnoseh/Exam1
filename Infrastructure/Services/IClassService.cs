namespace Infrastructure;
using Domains;
public interface IClassService
{
    public void AddClass(Class1 class1);
        public void DeleteClass(int id);
        public Class1? GetClassById(int id);
        public List<Class1> GetClasses();
        public void UpdateClass(Class1 class1);
}