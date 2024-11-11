namespace WebStore.Models
{
    public class Pagination
    {
        public long TotalRecords { get; set; }
        public IEnumerable<dynamic> Records { get; set; }
    }
}
