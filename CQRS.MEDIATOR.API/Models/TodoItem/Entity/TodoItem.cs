namespace CQRS.MEDIATOR.API.Models.TodoItem.Entity
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Rowguid { get; set; }
    }
}
