namespace Sofis.Api.Domain.Entities
{
    public class Family : BaseEntity
    {
        public string SurName { get; set; } 

       public ICollection<Child> RelationedChildren { get; set; }
       public ICollection<Guardian> Guardians { get; set; }

        public Family() { }

        public Family(string surName)
        {
            Id = Guid.NewGuid();
            SurName = surName;
            //Name = name;
            //Kinship = kinship;
            //Phone = phone;
            //Cpf = cpf;
            //Email = email;
            //Address = address;
            CreatedAt = DateTime.UtcNow;
        }

        //public static implicit operator string(Family f)
        //{
        //    return f.Name;
        //}

    }
}
