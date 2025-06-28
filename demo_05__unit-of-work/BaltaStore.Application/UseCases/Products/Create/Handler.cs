using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Entities;
using BaltaStore.Domain.Repositories;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.Create;

public class Handler() : IRequestHandler<Command, Result<Response>>
{
    public Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}