﻿using AutoMapper;
using webapi.AppService.DTOCartItem;
using webapi.CQRS.CommandCartItem;
using webapi.CQRS.ViewModels;
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Entities;


namespace webapi.AppService.Profiles
{
    public class OrderProfile : Profile //added 5:21pm 1/24/2023
    {
        public OrderProfile()
        {
          
            CreateMap<OrderModel, OrderViewModel>();

            //4:45pm 1/30/2023
            CreateMap<OrderModel, CartItem>();
            CreateMap<Order, CartItem>();
            CreateMap<Order, CartItemModel>();

            

        }
    }
}
