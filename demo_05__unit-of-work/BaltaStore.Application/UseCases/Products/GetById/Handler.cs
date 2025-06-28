using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Repositories;
using BaltaStore.Domain.Specifications.Products;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.GetById;

public sealed class Handler(IProductRepository repository) : IRequestHandler<Query, Result<Response>>
{
    public async Task<Result<Response>> Handle(Query query, CancellationToken cancellationToken)
    {
        var specification = new GetProductByIdSpecification(query.Id);
        var product = await repository.GetByIdAsync(specification, cancellationToken);
        return product is null
            ? Result.Failure<Response>(new Error("404", "Produto não encontrado"))
            : Result.Success<Response>(new Response(product.Id, product.Title));
    }
}