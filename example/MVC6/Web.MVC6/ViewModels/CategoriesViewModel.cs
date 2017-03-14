namespace Web.MVC6.ViewModels
{
    using System.Collections.Generic;

    public class CategoriesViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
