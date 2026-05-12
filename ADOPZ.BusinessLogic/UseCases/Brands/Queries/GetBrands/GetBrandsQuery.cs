using MediatR;

namespace ADOPZ.BusinessLogic.UseCases.Brands.Queries.GetBrands;

public record GetBrandsQuery() : IRequest<List<BrandResponse>>;
