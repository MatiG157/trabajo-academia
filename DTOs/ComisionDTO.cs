namespace DTOs
{
    public class ComisionDTO
    {
        public int IdComision { get; set; }
        public int AnioEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public int IdPlan { get; set; }
        public string Display => $"{Descripcion} (ID: {IdComision})";
    }
}