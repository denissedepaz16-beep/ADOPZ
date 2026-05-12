using ADOPZ.DataAccess.Interfaces;
using ADOPZ.Entities;
using Mapster;
using MediatR;

namespace ADOPZ .BusinessLogic.UseCases.Brands.Commads.CreateBrand;

internal sealed class CreateBrandHandler(IEfRepository<Brand> _repository) : IRequestHandler<CreateBrandCommand, int>
{
    public async Task<int> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newBrand = command.Request.Adapt<Brand>();

            var createBrand = await _repository.AddAsync(newBrand, cancellationToken);

            return createBrand.BrandId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
