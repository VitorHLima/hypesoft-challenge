namespace Hypesoft.Application.Categories.Commands;

using MediatR;
using Hypesoft.Application.Common.DTOs;

public class CreateCategoryCommand : IRequest<CategoryDto>
{
    public string Name { get; set; } = string.Empty;
}
