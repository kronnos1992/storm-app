namespace Customer.domain.Interfaces;

public interface IDto<TEntity> where TEntity : IEntity
{
    void MapFromEntity(TEntity entity);
}

