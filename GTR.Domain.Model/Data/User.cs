using System.Globalization;

namespace GTR.Domain.Model.Data
{
    public class User
    {
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public CultureInfo Country { get; set; }
        public string Role { get; set; }
        public string Mail { get; set; }
        public string Franquicia { get; set; }
        public string NameRole { get; set; }
        public string Sid { get; set; }
        public string NameUserData { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsPowerUser { get; set; }
        public bool IsUserAllowed { get; set; }
        public byte IdIdioma { get; set; }
        public string FranquiciaFilter { get; set; }
        public string IP { get; set; }
    }
}
