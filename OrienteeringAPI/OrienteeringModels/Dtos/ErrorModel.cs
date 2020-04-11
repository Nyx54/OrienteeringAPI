namespace OrienteeringModels.Dtos
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsCustomException { get; set; }
    }
}
