using System.Collections.Generic;

namespace Api.DataTransferObjects
{
    public class PersonDTO 
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<DocumentDTO> Documents { get; set; }
    }
}
