﻿using System.Linq.Expressions;

namespace DAL.Interfaces;

public interface IGenericRepositories<TEntity> where TEntity : class
{
    TEntity Get(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    // This method was not in the videos, but I thought it would be useful to add.
    TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

    bool Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);

    bool Update(TEntity entity);
    bool Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

}