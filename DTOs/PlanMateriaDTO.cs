namespace DTOs
{
    public class PlanMateriaDTO
    {
        public int IdPlan { get; set; }
        public string PlanDescripcion { get; set; }
        public int IdMateria { get; set; }
        public string MateriaDescripcion { get; set; }
        public int HsSemanales { get; set; }
        public int HsTotales { get; set; }
    }
}