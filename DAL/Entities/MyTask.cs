namespace DAL.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public string Status { get; set; }
    }
}
