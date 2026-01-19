namespace Hypesoft.Application.Products.Commands;

using MediatR;

public class DeleteProductCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;
}
