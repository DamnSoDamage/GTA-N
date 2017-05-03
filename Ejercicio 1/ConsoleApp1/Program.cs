using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 // Falta mejor nombre de namespace
{
    public abstract class Entidad // Excelente
    {
        public bool hecho = false; // ¿Esto es un atributo que se debe perpetuar para todas las entidades del juego?
        public abstract void limpieza(int numero); // No tienen que haber métodos dentro de la entidad, o tiene que haber los minimos e indispensables.
        public abstract bool limpio(); // Idem arriba

    }


	// Esto al escalarse complicará la lectura de todo el documento, es necesario crear otro archivo.
    class Controller<T>
    {
        public List<T> Lista { get; set; } // Investigar diferencia entre operador y atributo.
        public Controller()
        {
            Lista = new List<T>();
        }

        public void Agregar(T valor)
        {
            Lista.Add(valor);
        }

    }

	
    public class Usuario // Esto tendría que haber heredado Entidad, podría estar en otro archivo.
    {

        

    }

    //Vehiculo realmente no quiero que herede la clase abstracta, ya que debería de definir sus métodos y no los quiero. Crearía otra para vehículo.
    class Vehiculo : Entidad
    {

        public int z;
        public override void limpieza(int numero) // Acá hay un problema de rendimiento, si pones el while primero habrá una operación de más.
        {
            while (numero != 10)
            {
                if (numero != 10)
                {
                    numero++;

                }
            }
            if (numero == 10)
            {
                hecho = true;
            }
        }

        public override bool limpio() // Esto puede ser static.
        {
            return hecho;
        }



    }

	// Usuario/UsuarioController.cs
    class UsuarioController : Controller<Usuario> // Excelente, pero... ¿y los métodos para modificar los atributos de Usuario?
    {
        
    }
	
	// ¿Y VehiculoController?
	
    class Program // Esto está de más.
    {
        static void Main(string[] args)
        {
            Controller<int> MiLista = new Controller<int>();
            MiLista.Agregar(20);

            /* _______________________________ */
            Console.WriteLine("Se va a limpiar el coche");
            Vehiculo a = new Vehiculo();

            a.limpieza(0);


            if(a.limpio() == true)
            {
                Console.WriteLine("Limpio");
            }


            Console.ReadLine();


        }

    }

}