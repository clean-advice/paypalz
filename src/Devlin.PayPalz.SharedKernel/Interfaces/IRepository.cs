﻿using Ardalis.Specification;

namespace Devlin.PayPalz.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
