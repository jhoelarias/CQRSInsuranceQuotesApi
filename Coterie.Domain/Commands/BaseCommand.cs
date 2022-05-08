namespace Coterie.Domain.Commands
{
    using MediatR;

    public abstract class BaseCommand<T> : IRequest<T>
    {
    }
}