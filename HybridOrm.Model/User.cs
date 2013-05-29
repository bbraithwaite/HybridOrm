using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridOrm.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
