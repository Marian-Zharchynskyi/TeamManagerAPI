using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagerWeb.Core.Entities
{
    public class Language : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
/*        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
*/    
    }
}
