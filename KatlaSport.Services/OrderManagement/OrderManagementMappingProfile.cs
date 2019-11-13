namespace KatlaSport.Services.OrderManagement
{
    using AutoMapper;
    using System;
    using DataAccessOrder = KatlaSport.DataAccess.OrderCatalogue.Order;
    using DataAccessDelivery = KatlaSport.DataAccess.OrderCatalogue.Delivery;
    using DataAccessClent = KatlaSport.DataAccess.OrderCatalogue.Client;
    using DataAccessEmployee = KatlaSport.DataAccess.OrderCatalogue.Employee;

    public sealed class OrderManagementMappingProfile : Profile
    {
        public OrderManagementMappingProfile()
        {
            CreateMap<DataAccessOrder, Order>();
            CreateMap<DataAccessClent, Client>();
            CreateMap<DataAccessEmployee, Employee>();
            CreateMap<DataAccessDelivery, Delivery>();
            CreateMap<UpdateDeliveryRequest, DataAccessDelivery>();
            CreateMap<UpdateClientRequest, DataAccessClent>();
            CreateMap<UpdateEmployeeRequest, DataAccessEmployee>();
            CreateMap<UpdateOrderRequest, DataAccessOrder>()
                .ForMember(r => r.DateAccommodation, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(r => r.DateDestination, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(r => r.DateExecution, opt => opt.MapFrom(p => DateTime.UtcNow));
        }
    }
}
