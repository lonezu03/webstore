namespace WebStore.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int VariantId { get; set; }

        public Variant Variant { get; set; }
    }
}
