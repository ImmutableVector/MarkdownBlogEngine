using System;

namespace ProgrammingLexicon.Dal.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
