using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public class DatosYAccionesLoader
{
    private readonly long Dni_;

    public DatosYAccionesLoader(long dni)
    {
        Dni_ = dni;
    }

    public void CargarDatosYAcciones(ListView listView, string consulta, string[] columnas)
    {
        listView.Items.Clear();
        listView.Columns.Clear();
        CARGARMESADEENTRADA cargador = new CARGARMESADEENTRADA();
        cargador.CargarDatos(listView, consulta, columnas);
    }
}
}




