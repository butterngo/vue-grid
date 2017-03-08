namespace WebApi.Core
{
    using AutoMapper;
    using Domain;
    using Dto;

    public class CommonMapper: Profile
    {
        public CommonMapper()
        {
            #region Enity To Dto

            CreateMap<Categories, CategoriesDto>();

            CreateMap<CustomerCustomerDemo, CustomerCustomerDemoDto>();

            CreateMap<CustomerDemographics, CustomerDemographicsDto>();

            CreateMap<Customers, CustomersDto>();

            CreateMap<Employees, EmployeesDto>();

            CreateMap<EmployeeTerritories, EmployeeTerritoriesDto>();

            CreateMap<OrderDetails, OrderDetailsDto>();

            CreateMap<Orders, OrdersDto>();

            CreateMap<Products, ProductsDto>();

            CreateMap<Region, RegionDto>();

            CreateMap<Shippers, ShippersDto>();

            CreateMap<Suppliers, SuppliersDto>();

            CreateMap<Territories, TerritoriesDto>();
            #endregion

            #region Dto To Entity

            CreateMap<CategoriesDto, Categories>();

            CreateMap<CustomerCustomerDemoDto, CustomerCustomerDemo>();

            CreateMap<CustomerDemographicsDto, CustomerDemographics>();

            CreateMap<CustomersDto, Customers>();

            CreateMap<EmployeesDto, Employees>();

            CreateMap<EmployeeTerritoriesDto, EmployeeTerritories>();

            CreateMap<OrderDetailsDto, OrderDetails>();

            CreateMap<OrdersDto, Orders>();

            CreateMap<ProductsDto, Products>();

            CreateMap<RegionDto, Region>();

            CreateMap<ShippersDto, Shippers>();

            CreateMap<SuppliersDto, Suppliers>();

            CreateMap<TerritoriesDto, Territories>();

            #endregion
        }
    }
}
