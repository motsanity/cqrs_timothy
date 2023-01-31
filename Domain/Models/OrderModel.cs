using System.ComponentModel.DataAnnotations.Schema;
using webapi.Infrastructure.Database.Entities;

namespace webapi.Domain.Models
{
    public class OrderModel
    {
        public Guid CustomerId { get; set; }
        public Guid UserPrimaryID { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public Guid OrderId { get; internal set; }
    }
}

