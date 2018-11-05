using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
     class Listas
        {
            List<Tareas> Global = new List<Tareas>();
            List<Tareas> Pendiente = new List<Tareas>();  //Listas globales
            List<Tareas> Proceso = new List<Tareas>();
            List<Tareas> Terminada = new List<Tareas>();
            int id = 0;

            public void MostrarListas() //En este metodo dependiendo de la opción elegida es la lista que desplegará
            {
                int opcion = 0;
                Console.Write("Listas disponibles: \n1.- Global \n2.- Pendientes \n3.- En proceso \n4.- Terminadas \nSelección: "); //Menú
                opcion = Convert.ToInt32(Console.ReadLine()); 
                switch (opcion)
                {
                    case 1:
                        foreach (var item in Global)
                        {
                            Console.WriteLine("ID: " + item.Id);
                            Console.WriteLine("Nombre: " + item.Nombre); 
                            Console.WriteLine("Descripción: " + item.Descripcion);
                            Console.WriteLine("Fecha de inicio: " + item.Fecha_Inicio);
                            Console.WriteLine("Status: " + item.Estatus + "\n");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        foreach (var item in Pendiente)
                        {
                            Console.WriteLine("ID: " + item.Id);
                            Console.WriteLine("Nombre: " + item.Nombre); 
                            Console.WriteLine("Descripción: " + item.Descripcion);
                            Console.WriteLine("Fecha de inicio: " + item.Fecha_Inicio);
                            Console.WriteLine("Status: " + item.Estatus + "\n");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        foreach (var item in Proceso)
                        {
                            Console.WriteLine("ID: " + item.Id);
                            Console.WriteLine("Nombre: " + item.Nombre);
                            Console.WriteLine("Descripción: " + item.Descripcion);
                            Console.WriteLine("Fecha de inicio: " + item.Fecha_Inicio);
                            Console.WriteLine("Status: " + item.Estatus + "\n");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        foreach (var item in Terminada)
                        {
                            Console.WriteLine("ID: " + item.Id);
                            Console.WriteLine("Nombre: " + item.Nombre);
                            Console.WriteLine("Descripción: " + item.Descripcion);
                            Console.WriteLine("Fecha de inicio: " + item.Fecha_Inicio);
                            Console.WriteLine("Fecha de finalización: " + item.Fecha_Fin + "\n");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida"); //Opcion no valida
                
                        break;
                }
            }

            public void AgregarTarea(int opcion, int IDActual, string fecha)
            {
                Tareas NuevaTarea = new Tareas();

                switch (opcion)
                {
                    case 1:
                        id = id + 1; //if para saber si es nueva o solo editar
                        break;
                }

                NuevaTarea.Id = id;
                Console.Write("Ingrese el nombre de la tarea: ");
                NuevaTarea.Nombre = Console.ReadLine();
                Console.Write("Ingrese la descripción de la tarea: "); //Pide y lee los valores para la tarea
                NuevaTarea.Descripcion = Console.ReadLine();
                Console.Write("Ingrese la fecha de inicio: ");
                NuevaTarea.Fecha_Inicio = Console.ReadLine();
                NuevaTarea.Fecha_Fin = fecha;


                switch (opcion)
                {
                    case 1:
                        NuevaTarea.Estatus = "Pendiente"; //Si es 1 el valor de opción es una tarea nueva y se agrega a pendientes y global
                        Pendiente.Add(NuevaTarea);
                        Global.Add(NuevaTarea);
                        break;
                    case 2:
                        NuevaTarea.Estatus = "En proceso";
                        NuevaTarea.Id = IDActual; //Si el valor de opción es 2, la tarea se corrige y el ID no cambia, además se agrega a la lista de procesos y se cambia en la lista global
                        Proceso.Add(NuevaTarea);
                        Global.Add(NuevaTarea);
                        break;
                }

            }

            public void IniciarTarea() //Empieza una tarea y cambia el status de la tarea a "En Proceso" y a su vez se agrega en Global y si ya está en global se elimina y se agrega nuevamente con el status nuevo
            {
                int choose = 0;
                Console.WriteLine("Lista de tareas disponibles para iniciar: ");
                foreach (Tareas Tarea in Pendiente) //Muestra las tareas disponibles para iniciar
                {
                    Console.WriteLine("ID: " + Tarea.Id);
                    Console.WriteLine(Tarea.Nombre);
                    Console.WriteLine(Tarea.Descripcion + "\n");
                }
                Console.Write("Ingrese el id de la tarea a iniciar: "); //Pide el id y lo guarda en la variable elegir
                choose = Convert.ToInt32(Console.ReadLine());
                var seleccionada = (from search
                                    in Pendiente
                                    where choose == search.Id //Si el id elegido es igual a un id que haya en las tareas disponibles lo guarda en la lista con nombre "seleccionada"
                                    select search).ToList();

                foreach (var item in seleccionada) //Recorre la lista con los id iguales al elegido
                {
                    Global.Remove(item); //Elimina la tarea de global con el id elegido
                    item.Estatus = "En proceso"; //Se cambia el status de la tarea
                    Proceso.Add(item);//Se agrega a tareas en proceso el nuevo objeto, ahora con el status nuevo
                    Global.Add(item);//Se agrega la tarea modificada a global
                    Pendiente.Remove(item);//Se elimina de pendientes la tarea que se inicio
                }
                seleccionada.Clear();//Se limpia la lista para evitar duplicidad en las listas
            }

            public void TerminarTarea()
            {
                string fecha = "";
                int elegir = 0;
                Console.WriteLine("Lista de tareas disponibles para terminar: ");
                foreach (Tareas Tarea in Proceso) //Muestra las tareas disponibles en proceso
                {
                    Console.WriteLine("ID: " + Tarea.Id);
                    Console.WriteLine(Tarea.Nombre); //Muestra algunos datos de las tareas
                    Console.WriteLine(Tarea.Descripcion + "\n");
                }
                Console.Write("Ingrese el id de la tarea a terminar: "); //Pide el id y lo almacena
                elegir = Convert.ToInt32(Console.ReadLine());
                var seleccionada = (from search //Hace la busqueda de los id, si es igual al ingresado se guarda esa tarea
                                    in Proceso
                                    where elegir == search.Id
                                    select search).ToList();

                Console.Write("Ingrese fecha de finalización: ");//Pide la fecha de finalización y la guarda
                fecha = Console.ReadLine();

                foreach (var item in seleccionada)
                {
                    Global.Remove(item); //Elimina la tarea antigua de global para después guardarla con nuevo status
                    item.Estatus = "Terminada";//Cambia al nuevo status 
                    item.Fecha_Fin = fecha; //Guarda la fecha de finalización
                    Terminada.Add(item); //Agrega a la lista de terminadas la tarea con el id seleccionado
                    Global.Add(item); //Agrega a la lista global la tarea en cuestión
                    Proceso.Remove(item); //Elimina de la lista en proceso la tarea elegida
                }
                seleccionada.Clear();//Limpia la lista por si se termina otra tarea, no se agrege 2 veces en la lista de terminadas
            }

            public void CorregirTarea() //En este metodo es donde se realiza la corrección de una tarea
            {
                int choose = 0;
                Console.WriteLine("Lista de tareas disponibles para corregir: "); //Despliega la lista de tareas disponibles a corregir
                foreach (Tareas Tarea in Terminada)
                {
                    Console.WriteLine("ID: " + Tarea.Id);
                    Console.WriteLine(Tarea.Nombre);
                    Console.WriteLine(Tarea.Descripcion + "\n");
                }
                Console.Write("Ingrese el id de la tarea a corregir: "); //Pide el id y lo guarda para comparar después 
                choose = Convert.ToInt32(Console.ReadLine());
                var seleccionada = (from search
                                    in Terminada
                                    where choose == search.Id  //Realiza la busqueda de las tareas con el id seleccionado
                                    select search).ToList();

                foreach (var item in seleccionada)
                {
                    Global.Remove(item);//Elimina de la lista global la tarea que se va a corregir
                    Terminada.Remove(item);//Se elimina de terminadas la tarea seleccionada
                }
                Console.Clear(); //Se limpia la consola
                seleccionada.Clear(); //Se limpia la lista para evitar duplicidad en las listas
                AgregarTarea(2, choose, " --- ");//Se llama al metodo AgregarTarea, pero con parametros diferentes, 2 para que sea una corrección, elegir para mantener el ID actual y " --- " para indicar que no hay fecha de finalización aun
            }

            public void Menu()
            {
                int opcion = 0;
                do
                {
                    
                   
                        Console.Clear();//Limpia la consola para evitar despliegues innecesarios
                        Console.Write("Menú de opciones disponibles: \n1.- Agregar tarea nueva \n2.- Iniciar una tarea \n3.- Terminar una tarea \n4.- Corregir una tarea \n5.- Ver listas" +
                                 "\n6.- Salir del programa \nOpción: "); //Despliega las opciones disponibles del menú
                        opcion = Convert.ToInt32(Console.ReadLine());//Guarda el valor de la opcion

                        switch (opcion) //Depende de la opcion llama al metodo indicado
                        {
                            case 1:
                                AgregarTarea(opcion, 0, " --- "); //Se envía como parametro opcion, para que sea una tarea nueva, 0 porque no hay un id actual, " --- " porque no hay finalización aun
                                break;
                            case 2:
                                IniciarTarea(); //Llama al metodo iniciar tarea
                                break;
                            case 3:
                                TerminarTarea(); //Llama al metodo terminar tarea
                                break;
                            case 4:
                                CorregirTarea(); //Llama al metodo corregir tarea
                                break;
                            case 5:
                                MostrarListas(); //Llama al metodo mostrar listas
                                break;
                            case 6:
                                opcion = 9; //Termina el programa
                                break;
                            default:
                                Console.WriteLine("Opción no válida"); //En caso de que sea una opcion diferente
                                break;
                        }

                   
                } while (opcion != 9); //Mientras sea diferente de 9 seguirá corriendo el programa

            }
        }
}
