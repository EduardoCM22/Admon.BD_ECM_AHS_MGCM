namespace Modelo
{
    public class Area
    {
        public int AreaID { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public Area(int idArea, string nombre, string ubicacion)
        {
            AreaID = idArea;
            Nombre = nombre;
            Ubicacion = ubicacion;
        }
    }
}
