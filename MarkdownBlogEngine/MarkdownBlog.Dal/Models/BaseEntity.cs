using System;

namespace ProgrammingLexicon.Dal.Models
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
