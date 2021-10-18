﻿using Core.Seed;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
   public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIDAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> specification);

        Task <IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
    }
}