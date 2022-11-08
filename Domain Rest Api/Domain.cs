namespace Domain_Rest_Api
{
    public class Domain
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = new Guid();
        public string DomainName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public DateTime TimeAdded { get; set; } = DateTime.Now;
        public DateTime TimeUpdated { get; set; } = DateTime.Now;
    }
}
