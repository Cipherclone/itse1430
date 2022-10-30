namespace JamesSparkman.ContactManager.Library // im on story 2 rn
{
    /// <summary>Represents a Contact</summary>
    public class Contact
    {
        // TODO add constructors
        public Contact ()
        {

        }

        /// <summary>Optional First Name</summary>
        public string FirstName 
        {
            get { return _firstName ?? ""; }
            set { _firstName = value?.Trim() ?? ""; }
        }
        private string _firstName;
        
        /// <summary>Required Last Name</summary>
        public string LastName 
        {
            get { return _lastName ?? ""; }
            set { _lastName = value?.Trim() ?? ""; } 
        }
        private string _lastName;

        /// <summary>Required and Unique E-Mail Address</summary>
        public string Email 
        {
            get { return _email ?? ""; } 
            set { _email = value?.Trim() ?? ""; }
        }
        private string _email;
        
        /// <summary>Optional Notes</summary>
        public string Notes 
        { 
            get { return _notes ?? ""; }
            set { _notes = value ?.Trim() ?? ""; } 
        }
        private string _notes;
        
        /// <summary>Bool Representing if a Contact is listed as a Favorite</summary>
        public bool IsFavorite { get; set; } = false;


        bool IsValidEmail(string source)
        {
            return true; // TODO this function
        }
    }
}