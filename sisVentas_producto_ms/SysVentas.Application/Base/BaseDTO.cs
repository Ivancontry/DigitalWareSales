using System.Collections.Generic;
using AutoMapper;
namespace SysVentas.Application.Base
{
    public abstract class BaseDTO
    {
    }
    public abstract class DTO<T,TEntity,TDTO> : BaseDTO, IDTO<T>
    {
        public virtual T Id { get; set; }
        private readonly IMapper mapper;
        protected DTO()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TDTO>().ReverseMap());
            mapper = config.CreateMapper();
            
        }
        public virtual TDTO ToDTO(TEntity entity)
        {
            return mapper.Map<TDTO>(entity);
        }
        public virtual TEntity ToEntity()
        {
            
            return mapper.Map<TEntity>(this);

        }

        public virtual List<TDTO> ToListDTO(List<TEntity> dTOs)
        {
            return mapper.Map<List<TDTO>>(dTOs);
        }
    }
}
