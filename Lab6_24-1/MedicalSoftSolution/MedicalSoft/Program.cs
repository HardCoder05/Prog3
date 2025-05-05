using MedicalSoftController.Infra.DAO;
using MedicalSoftController.Infra.Impl;
using MedicalSoftModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int resultado = 0;
            
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("SISTEMA DE GESTION DE SALAS ESPECIALIZADAS");
                System.Console.WriteLine("---------------------------------------------------");
                System.Console.WriteLine("1. Registrar nueva sala especializada.");
                System.Console.WriteLine("2. Listar todas las salas especializadas.");
                System.Console.WriteLine("3. Obtener los datos de una sala especializada por id.");
                System.Console.WriteLine("4. Eliminar una sala especializada.");
                System.Console.WriteLine("5. Modificar una sala especializada.");
                System.Console.WriteLine("6. Salir del sistema de gestion.");
                System.Console.Write("Ingrese su opcion: ");
                resultado = Int32.Parse(System.Console.ReadLine());
                if (resultado == 1)
                {
                    SalaEspecializada sala = new SalaEspecializada();
                    sala = solicitarDatosRegistro();
                    
                    SalaEspecializadaDAO salaDAO = new SalaEspecializadaImpl();
                    int idSala = salaDAO.insertar(sala);
                    System.Console.WriteLine("Se registro la sala especializada con id: " + idSala);
                }
                else if (resultado == 2)
                {
                    SalaEspecializadaDAO salaDAO = new SalaEspecializadaImpl();
                    BindingList<SalaEspecializada> listaSalas = salaDAO.listarTodos();
                    System.Console.WriteLine("Lista de salas especializadas: ");
                    foreach (SalaEspecializada sala in listaSalas)
                    {
                        sala.mostrarDatos();
                    }
                }
                else if (resultado == 3)
                {
                    System.Console.WriteLine("Ingrese el id de la sala cuyos datos desea visualizar: ");
                    int idSala = Int32.Parse(System.Console.ReadLine());
                    SalaEspecializadaDAO salaDAO = new SalaEspecializadaImpl();
                    SalaEspecializada sala = salaDAO.obtenerPorId(idSala);
                    if (sala != null)
                    {
                        sala.mostrarDatos();
                    }
                    else
                    {
                        System.Console.WriteLine("No se encontro la sala especializada con id: " + idSala);
                    }
                }
                else if (resultado == 4)
                {
                    System.Console.WriteLine("Ingrese el id de la sala especializada a eliminar: ");
                    int idSala = Int32.Parse(System.Console.ReadLine());
                    SalaEspecializadaDAO salaDAO = new SalaEspecializadaImpl();
                    salaDAO.eliminar(idSala);
                    System.Console.WriteLine("Se elimino la sala especializada con id: " + idSala);
                }
                else if (resultado == 5)
                {
                    SalaEspecializada sala = new SalaEspecializada();
                    System.Console.WriteLine("Ingrese el id de la sala especializada a modificar: ");
                    int idSala = Int32.Parse(System.Console.ReadLine());
                    sala = solicitarDatosModificar(idSala);
                    SalaEspecializadaDAO salaDAO = new SalaEspecializadaImpl();
                    salaDAO.modificar(sala);
                    System.Console.WriteLine("Se modifico la sala especializada con id: " + idSala);
                }
                else
                {
                    System.Console.WriteLine("Ingrese una opcion valida");
                }
            } while (resultado != 6);
        }

        public static SalaEspecializada solicitarDatosRegistro()
        {
            SalaEspecializada sala = new SalaEspecializada();

            System.Console.WriteLine("Ingrese el nombre de la sala especializada: ");
            sala.Nombre = System.Console.ReadLine();

            System.Console.WriteLine("Ingrese el espacio en metros cuadrados: ");
            sala.EspacioMetrosCuadrados = Double.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Ingrese la torre donde esta ubicada la sala: ");
            sala.Torre = char.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Ingrese el piso donde esta ubicada la sala: ");
            sala.Piso = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Ingrese el tipo de sala [1.UCI - 2.CIRUGIA - 3.EMERGENCIA]: ");
            string tipoSala = System.Console.ReadLine();
            int tipoSalaInt = Int32.Parse(tipoSala);

            if (tipoSalaInt == 1)
            {
                sala.TipoSala = TipoSala.UCI;
            }
            else if (tipoSalaInt == 2)
            {
                sala.TipoSala = TipoSala.CIRUGIA;
            }
            else if (tipoSalaInt == 3)
            {
                sala.TipoSala = TipoSala.EMERGENCIA;
            }

            System.Console.WriteLine("Posee equipamiento de imagenologia? [1.S - 2.N]: ");
            string respuesta = System.Console.ReadLine();

            if (respuesta.Equals("S"))
            {
                sala.PoseeEquipamientoImagenologia = true;
            }
            else if (respuesta.Equals("N"))
            {
                sala.PoseeEquipamientoImagenologia = false;
            }

            return sala;
        }
        
        
        public static SalaEspecializada solicitarDatosModificar(int idSalaEspecializada)
        {
            SalaEspecializada sala = new SalaEspecializada();
            //recuperar la sala especializada por id
            SalaEspecializadaDAO salaDAO = new SalaEspecializadaImpl();

            sala = salaDAO.obtenerPorId(idSalaEspecializada);

            //modificar los datos de la sala especializada
            System.Console.WriteLine("Si desea mantener el valor actual, presione ENTER");
            
            System.Console.Write("Ingrese el nombre de la sala especializada (VALOR ACTUAL: " );
            System.Console.WriteLine(sala.Nombre + "): ");
            //ahora leo el nombre o presiono enter
            string nombre = System.Console.ReadLine();
            if (!nombre.Equals(""))
            {
                sala.Nombre = nombre;
            }
            
            System.Console.Write("Ingrese el espacio en metros cuadrados (VALOR ACTUAL: ");
            System.Console.WriteLine(sala.EspacioMetrosCuadrados + "): ");
            //ahora leo el espacio o presiono enter
            string espacio = System.Console.ReadLine();
            if (!espacio.Equals(""))
            {
                sala.EspacioMetrosCuadrados = Double.Parse(espacio);
            }
            
            System.Console.Write("Ingrese la torre donde esta ubicada la sala (VALOR ACTUAL: ");
            System.Console.WriteLine(sala.Torre + "): ");
            //ahora leo la torre o presiono enter
            string torre = System.Console.ReadLine();
            if (!torre.Equals(""))
            {
                sala.Torre = char.Parse(torre);
            }
            
            System.Console.Write("Ingrese el piso donde esta ubicada la sala (VALOR ACTUAL: ");
            System.Console.WriteLine(sala.Piso + "): ");
            //ahora leo el piso o presiono enter
            string piso = System.Console.ReadLine();
            if (!piso.Equals(""))
            {
                sala.Piso = Int32.Parse(piso);
            }
            
            System.Console.Write("Ingrese el tipo de sala [1.UCI - 2.CIRUGIA - 3.EMERGENCIA] (VALOR ACTUAL: ");
            System.Console.WriteLine(sala.TipoSala.ToString() + "): ");
            //ahora leo el tipo de sala o presiono enter
            string tipoSala = System.Console.ReadLine();
            if (!tipoSala.Equals(""))
            {
                int tipoSalaInt = Int32.Parse(tipoSala);
                if (tipoSalaInt == 1)
                {
                    sala.TipoSala = TipoSala.UCI;
                }
                else if (tipoSalaInt == 2)
                {
                    sala.TipoSala = TipoSala.CIRUGIA;
                }
                else if (tipoSalaInt == 3)
                {
                    sala.TipoSala = TipoSala.EMERGENCIA;
                }
            }
            
            System.Console.Write("Posee equipamiento de imagenologia? [1.S - 2.N] (VALOR ACTUAL: ");
            System.Console.WriteLine((sala.PoseeEquipamientoImagenologia ? "SI" : "NO") + "): ");
            //ahora leo la respuesta o presiono enter
            string respuesta = System.Console.ReadLine();
            if (!respuesta.Equals(""))
            {
                if (respuesta.Equals("S"))
                {
                    sala.PoseeEquipamientoImagenologia = true;
                }
                else if (respuesta.Equals("N"))
                {
                    sala.PoseeEquipamientoImagenologia = false;
                }
            }

            return sala;
        }
    }
}
