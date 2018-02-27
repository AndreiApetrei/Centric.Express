using System;

namespace CentricExpress.Business.Domain
{
    public class Picture : Aggregate
    {
        public Picture(Guid id) :base(id)
        {
        }

        public Picture()
        {
        }

        public string Description { get; set; }

        public byte[] Content { get; set; }
    }
}