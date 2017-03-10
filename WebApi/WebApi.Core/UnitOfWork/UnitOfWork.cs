namespace WebApi.Core
{
    using System.Threading.Tasks;
    using Repository;
    using Domain;

    public class UnitOfWork : IUnitOfWork
    {
        private NORTHWNDContext _context;

        public ICategoryRepository CategoriesRepository { get; private set; }

        public IRepository<CustomerCustomerDemo> CustomerCustomerDemoRepository { get; private set; }

        public IRepository<CustomerDemographics> CustomerDemographicsRepository { get; private set; }

        public IRepository<Customers> CustomersRepository { get; private set; }

        public IRepository<Employees> EmployeesRepository { get; private set; }

        public IRepository<EmployeeTerritories> EmployeeTerritoriesRepository { get; private set; }

        public IRepository<OrderDetails> OrderDetailsRepository { get; private set; }

        public IRepository<Orders> OrdersRepository { get; private set; }

        public IRepository<Products> ProductsRepository { get; private set; }

        public IRepository<Region> RegionRepository { get; private set; }

        public IRepository<Shippers> ShippersRepository { get; private set; }

        public IRepository<Suppliers> SuppliersRepository { get; private set; }

        public IRepository<Territories> TerritoriesRepository { get; private set; }

        public UnitOfWork(NORTHWNDContext context)
        {
            _context = context;
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            CategoriesRepository = new CategoryRepository(_context);

            CustomerCustomerDemoRepository = new GenericRepository<CustomerCustomerDemo, NORTHWNDContext>(_context);

            CustomerDemographicsRepository = new GenericRepository<CustomerDemographics, NORTHWNDContext>(_context);

            CustomersRepository = new GenericRepository<Customers, NORTHWNDContext>(_context);

            EmployeesRepository = new GenericRepository<Employees, NORTHWNDContext>(_context);

            EmployeeTerritoriesRepository = new GenericRepository<EmployeeTerritories, NORTHWNDContext>(_context);

            OrderDetailsRepository = new GenericRepository<OrderDetails, NORTHWNDContext>(_context);

            OrdersRepository = new GenericRepository<Orders, NORTHWNDContext>(_context);

            ProductsRepository = new GenericRepository<Products, NORTHWNDContext>(_context);

            RegionRepository = new GenericRepository<Region, NORTHWNDContext>(_context);

            ShippersRepository = new GenericRepository<Shippers, NORTHWNDContext>(_context);

            SuppliersRepository = new GenericRepository<Suppliers, NORTHWNDContext>(_context);

            TerritoriesRepository = new GenericRepository<Territories, NORTHWNDContext>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            //TODO:
        }
    }
}
