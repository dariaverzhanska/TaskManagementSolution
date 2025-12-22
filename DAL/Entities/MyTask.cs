namespace DAL.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int AssignedTo { get; set; }
        public required string Status { get; set; }
    }
}
