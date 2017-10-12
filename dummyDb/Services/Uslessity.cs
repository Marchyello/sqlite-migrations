namespace dummyDb.Services
{
    public interface IUselessity
    {
        string Serve (string input);
    }

    public class Uselessity : IUselessity
    {
        public string Serve (string input)
        {
            return input + "_UselessityServedYou";
        }
    }
}