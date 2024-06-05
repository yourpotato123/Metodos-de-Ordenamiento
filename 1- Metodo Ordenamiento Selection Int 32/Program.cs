using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;                               // Diagnostics te deja utilizar  el  metodo stopwatch

namespace Metodo_Seleccion
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
            int[] numlea;                              //Declaro y creo el arreglo a rellenar
            numlea = new int[10];
            //int[] numleas;
            //numleas = new int[10];
            for (int i = 0; i < numlea.Length; i++)       //Inicializo un for para rellenar, que avanza hasta la cantidad de variables
            {                                             //que tenga mi arreglo
                numlea[i] = aleatorio.Next(100);             //Array [iteracion] = Instancia random. Metodo random a llamar
                                                             //Array.Next(numero) genera de 0 a numero 

                //Console.WriteLine("Vector 1: Elemento {0}: {1}", i + 1, numlea[i]);
            };

            /*for (int i = 0; i < numlea.Length; i++)       //Inicializo un for para rellenar, que avanza hasta la cantidad de variables
            {                                             //que tenga mi arreglo
                numleas[i] = aleatorio.Next(100);             //Array [iteracion] = Instancia random. Metodo random a llamar
                                                              //Array.Next(numero) genera de 0 a numero 

                Console.WriteLine("Vector 2: Elemento {0}: {1}", i + 1, numlea[i]);
            };
            Console.ReadKey();*/
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
        static void Ordenamiento(int[] array)         //Genero Metodo ordenamiento
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
                int temporal = array[IndiceMinimo];     //Genero variable temporal que guarde el valor mas tiquito
                array[IndiceMinimo] = array[i];         //Se mueve el elemento actual a la posicion del tiquito
                array[i] = temporal;                    //El tiquito guardado en temporal, se asigna donde estaba el elemento actual
                if (i % 25000 == 0)
                {
                    Console.WriteLine("Ordenados {0}", i);
                }
            }
            Console.WriteLine("Ordenados {0}", n);
        }
        #endregion
            
            #region
            /*static void Imprimir(int[] array)
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
