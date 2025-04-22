namespace jmailaT2S2A.Views;

public partial class vSistemas : ContentPage
{
	public vSistemas()
	{
        InitializeComponent();
    }

    private void btnEstudiantes_Clicked(object sender, EventArgs e)
    {
        string nombre = pkEstudiantes.SelectedItem?.ToString() ?? "Sin nombre";

        if (!double.TryParse(txtSeguimiento1.Text, out double s1) ||
            !double.TryParse(txtExamen1.Text, out double e1) ||
            !double.TryParse(txtSeguimiento2.Text, out double s2) ||
            !double.TryParse(txtExamen2.Text, out double e2))
        {
            DisplayAlert("Error", "Por favor ingresa todas las notas válidas entre 0 y 10", "OK");
            return;
        }

        if (s1 < 0 || s1 > 10 || e1 < 0 || e1 > 10 || s2 < 0 || s2 > 10 || e2 < 0 || e2 > 10)
        {
            DisplayAlert("Error", "Todas las notas deben estar entre 0 y 10", "OK");
            return;
        }
        double parcial1 = Math.Round((s1 * 0.3) + (e1 * 0.2), 2);
        double parcial2 = Math.Round((s2 * 0.3) + (e2 * 0.2), 2);
        double notaFinal = Math.Round(parcial1 + parcial2, 2);

        lblParcial1.Text = parcial1.ToString();
        lblParcial2.Text = parcial2.ToString();

        string estado;

        if (notaFinal >= 7)
            estado = "APROBADO";
        else if (notaFinal >= 5 && notaFinal < 7)
            estado = "COMPLEMENTARIO";
        else
            estado = "REPROBADO";

        string fecha = dtFecha.Date.ToString("dd/MM/yyyy");

        DisplayAlert("REPORTE DEL ESTUDIANTE",
            $"Nombre: {nombre}\n" +
            $"Fecha: {fecha}\n" +
            $"Nota Parcial 1: {parcial1}\n" +
            $"Nota Parcial 2: {parcial2}\n" +
            $"Nota Final: {notaFinal}\n" +
            $"Estado: {estado}", "Cerrar");

    }

}
