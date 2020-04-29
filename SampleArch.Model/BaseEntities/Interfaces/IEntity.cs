using System.ComponentModel.DataAnnotations;

namespace SampleArch.Model.BaseEntities.Interfaces
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
