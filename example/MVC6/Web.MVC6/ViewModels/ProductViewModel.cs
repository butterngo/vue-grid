namespace Web.MVC6.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [StringLength(40)]
        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
