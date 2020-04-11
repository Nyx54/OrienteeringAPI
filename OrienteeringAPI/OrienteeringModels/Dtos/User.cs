namespace OrienteeringModels.Dtos
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
