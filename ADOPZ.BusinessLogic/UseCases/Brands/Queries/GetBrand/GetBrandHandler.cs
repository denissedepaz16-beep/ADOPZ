using ADOPZ.BusinessLogic.UseCases.Brands.Queries.GetBrand;
using ADOPZ.BusinessLogic.DTOs;
using ADOPZ.DataAccess.Interfaces;
using ADOPZ.Entities;
using Mapster;
using MediatR;

namespace ESFE.BusinessLogic.UseCases.Brands.Queries.GetBrand;

internal sealed class GetBrandHandler(IEfRepository<Brand> _repository) : IRequestHandler<GetBrandQuery, BrandResponse>
{
    public async Task<BrandResponse> Handle(GetBrandQuery query, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(query.brandId, cancellationToken);

        if (brand == null)
        {
            return new BrandResponse();
        }

        return brand.Adapt<BrandResponse>();
    }
}