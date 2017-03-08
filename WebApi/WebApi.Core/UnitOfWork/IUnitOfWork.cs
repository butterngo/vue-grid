namespace WebApi.Core
{
    using Repository;
    using System;
    using System.Threading.Tasks;
    using WebApi.Domain;

    public interface IUnitOfWork: IDisposable
    {
        IRepository<Categories> CategoriesRepository { get; }

        IRepository<CustomerCustomerDemo> CustomerCustomerDemoRepository { get; }

        IRepository<CustomerDemographics> CustomerDemographicsRepository { get; }

        IRepository<Customers> CustomersRepository { get; }

        IRepository<Employees> EmployeesRepository { get; }

        IRepository<EmployeeTerritories> EmployeeTerritoriesRepository { get; }

        IRepository<OrderDetails> OrderDetailsRepository { get; }

        IRepository<Orders> OrdersRepository { get; }

        IRepository<Products> ProductsRepository { get; }

        IRepository<Region> RegionRepository { get; }

        IRepository<Shippers> ShippersRepository { get; }

        IRepository<Suppliers> SuppliersRepository { get; }

        IRepository<Territories> TerritoriesRepository { get; }

        void Commit();

        Task CommitAsync();
    }
}
