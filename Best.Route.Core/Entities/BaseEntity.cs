using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Best.Route.Core.Entities;

[Index(nameof(Uid), IsUnique = true)]
[Index(nameof(Id), IsUnique = true)]
public class BaseEntity()
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    public bool Active { get; private set; } = true;
    public Guid Uid { get; private set; } = Guid.NewGuid();

}
