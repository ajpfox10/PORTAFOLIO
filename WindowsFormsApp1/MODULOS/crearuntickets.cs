using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CrearTicket
    {
        public string Agentedeatencion { get; set; }
        public string Horadeatencion { get; set; }
        public string Motivodeconsulta { get; set; }
        public string Explicaciondada { get; set; }
        public string Agente { get; set; }
        private readonly PrintDocument doc = new PrintDocument();
        private readonly PrintPreviewDialog vista = new PrintPreviewDialog();
        public void Imprimir()
        {
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            doc.PrintPage += new PrintPageEventHandler(Imprimeticket);
            vista.Document = doc;
            vista.Show();
        }
        public void Imprimeticket(object sender, PrintPageEventArgs e)
        {
            int posX = 0;
            int posY = 0;
            Font fuente = new Font("consola", 8, FontStyle.Bold);
            int ticketAncho = e.PageBounds.Width; // Obtener el ancho máximo del ticket

            string agenteText = "Agente de Atención: " + Agentedeatencion;
            string horaText = "Hora de Atención: " + Horadeatencion;
            string consultaText = "Consulta";

            // Centrar "Consulta" debajo de "Hora de Atención"
            SizeF consultaSize = e.Graphics.MeasureString(consultaText, fuente);
            int consultaPosX = (ticketAncho - (int)consultaSize.Width) / 2;
            e.Graphics.DrawString(consultaText, fuente, Brushes.Black, consultaPosX, posY);
            posY += (int)fuente.GetHeight() + 5;

            // Mostrar "Agente de Atención" y "Hora de Atención"
            e.Graphics.DrawString(agenteText, fuente, Brushes.Black, posX, posY);
            posY += (int)fuente.GetHeight() + 5;
            e.Graphics.DrawString(horaText, fuente, Brushes.Black, posX, posY);
            posY += (int)fuente.GetHeight() + 10;
            // Calcular el ancho del campo para motivodeconsulta
            int campoAnchoMotivoConsulta = CalcularAnchoCampo(e.Graphics, fuente, Motivodeconsulta, ticketAncho);
            int campoAnchoExplicacionDada = CalcularAnchoCampo(e.Graphics, fuente, Explicaciondada, ticketAncho);
            // Mostrar el título "Motivo de Consulta"
            string tituloMotivoConsulta = "Motivo de Consulta:";
            e.Graphics.DrawString(tituloMotivoConsulta, fuente, Brushes.Black, posX, posY);
            posY += (int)fuente.GetHeight() + 5;
            // Mostrar el texto en el campo motivodeconsulta
            string[] lineasMotivoConsulta = WrapText(Motivodeconsulta, fuente, campoAnchoMotivoConsulta);
            foreach (string linea in lineasMotivoConsulta)
            {
                e.Graphics.DrawString(linea, fuente, Brushes.Black, posX, posY);
                posY += (int)fuente.GetHeight() + 12;
            }
            posY += 20; // Espaciado después del texto del motivo de consulta
            // Mostrar el título "Explicación Dada"
            string tituloExplicacionDada = "Explicación Dada:";
            e.Graphics.DrawString(tituloExplicacionDada, fuente, Brushes.Black, posX, posY);
            posY += (int)fuente.GetHeight() + 5;

            // Mostrar el texto de explicaciondada
            string[] lineasExplicacionDada = WrapText(Explicaciondada, fuente, campoAnchoExplicacionDada);
            foreach (string linea in lineasExplicacionDada)
            {
                e.Graphics.DrawString(linea, fuente, Brushes.Black, posX, posY);
                posY += (int)fuente.GetHeight() + 12;
            }
            posY += 30; // Espaciado después del texto de la explicación   
                        // Enviar el código de corte
            string codigoCorte = "\u000A\u000A\u000A\u000A\u000A\u001B" + "i" + "\u000A"; // \u000A representa el carácter ASCII 10 y \u001B representa el carácter ASCII 27
            e.Graphics.DrawString(codigoCorte, fuente, Brushes.Black, posX, posY);

        }
        private int CalcularAnchoCampo(Graphics graphics, Font font, string texto, int anchoMaximo)
        {
            // Calcular el ancho del texto
            SizeF textSize = graphics.MeasureString(texto, font);

            // Asegurarse de que el ancho no exceda el ancho máximo del ticket
            int campoAncho = (int)Math.Min(textSize.Width, anchoMaximo);

            return campoAncho;
        }
        private string[] WrapText(string text, Font font, int maxWidth)
        {
            List<string> lines = new List<string>();
            string[] paragraphs = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string paragraph in paragraphs)
            {
                string[] words = paragraph.Split(' ');
                StringBuilder currentLine = new StringBuilder();
                float currentWidth = 0;

                foreach (string word in words)
                {
                    SizeF wordSize = TextRenderer.MeasureText(word + " ", font); // Agregar un espacio después de cada palabra para calcular el ancho correctamente
                    float wordWidth = wordSize.Width;

                    if (currentWidth + wordWidth <= maxWidth)
                    {
                        if (currentLine.Length > 0)
                        {
                            currentLine.Append(" "); // Agregar espacio entre palabras
                            currentWidth += TextRenderer.MeasureText(" ", font).Width; // Ancho del espacio
                        }
                        currentLine.Append(word);
                        currentWidth += wordWidth;
                    }
                    else
                    {
                        lines.Add(currentLine.ToString());
                        currentLine.Clear();
                        currentLine.Append(word);
                        currentWidth = wordWidth;
                    }
                }

                if (currentLine.Length > 0)
                {
                    lines.Add(currentLine.ToString());
                }
            }

            return lines.ToArray();
        }
    
        private string[] SplitWord(string word, int maxWidth, Font font)
        {
            List<string> parts = new List<string>();
            StringBuilder currentPart = new StringBuilder();
            float currentWidth = 0;

            foreach (char c in word)
            {
                SizeF charSize = TextRenderer.MeasureText(c.ToString(), font);
                float charWidth = charSize.Width;

                if (currentWidth + charWidth <= maxWidth)
                {
                    currentPart.Append(c);
                    currentWidth += charWidth;
                }
                else
                {
                    parts.Add(currentPart.ToString());
                    currentPart.Clear();
                    currentPart.Append(c);
                    currentWidth = charWidth;
                }
            }

            if (currentPart.Length > 0)
            {
                parts.Add(currentPart.ToString());
            }

            return parts.ToArray();
        }
    }
}
