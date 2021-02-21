using BikeStore.Core.DTOs;
using FluentValidation;

namespace BikeStore.Infrastructure.Validators
{
    public class ProductsValidator : AbstractValidator<ProductsDto>
    {
        public ProductsValidator()
        {
            RuleFor(products => products.ProductName)
                .NotNull()
                .Length(5, 200);
            RuleFor(products => products.ListPrice)
                .NotNull()
                .LessThan(1950).WithMessage("The Product Price Cannot be more than S/.1950");                                                
        }
    }
}
