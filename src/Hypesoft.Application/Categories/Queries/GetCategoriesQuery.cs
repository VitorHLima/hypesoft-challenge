namespace Hypesoft.Application.Categories.Queries;

using MediatR;
using Hypesoft.Application.Common.DTOs;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}
