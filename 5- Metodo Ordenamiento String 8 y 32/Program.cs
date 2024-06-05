using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_Ordenamiento_String_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random aleatorio = new Random(10);         //Creo una instancia de la clase random
                                                       //al poner new Random (numero), se llama una semilla en especifico

            double tiempo = 0;                         //Declaro tiempo para devolver
            double hora = 0;
            double minutos = 0;
            double segundos = 0;
            double milisegundos = 0;
            double horat = 0;                          //Declaro tiempos truncados
            double minutot = 0;
            double segundot = 0;
            string[] numlea = new string[5000000];        //Declaro y creo el arreglo a rellenar

            GenerarCadenas(aleatorio, numlea, numlea.Length, 32);  // Lleno el arreglo con cadenas aleatorias de longitud 10

            Stopwatch temporizador = new Stopwatch();  //Creo el temporizador con stopwatch ya que no anda mi hora de compu
            temporizador.Start();                      //Inicializo el temporizador
            Console.WriteLine("Ordenamiento Empezado");
            Ordenamiento(numlea);
            Console.WriteLine("Ordenamiento Finalizado.");
            temporizador.Stop();                       //Finalizo el temporizador
            tiempo = (double)temporizador.ElapsedMilliseconds / 1000;     //paso a variable el tiempo transcurrido, Milisegundos/1000 = segundos,
            hora = (tiempo / 3600);                                     // segundos/3600 = horas
            horat = Math.Floor(hora);                                   // Trunco la hora
            minutos = (hora - horat) * 60;                                // Se quitan las horas y se multiplica por 60 para llevar a entero el minuto
            minutot = Math.Floor(minutos);                              // Trunco los minutos
            segundos = (minutos - minutot) * 60;                         // Quito minutos y multiplico por 60 para tener segundos
            segundot = Math.Floor(segundos);                            // Trunco segundos
            milisegundos = Math.Floor((segundos - segundot) * 1000);    // Quito segundos y multiplico por 1000 para tener milisegundos

            //Entrego el resultado
            Console.WriteLine("Tiempo de ejecución: {0} horas, {1} minutos, {2} segundos, {3} milisegundos",
            horat, minutot, segundot, milisegundos);

            //Console.WriteLine("Arreglo ordenado:");
            //Imprimir(numlea);
            Console.ReadKey();
        }

        #region Métodos auxiliares
        static void GenerarCadenas(Random numeros, string[] arreglo, int tamano, int longitud)
        {
            for (int i = 0; i < tamano; i++)
            {
                arreglo[i] = GenerarCadenaAleatoria(numeros, longitud);
                //Console.WriteLine(arreglo[i]);
            }
        }

        static string GenerarCadenaAleatoria(Random random, int longitud)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] cadena = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                cadena[i] = caracteres[random.Next(caracteres.Length)];
            }
            return new string(cadena);
        }

        static void Ordenamiento(string[] array)         //Genero Metodo ordenamiento
        {
            int n = array.Length;                        //Una variable sea igual a la longitud del vector
            for (int i = 0; i < n - 1; i++)              //for desde i hasta n-1
            {
                int IndiceMinimo = i;                    //Se crea variable igual a la iteracion

                for (int j = i + 1; j < n; j++)          //for desde j hasta n
                {
                    if (string.Compare(array[j], array[IndiceMinimo]) < 0)  //Se compara si en el array j es menor a IndiceMinimo
                    {
                        IndiceMinimo = j;        //Dado verdad se reemplaza
                    }
                }
                // Intercambiar el elemento actual con el elemento más pequeño encontrado
                string temporal = array[IndiceMinimo];     //Genero variable temporal que guarde el valor más pequeño
                array[IndiceMinimo] = array[i];         //Se mueve el elemento actual a la posición del más pequeño
                array[i] = temporal;                    //El más pequeño guardado en temporal, se asigna donde estaba el elemento actual
                if (i % 50 == 0)                       // Ajusto el valor de 25000 a 250 para que el mensaje se muestre más frecuentemente
                {
                    Console.WriteLine("Ordenados {0}", i);
                }
            }
            Console.WriteLine("Ordenados {0}", n);
        }
        #endregion
        #region
        /*static void Imprimir(string[] array)
        {
            int n = array.Length;                       //otra vez genero el paseador
            for (int i = 0; i < n; i++)                 //for de todos los elementos
            {
                Console.WriteLine("Elemento {0}: {1}", i + 1, array[i]);      //Elemento i, con su valor correspondiente
            }
        }*/
        #endregion
    }
}


