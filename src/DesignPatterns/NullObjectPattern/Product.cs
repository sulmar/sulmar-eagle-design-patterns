namespace NullObjectPattern
{
    // Real Object
    public class Product : ProductBase 
    {        
        public override void RateId(int rate)
        {
            this.rate = rate;
        }

    }
}
