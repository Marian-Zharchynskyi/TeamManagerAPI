using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagerWeb.Core.Entities
{
    public class Language 
    {
        public int Id { get; set; }
        public string Name { get; set; }
/*        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
*/    
    }
}
