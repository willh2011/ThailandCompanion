using Mapster;
using ThailandCompanion.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Entities.Common;

namespace ThailandCompanion.Api.Services.Common;

public abstract class BaseReadService<TEntity, TDto>
    where TEntity : class, IBaseEntity
    where TDto : class
{
    protected readonly IRepository<TEntity> Repository;

    protected BaseReadService(IRepository<TEntity> repository)
    {
        Repository = repository;
    }

    public virtual List<TDto> GetAll()
    {
        return Repository.Query()
            .ProjectToType<TDto>()
            .ToList();
    }

    public virtual TDto? GetById(int id)
    {
        return Repository.Query()
            .Where(e => e.Id == id)
            .ProjectToType<TDto>()
            .FirstOrDefault();
    }
}