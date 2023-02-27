using MediatR;

namespace Store.Domain.Commands.Common
{
    public abstract class RequestCommand<TResult> : Command, IRequest<TResult>
    {
    }
}
