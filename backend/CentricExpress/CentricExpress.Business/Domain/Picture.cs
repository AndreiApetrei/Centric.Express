namespace CentricExpress.Business.Domain
{
    public class Picture : Aggregate
    {
        public string Description { get; set; }

        public byte[] Content { get; set; }
    }
}