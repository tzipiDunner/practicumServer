using Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public enum EGender
    {
        MALE, FEMALE
    }
    public enum EHmo
    {
        CLALIT, MACCABI, MEUHEDET, LEUMIT
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public DateTime DOB { get; set; }
        public EGender Gender { get; set; }
        public EHmo HMO { get; set; }
        public List<Child>? Children { get; set; }
    }
}
