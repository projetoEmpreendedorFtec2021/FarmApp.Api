namespace FarmApp.Domain.Models.DTO
{
    public class EnderecoLatLongDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LatitudeDelta { get; set; }
        public string LongitudeDelta { get; set; }
        public bool IdTipoEndereco { get; set; }
        public string IdContaPessoal { get; set; }
    }
}
