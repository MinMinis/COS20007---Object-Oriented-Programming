using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration1
{
    public class Identifiable_Object
    {
        public List<string> _identifiers = new(); //  define _identifers 
        public Identifiable_Object(string[] idents) // create string array for idents 
        {
            _identifiers = new List<string>();
            foreach (string s in idents) //loop to find every elements in the idents
            {
                _identifiers.Add(s.ToLower()); // turn it into lower case and add to list _identifiers
            }
        }
        public bool AreYou(string you)
        {
            foreach (string s in _identifiers) //loop to assign every single elements in _identifiers to s
            {
                if (you.ToLower() == s) //check whenever you is a elements in _indetifiers or not
                {
                    return true; //if yes return true
                }
            }
            return false;
        }
        public string FirstId()
        {
            if (_identifiers.Count == 0) //count = length of array
            {
                return ""; // return emty string
            }
            return _identifiers[0]; //return the first element in the _identifiers array
        }
        public void AddIdentifier(string item)
        {
            _identifiers.Add(item.ToLower());
        }
        static void Main() { }
    }
}
