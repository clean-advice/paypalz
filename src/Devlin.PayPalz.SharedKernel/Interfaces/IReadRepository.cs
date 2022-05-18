using Ardalis.Specification;

namespace Devlin.PayPalz.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
