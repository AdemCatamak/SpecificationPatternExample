namespace SpecificationPatternExample.Data.Models
{
    public class UserModel
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public int Height { get; private set; }
        public int Age { get; private set; }

        public UserModel(string name, int height, int age)
            : this(default, name, height, age)
        {
        }

        public UserModel(long id, string name, int height, int age)
        {
            Id = id;
            Name = name;
            Height = height;
            Age = age;
        }
    }
}