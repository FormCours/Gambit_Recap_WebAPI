namespace Gambit.API.Contracts.Intput
{
    public class LimitOffsetParameters
    {
        public int Limit { get; set; } = 25;
        public int Offset { get; set; } = 0;
    }
}
