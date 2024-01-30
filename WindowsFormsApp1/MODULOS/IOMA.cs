using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using System;
using System.IO;

namespace WindowsFormsApp1.MODULOS
{
    internal class IOMA
    {
        public void ProcesarDocumento(string rutaDocumento, string cadenaARemplazar, string cadenaReemplazo)
        {
            try
            {
                
                byte[] byteArray;

                // Crear una copia temporal en memoria
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (FileStream fileStream = new FileStream(rutaDocumento, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(memoryStream);
                    }
                    byteArray = memoryStream.ToArray();
                }

                // Abrir el documento desde la copia temporal en memoria
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    using (WordprocessingDocument doc = WordprocessingDocument.Open(ms, true))
                    {
                        Console.WriteLine("ABIERTO");

                        // Realizar el reemplazo en la copia temporal en memoria
                        TextReplacer.SearchAndReplace(wordDoc: doc, search: cadenaARemplazar, replace: cadenaReemplazo, matchCase: false);

                        Console.WriteLine("DOCUMENTO REMPLAZADO");

                    
                        doc.Save();
                    }

                    
                    string tempFilePath = Path.GetTempFileName();
                    using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create))
                    {
                        ms.Position = 0;
                        ms.CopyTo(fileStream);
                    }

                   
                    System.Diagnostics.Process.Start("WINWORD.EXE", tempFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar el documento: {ex.Message}");
            }
        }
        public void ProcesarDocumentoEnMemoria(MemoryStream memoryStream, string cadenaARemplazar, string cadenaReemplazo)
        {
            try
            {
                // Abrir el documento desde la copia temporal en memoria
                using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
                {
                    Console.WriteLine("Document opened successfully");

                    // Realizar el reemplazo en la copia temporal en memoria
                    TextReplacer.SearchAndReplace(wordDoc: doc, search: cadenaARemplazar, replace: cadenaReemplazo, matchCase: false);

                    Console.WriteLine("Search and replace completed");

                    // No es necesario guardar cambios aquí, ya que se está trabajando en la copia temporal en memoria
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar el documento: {ex.Message}");
            }
        }
    }
}
