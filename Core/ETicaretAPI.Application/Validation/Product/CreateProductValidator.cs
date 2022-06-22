using ETicaretAPI.Application.ViewModel.Products;
using FluentValidation;


namespace ETicaretAPI.Application.Validation.Product
{
    public class CreateProductValidator : AbstractValidator<VM_CreateProducts>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ürün ismi BOŞ geçilemez !").MaximumLength(150).MinimumLength(3).WithMessage("Ürün ismi 3 ile 150 karakter ARASINDA olmalıdır ! ");
            RuleFor(x => x.Stock).NotEmpty().NotNull().WithMessage("Stok adedi BOŞ geçilemez").Must(x => x >= 0).WithMessage("Stok adedi 0 dan BÜYÜK olmalıdır!");
            RuleFor(x => x.Stock).NotEmpty().NotNull().WithMessage("Fiyat değeri BOŞ geçilemez").Must(x => x >= 0).WithMessage("Fiyat değeri 0 dan BÜYÜK olmalıdır!");
        }
    }
}
