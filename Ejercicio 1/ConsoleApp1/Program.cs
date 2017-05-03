using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Entidad
    {
        public bool hecho = false;
        public abstract void limpieza(int numero);
        public abstract bool limpio();

    }



    class Controller<T>
    {
        public List<T> Lista { get; set; }
        public Controller()
        {
            Lista = new List<T>();
        }

        public void Agregar(T valor)
        {
            Lista.Add(valor);
        }

    }


    public class Usuario 
    {

        

    }

    //Vehiculo realmente no quiero que herede la clase abstracta, ya que debería de definir sus métodos y no los quiero. Crearía otra para vehículo.
    class Vehiculo : Entidad
    {

        public int z;
        public override void limpieza(int numero)
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

        public override bool limpio()
        {
            return hecho;
        }



    }


    class UsuarioController : Controller<Usuario>
    {
        
    }

    class Program
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