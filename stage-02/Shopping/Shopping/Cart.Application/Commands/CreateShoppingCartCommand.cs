using Cart.Application.Responses;
using Cart.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Commands
{
    public class CreateShoppingCartCommand : IRequest<ShoppingCartResponse>
    {
        public CreateShoppingCartCommand(string userName, List<ShoppingCartItem> items)
        {
            UserName = userName;
            Items = items;
        }
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
    }
}
