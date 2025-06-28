using BaltaStore.Domain.Abstractions;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.GetById;

public sealed record Command(Guid Id) : IRequest<Result<Response>>;