using System.Collections.Generic;
using System.Text;
using SampleArch.Model.BaseEntities.Interfaces;

namespace SampleArch.Model.BaseEntities.Abstracts
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        #region Implementation of IEntity<T>
        public virtual T Id { get; set; }
        #endregion
    }
}
