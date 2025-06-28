using BaltaStore.Domain.Abstractions;
using MediatR;

namespace BaltaStore.Application.UseCases.Products.Create;

public sealed record Command(string Title) : IRequest<Result<Response>>;