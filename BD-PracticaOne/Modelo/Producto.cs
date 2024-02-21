using System;
namespace Modelo
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; }
        public string ProductoSerie { get; set; }
        public string ProductoColor { get; set; }
        public DateTime ProductoFechaAd { get; set; }
        public string ProductoTipoAd { get; set; }
        public string ProductoArea { get; set; }
        public string ProductoObservaciones { get; set; }
        // Constructor
        public Producto(int productoID, string productoNombre, string productoDescripcion, string productoSerie,
                        string productoColor, DateTime productoFechaAd, string productoTipoAd, string productoArea,
                        string produtoObservaciones)
        {
            ProductoID = productoID;
            ProductoNombre = productoNombre;
            ProductoDescripcion = productoDescripcion;
            ProductoSerie = productoSerie;
            ProductoColor = productoColor;
            ProductoFechaAd = productoFechaAd;
            ProductoTipoAd = productoTipoAd;
            ProductoArea = productoArea;
            ProductoObservaciones = produtoObservaciones;
        }
        public Producto()
        {
            {
            }
        }
    }
}
