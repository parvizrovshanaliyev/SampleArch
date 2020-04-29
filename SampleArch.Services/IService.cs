using System;
using System.Collections.Generic;
using System.Text;
using SampleArch.Model;
using SampleArch.Model.BaseEntities.Abstracts;
using SampleArch.Repository;
using SampleArch.Repository.Interfaces;

namespace SampleArch.Services
{
    public interface IService
    {
    }

    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }

    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }

    

   
}
