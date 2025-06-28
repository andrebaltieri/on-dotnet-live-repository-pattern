using BaltaStore.Domain.Abstractions;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.GetById;

public sealed class Handler() : IRequestHandler<Command, Result<Response>>
{
    public Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}