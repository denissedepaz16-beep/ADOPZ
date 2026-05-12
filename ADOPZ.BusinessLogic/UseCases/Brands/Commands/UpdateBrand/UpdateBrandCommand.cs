using ADOPZ.BusinessLogic.DTOs;
using MediatR;

namespace ADOPZ.BusinessLogic.UseCases.Brands.Commands.UpdateBrand;

public record UpdateBrandCommand(UpdateBrandRequest Request) : IRequest<int>;
