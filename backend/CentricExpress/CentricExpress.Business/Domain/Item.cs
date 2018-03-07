using System;

namespace CentricExpress.Business.Domain
{
    public class Item : Aggregate
    {
        public Item(Guid id)
        {
            this.Id = id;
        }
         
        private Item()
        {
            //orm
        }

        public string Description { get; set; }

        public Money Price { get; set; }

        public byte[] Picture { get; set; }
    }
}
