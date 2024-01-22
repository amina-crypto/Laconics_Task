using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laconics_Task.Model
{
    public class Customer
    {
        /*3 Create a Customer class with these properties:
         o Id
       o FirstName
        o LastName*/
        // Properties of class Customer
        [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
       
    }
}
