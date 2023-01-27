namespace NullObjectPattern
{
    // Abstract Object
    public abstract class ProductBase
    {
        protected int rate;

        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void RateId(int rate);

        public static readonly ProductBase Null = new NullProduct();

        // Null Object
        private class NullProduct : ProductBase
        {
            public NullProduct()
            {
                Id = -1;
                Name = "Not Available";
            }

            public override void RateId(int rate)
            {
                // nic nie rób
            }
        }
    }
}
