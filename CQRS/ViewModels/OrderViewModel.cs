
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Entities;

namespace webapi.CQRS.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserPrimaryId { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
