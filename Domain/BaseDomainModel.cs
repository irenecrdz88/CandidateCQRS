namespace Domain
{

    public abstract class BaseDomainModel
    {


        public int Id { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
