using System.ComponentModel.DataAnnotations.Schema;

namespace WebMotors.Repository.Entity
{
    public class BaseEntity
    {
        [Column("ID")]
        public int Id { get; set; }
    }
}
