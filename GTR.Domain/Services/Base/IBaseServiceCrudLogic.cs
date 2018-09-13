using GTR.Domain.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTR.Domain.Services.Base
{
    public interface IBaseServiceCrudLogic<TEntity, TEntityKey>
    {
        TEntity Add(TEntity entity, User usuario);
        TEntity Add(TEntity entity, bool validate, User usuario);
        void Update(TEntity entity, User usuario);
        void Delete(TEntityKey entityId, User usuario);
        void Validate(TEntity entity, User usuario);
    }
}