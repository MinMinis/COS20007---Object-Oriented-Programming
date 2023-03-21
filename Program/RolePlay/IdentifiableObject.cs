namespace RolePlay
{
    public class IdentifiableObject
    {
        public List<string> _identifiers = new(); 
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string s in idents) 
            {
                _identifiers.Add(s.ToLower());
            }
        }
        public bool AreYou(string you)
        {
            foreach (string s in _identifiers) 
            {
                if (you.ToLower() == s) 
                {
                    return true; 
                }
            }
            return false;
        }
        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0) 
                {
                    return ""; 
                }
                return _identifiers[0]; 
            }
        }
        public void AddIdentifier(string item)
        {
            _identifiers.Add(item.ToLower());
        }
    }
}
