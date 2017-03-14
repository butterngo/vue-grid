namespace Web.MVC6.ViewModels
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
