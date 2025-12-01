namespace MultiQuoteApi.Core.Models
{
    public class MenuScreenModel
    {   
        public MenuProductModel Product { get; set; }  
        public List<MenuComponentModel> Component { get; set; } = [];

    }
}
