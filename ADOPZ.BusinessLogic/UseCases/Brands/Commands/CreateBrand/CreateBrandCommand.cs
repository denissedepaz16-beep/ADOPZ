using System;
using System.Collections.Generic;
using System.Text;

namespace ADOPZ.BusinessLogic.UseCases.Brands.Commands.Createcommand;

public record CreateBrandCommand(CreateBrandRequest Request) : IRequest<int>;


