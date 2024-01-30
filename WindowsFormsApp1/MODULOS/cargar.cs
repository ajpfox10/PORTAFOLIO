using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public class DatosYAccionesLoader
{
    private long _dni;

    public DatosYAccionesLoader(long dni)
    {
        _dni = dni;
    }

    public void CargarDatosYAcciones(ListView listView, string consulta, string[] columnas)
    {
        listView.Items.Clear();
        listView.Columns.Clear();

        CARGARMESADEENTRADA cargador = new CARGARMESADEENTRADA();
        cargador.CargarDatos(listView, consulta, columnas);

        // Realiza otras acciones relacionadas aquí
    }
}
}




