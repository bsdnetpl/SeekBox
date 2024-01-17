namespace SeekBox.Models
{
    public class StatusBox
    {
        public int Id { get; set; }
        public Guid boxGuid { get; set; }
        public DateTime DateTime { get; set; }
        public string EventName { get; set; }
        public int postalUnitId { get; set; }
    }
}
