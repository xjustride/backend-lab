namespace BlazorServer
{
    public class UserService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>();
        public void Add(string connectionId, string username)
        { 
            _users.Add(connectionId, username);

        }

        public void RemoveByName(string username)
        {
            foreach (var (id, name) in _users) 
            {
                if(name == username)
                {
                    _users.Remove(id);
                }
            }
        }

        public string GetConnectionIdByName(string username)
        {
            string connectionId = string.Empty;
            return connectionId;
        }

        public IEnumerable<(string ConnectionId, string Username)> GetAll()
        {

        }
    }
}
