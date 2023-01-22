namespace Rifa_On.Models
{
    public class Token
    {
        public string Value { get; }
        public int Id { get; set; }
        public Token(string value)
        {
            Value = value;
        }
    }
}
