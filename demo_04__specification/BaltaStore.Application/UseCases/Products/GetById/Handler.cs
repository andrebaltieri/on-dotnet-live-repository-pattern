using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Repositories;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.GetById;

public sealed class Handler(IProductRepository repository) : IRequestHandler<Query, Result<Response>>
{
    public Task<Result<Response>> Handle(Query query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}