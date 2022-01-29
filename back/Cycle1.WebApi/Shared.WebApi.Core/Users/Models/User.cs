namespace A3.Shared.WebApi.Core.Users.Models
{
    public class User
    {
        public string Id { get; }

        public string Name { get; }

        public User(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
