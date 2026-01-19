namespace Hypesoft.Application.Categories.Commands;

using MediatR;

public class DeleteCategoryCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;
}
