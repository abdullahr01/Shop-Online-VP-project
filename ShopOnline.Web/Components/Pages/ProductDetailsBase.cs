using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Diagnostics;

namespace ShopOnline.Web.Components.Pages
{
    public class ProductDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage {  get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CardItemToAddDto cartItemToAddDto)
        {
            try
            {
                Debug.WriteLine("AddToCart_Click method called");
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/ShoppingCart");
                Debug.WriteLine("Product added to cart");
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding product to cart: {ex.Message}");
                Debug.WriteLine("Product not added to cart");

                //Log Exception
            }
        }

    }
}
