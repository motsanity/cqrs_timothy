using AutoMapper;
using webapi.AppService.DTOCartItem;
using webapi.CQRS.CommandCartItem;
using webapi.CQRS.ViewModels;
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Entities;


namespace webapi.AppService.Profiles
{
    public class CartItemProfile : Profile //added 5:21pm 1/24/2023
    {
        public CartItemProfile()
        {
            CreateMap<webapi.Domain.Models.CartItemModel, webapi.Infrastructure.Database.Entities.CartItem>();
            CreateMap<AddCartItemDTO, AddCartItemCommand>();
            CreateMap<AddCartItemCommand, CartItemModel>();
                //.ConstructUsing((s) => new CartItemModel(s.CartItemName, s.CustomerId, s.OrderId));

            CreateMap<CartItemModel, CartItemViewModel>();

            CreateMap<UpdateCartItemDTO, UpdateCartItemCommand>();

            



        }

        

    }
}
