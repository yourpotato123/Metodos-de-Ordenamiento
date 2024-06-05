using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_Ordenamiento_Int_64
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
            long[] numlea;                             //Declaro y creo el arreglo a rellenar
            numlea = new long[5000000];

            for (int i = 0; i < numlea.Length; i++)       //Inicializo un for para rellenar, que avanza hasta la cantidad de variables que tenga el arreglo
            {
                uint num1;
                num1 = (uint)aleatorio.Next();                // Genera dos números aleatorios de 32 bits sin signo
                //Console.WriteLine("Num1 {0}", num1);
                uint num2 = (uint)aleatorio.Next();       //u de unsigned = sin signo
                //Console.WriteLine("Num2: {0}", num2);
                numlea[i] = ((long)num1 << 32) | num2;    // Combina los dos números de 32 bits para formar un número de 64 bits
                                                          // << 32 mueve los datos a los 32 bits de la izquierda, |  lo une a  la  derecha
                //Console.WriteLine("Numlong: {0}",numlea[i]);
                

            };

            Stopwatch temporizador = new Stopwatch();  //Creo el temporizador con stopwatch  ya que no anda mi hora de compu
            temporizador.Start();                      //Inicializo le temporizador
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
        #region
        static void Ordenamiento(long[] array)         //Genero Metodo ordenamiento
        {
            int n = array.Length;                       //Una variable sea igual a la longitud del vector
            for (int i = 0; i < n - 1; i++)               //for desde i hasta n-1
            {
                int IndiceMinimo = i;                   //Se crea variable igual a la iteracion

                for (int j = i + 1; j < n; j++)           //for desde j hasta n
                {
                    if (array[j] < array[IndiceMinimo])  //Se compara si en el array j es menor a IndiceMinimo
                    {
                        IndiceMinimo = j;        //Dado verdad se reemplaza
                    }
                }
                // Intercambiar el elemento actual con el elemento más pequeño encontrado
                long temporal = array[IndiceMinimo];     //Genero variable temporal que guarde el valor mas tiquito
                array[IndiceMinimo] = array[i];          //Se mueve el elemento actual a la posicion del tiquito
                array[i] = temporal;                     //El tiquito guardado en temporal, se asigna donde estaba el elemento actual
                if (i % 25000 == 0)
                {
                    Console.WriteLine("Ordenados {0}", i);
                }
            }
            Console.WriteLine("Ordenados {0}", n);
        }
        #endregion
        #region
        /*static void Imprimir(long[] array)            //Metodo de Control si esta ordenando o no
        {
            int n = array.Length;                       //otra vez genero el paseador
            for (int i = 0; i < n; i++)                 //for de todos los elementos
            {
                Console.WriteLine("Elemento {0}: {1}", i+1, array[i]);      //Elemento i, con su valor correspondiente
            }
        }*/
        #endregion
    }
}
