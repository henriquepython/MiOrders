namespace OrderService.Domain.Models
{
    public enum OrderStatus
    {
        Pending = 0,
        Completed = 1,
        Cancel = 2,
        RequestCancelled = 3,
    }
}