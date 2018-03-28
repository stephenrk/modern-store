using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandHandlers
{
    public class OrderHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        public void Handle(RegisterOrderCommand command)
        {
            var customer = customerRepository.Get(command.Customer);
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            foreach (var item in command.Items)
            {
                var product = productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }
        }
    }
}
