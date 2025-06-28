using BaltaStore.Domain.Abstractions;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.GetById;

public sealed record Query(Guid Id) : IRequest<Result<Response>>;