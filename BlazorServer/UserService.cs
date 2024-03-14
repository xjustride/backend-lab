namespace BlazorServer
{
    public class UserService
    {
        public List<(string connectionId, string username)> _users = new List<(string connectionId, string username)>();


        public void Add(string connectionId, string username)
        { 
            _users.Add((connectionId, username));

        }

        public void RemoveByName(string username)
        {
            _users.Remove((GetConnectionIdByName(username), username));
        }

        public string GetConnectionIdByName(string username)
        {
            return _users.FindLast(x => x.username == username).connectionId;
        }

        public IEnumerable<(string ConnectionId, string Username)> GetAll()
        {
            return _users;
        }
    }
}
