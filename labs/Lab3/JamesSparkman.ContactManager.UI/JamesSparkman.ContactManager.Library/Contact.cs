namespace JamesSparkman.ContactManager.Library
{
    public class Contact
    {
        // TODO add constructors
        public Contact ()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool IsFavorite { get; set; } = false;

    }
}