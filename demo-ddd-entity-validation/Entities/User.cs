namespace demo_ddd_entity_validation.Entities
{
    public class User
    {
        public string Id { get; protected set; }

        public string Email { get; protected set; }

        public string Name { get; protected set; }

        public int Age { get; protected set; }

        public static (User? user, IEnumerable<string> errors) Create(string email, string name, int age) 
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(email)) 
            {
                errors.Add("Email");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("Name");
            }

            if (age <= 0)
            {
                errors.Add("Age");
            }

            if (errors.Any()) 
            {
                return (null, errors);
            }

            return (
                new User(Guid.NewGuid().ToString(), email, name, age),
                Enumerable.Empty<string>()
                );
        }

        private User(string id, string email, string name, int age)
        {
            Id = id;
            Email = email;
            Name = name;
            Age = age;
        }
    }
}
