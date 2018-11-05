using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace Vaca
{
    public class Vaca
    {
        Queue Nom = new Queue();
        Queue Velocidad = new Queue(); //Se crea una cola
        int Time = 0; //Tiempo
        int Veces = 0; // Veces de recorrido

        public Vaca()//Constructor de lclase
        {
            //Inicializa los nombres y velocidades de las vacas
            Nom.Enqueue("Mazie");
            Nom.Enqueue("Daisy");
            Nom.Enqueue("Crazy");
            Nom.Enqueue("Lazy"); 
            Velocidad.Enqueue(2);
            Velocidad.Enqueue(4);
            Velocidad.Enqueue(10);
            Velocidad.Enqueue(20);
        }

        public void Avanzar()
        {

            Console.WriteLine("Bob lleva a las vacas {0} y {1}", Nom.ToArray().ElementAt(0), Nom.ToArray().ElementAt(1)); //Las dos primeras vacas
            Time = Time + Convert.ToInt32(Velocidad.ToArray().ElementAt(1)); 
            Console.WriteLine("Tiempo de recorrido: {0}", Time); //Despliega Time
            Veces = Veces + 1; //Veces del recorrido
            if (Time < 34) 
            {
                Regresar(); //Se manda a llamar el metodo Regresar
                if (Veces == 2)
                {
                    Velocidad.Dequeue(); //Cuando esté en el 2do recorrido, eliminará las vacas restantes y enviará Mazie y Daisy para que Daisy esté
                    Nom.Dequeue();     //En la segunda posición con indice 1 y se sume su tiempo como la vaca mas lenta
                    Nom.Enqueue("Mazie");
                    Velocidad.Enqueue(2);
                    Nom.Enqueue("Daisy");
                    Velocidad.Enqueue(4);
                }
                Avanzar(); //Se llama al metodo para seguir enviando las vacas
            }
        }

        public void Regresar()
        {
            Console.WriteLine("Bob regresa con la vaca: {0}", Nom.ToArray().ElementAt(Velocidad.ToArray().ToList().IndexOf(Velocidad.ToArray().Min()))); // Obtiene el indice de la vaca mas lenta y se le envie como indice para desplegar el nombre de esa vaca
            Time = Time + Convert.ToInt32(Velocidad.ToArray().Min()); 
            Console.WriteLine("Tiempo de recorrido: {0}", Time);//Despliega el time
            if (Veces == 1)
            {
                Nom.Enqueue("Daisy"); //Si es el primer recorrido se agrega Daisy pero tendrá el ultimo indice
                Velocidad.Enqueue(4);
            }
            Velocidad.Dequeue();
            Nom.Dequeue();  //Se eliminan de la cola
            Nom.Dequeue();
            Velocidad.Dequeue();
        }
    }
}
