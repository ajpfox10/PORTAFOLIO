using System;

public class CuilCuitGenerator
{
    private readonly string _genero;

    public CuilCuitGenerator(string genero)
    {
        if (genero != "Femenino" && genero != "Masculino")
        {
            throw new ArgumentException("El género debe ser 'Femenino' o 'Masculino'.");
        }
        _genero = genero;
    }

    public string GetCuilCuit(string numero_documento)
    {
        const string HOMBRE = "Masculino,M,MACHO";
        const string MUJER = "Femenino,F,FEMENINO";
        const string SOCIEDAD = "SOCIEDAD,S,SOCIEDAD";
        string AB, C;

        // Verificar que el número de documento tenga exactamente ocho números y que la cadena no contenga letras
        if (numero_documento.Length != 8 || !IsNumeric(numero_documento))
        {
            if (numero_documento.Length == 7 && IsNumeric(numero_documento))
            {
                numero_documento = "0" + numero_documento;
            }
            else
            {
                throw new ArgumentException("El número de documento ingresado no es correcto.");
            }
        }

        // Definir el valor del prefijo
        if (HOMBRE.Contains(_genero))
        {
            AB = "20";
        }
        else if (MUJER.Contains(_genero))
        {
            AB = "27";
        }
        else
        {
            AB = "30";
        }

        // Los números (excepto los dos primeros) que se deben multiplicar a la cadena formada por el prefijo y por el número de documento se almacenan en un arreglo.
        int[] multiplicadores = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };

        // Realizar las dos primeras multiplicaciones por separado.
        int calculo = int.Parse(AB.Substring(0, 1)) * 5 + int.Parse(AB.Substring(1, 1)) * 4;

        // Recorrer el arreglo y el número de documento para realizar las multiplicaciones.
        for (int i = 0; i < 8; i++)
        {
            calculo += int.Parse(numero_documento.Substring(i, 1)) * multiplicadores[i];
        }

        // Calcular el resto.
        int resto = calculo % 11;

        // Evaluar las condiciones para determinar el valor de C y conocer el valor definitivo de AB.
        if (!SOCIEDAD.Contains(_genero) && resto == 1)
        {
            if (HOMBRE.Contains(_genero))
            {
                C = "9";
            }
            else
            {
                C = "4";
            }
            AB = "23";
        }
        else if (resto == 0)
        {
            C = "0";
        }
        else
        {
            C = (11 - resto).ToString();
        }

        string cuil_cuit = $"{AB}-{numero_documento}-{C}";
        Console.WriteLine(cuil_cuit); // Mostrar ejemplo
        return cuil_cuit;
    }

    private bool IsNumeric(string value)
    {
        foreach (char c in value)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
}