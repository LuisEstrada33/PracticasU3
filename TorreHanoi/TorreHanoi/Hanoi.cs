using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorreHanoi
{
    class Hanoi
    {
        Stack Torre1 = new Stack();
        Stack Torre2 = new Stack(); //Inicializa las pilas necesarias, una por cada torre
        Stack Torre3 = new Stack();
        int Moves = 0; //Cuenta el número de movimientos
        int Discos = 0; //Obtiene la cantidad de discos
        public Hanoi(int Cantidad) //Constructor que inicializa la cantidad de discos, llama al metodo para llenar la pila y al metodo recursivo para resolver las torres
        {
            Discos = Cantidad;
            LlenarPila();
            MoverTorres(Cantidad, "1", "3", "2");
            Console.WriteLine("Movimientos: " + Moves); //Despliega la cantidad total de movimientos realizados
        }

        private void MoverDiscos(string salida, string final)
        {
            if (salida == "1" && final == "2")
            {
                Console.WriteLine("Mover disco " + Torre1.Peek() + " de " + salida + " a " + final); //Si se mueve de 1 a 2, se muestra cual disco se mueve de 1 a 2
                Torre2.Push(Torre1.Pop());
            }
            else if (salida == "1" && final == "3")
            {
                Console.WriteLine("Mover disco " + Torre1.Peek() + " de " + salida + " a " + final); //Si se mueve de 1 a 3, se muestra cual disco se mueve de 1 a 3
                Torre3.Push(Torre1.Pop());
            }
            else if (salida == "2" && final == "1")
            {
                Console.WriteLine("Mover disco " + Torre2.Peek() + " de " + salida + " a " + final); //Si se mueve de 2 a 1, se muestra cual disco se mueve de 2 a 1
                Torre1.Push(Torre2.Pop());
            }
            else if (salida == "2" && final == "3")
            {
                Console.WriteLine("Mover disco " + Torre2.Peek() + " de " + salida + " a " + final); //Si se mueve de 2 a 3, se muestra cual disco se mueve de 2 a 3
                Torre3.Push(Torre2.Pop());
            }
            else if (salida == "3" && final == "1")
            {
                Console.WriteLine("Mover disco " + Torre3.Peek() + " de " + salida + " a " + final); //Si se mueve de 3 a 1, se muestra cual disco se mueve de 3 a 1
                Torre1.Push(Torre3.Pop());
            }
            else
            {
                Console.WriteLine("Mover disco " + Torre3.Peek() + " de " + salida + " a " + final); //Si se mueve de 3 a 2, se muestra cual disco se mueve de 3 a 2
                Torre2.Push(Torre3.Pop());
            }

        }

        public void MoverTorres(int cantidad, string salida, string final, string temporal)//Empieza el método recursivo, que pide como parametros
        {                                                               //Cantidad de discos, de donde va a salir la primera torre con (altura total -1), a que varilla se dirige y por donde van a pasar temporalmente los discos
            if (cantidad >= 1)//Mientras que la cantidad de discos o altura sean mayor que 1
            {
                MoverTorres(cantidad - 1, salida, temporal, final);//Reduce en 1 la altura de la torre origen, y envia el disco a la ubicación temporal
                Moves = Moves + 1;//Incrementa la cantidad de movimientos
                MoverDiscos(salida, final);//Llama al metodo MoverDiscos para que despliegue los movimientos realizados 
                Console.ReadKey();
                MoverTorres(cantidad - 1, temporal, final, salida);//Reduce en 1 la altura de la torre temporal, que es de donde sale el disco esta vez, y se envía a la torre destino
            }
        }

        private void LlenarPila()
        {
            for (int contador = Discos; contador > 0; contador--) //Llena la pila de modo que cuando se usen los peek y pop, los valores que salgan sean los primeros
            {
                Torre1.Push(contador);//De esta forma se ingresan los datos de tal forma que los valores mas bajos queden al final de la pila y sean los primeros en salir cuando se use peek y pop
            }
        }
    }
}
