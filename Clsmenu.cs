using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Examen1pro3.Clsempleado;
using static Examen1pro3.Clsmenu;

namespace Examen1pro3
{
    internal class Clsmenu
    {
       

        public class menu
        {
            
            private empleado[] empleados;
            private int contador;

            public menu(int capacidad)
            {
                empleados = new empleado[capacidad];
                for (int i = 0; i < capacidad; i++)
                {
                    empleados[i] = null;
                }
                contador = 0;
            }

            public void AgregarEmpleado()
            {
                // Agregar empleado
                if (contador >= empleados.Length)
                {
                    Console.WriteLine("No se pueden agregar más empleados. El arreglo está lleno.");
                    return;
                }

                Console.WriteLine("Ingrese el número de cédula del empleado:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del empleado:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la dirección del empleado:");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el teléfono del empleado:");
                string telefono = Console.ReadLine();

                Console.WriteLine("Ingrese el salario del empleado:");
                double salario = Convert.ToDouble(Console.ReadLine());

                empleado nuevoEmpleado = new empleado(cedula, nombre, direccion, telefono, salario);
                empleados[contador] = nuevoEmpleado;
                contador++;
            }

            public void ConsultarEmpleados()
            {
                // Consultar empleados
                Console.WriteLine("Ingrese el número de cédula del empleado que desea consultar:");
                string cedula = Console.ReadLine();

                for (int i = 0; i < contador; i++)
                {
                    if (empleados[i].Cedula == cedula)
                    {
                        Console.WriteLine($"Nombre: {empleados[i].Nombre}");
                        Console.WriteLine($"Dirección: {empleados[i].Direccion}");
                        Console.WriteLine($"Teléfono: {empleados[i].Telefono}");
                        Console.WriteLine($"Salario: {empleados[i].Salario}");
                        return;
                    }
                }

                Console.WriteLine("No se encontró un empleado con la cédula ingresada.");
            }

            public void ModificarEmpleados()
            {
                // Modificar empleados
                Console.WriteLine("Ingrese el número de cédula del empleado que desea modificar:");
                string cedula = Console.ReadLine();

                for (int i = 0; i < contador; i++)
                {
                    if (empleados[i].Cedula == cedula)
                    {
                        Console.WriteLine("Ingrese el nuevo nombre del empleado:");
                        empleados[i].Nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese la nueva dirección del empleado:");
                        empleados[i].Direccion = Console.ReadLine();

                        Console.WriteLine("Ingrese el nuevo teléfono del empleado:");
                        empleados[i].Telefono = Console.ReadLine();

                        Console.WriteLine("Ingrese el nuevo salario del empleado:");
                        empleados[i].Salario = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Empleado modificado exitosamente.");
                        return;
                    }
                }

                Console.WriteLine("No se encontró un empleado con la cédula ingresada.");
            }

            public void BorrarEmpleados()
            {
                // Borrar empleados
                Console.WriteLine("Ingrese el número de cédula del empleado que desea borrar:");
                string cedula = Console.ReadLine();

                for (int i = 0; i < contador; i++)
                {
                    if (empleados[i].Cedula == cedula)
                    {
                        // Mueve todos los empleados después del empleado a borrar una posición hacia atrás en el arreglo
                        for (int j = i; j < contador - 1; j++)
                        {
                            empleados[j] = empleados[j + 1];
                        }

                        // Disminuye el contador de empleados
                        contador--;

                        Console.WriteLine("Empleado borrado exitosamente.");
                        return;
                    }
                }

                Console.WriteLine("No se encontró un empleado con la cédula ingresada.");
            }

            public void InicializarArreglos()
            {
                //Inicializar arreglos
                //linea 22-30
            }

            public void Reportes()
            {
                //Generar reportes
                while (true)
                {
                    Console.WriteLine("Menú de Reportes:");
                    Console.WriteLine("1. Consultar empleados con número de cédula.");
                    Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
                    Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
                    Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo de todos los empleados.");
                    Console.WriteLine("5. Regresar al menú principal.");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el número de cédula del empleado que desea consultar:");
                            string cedula = Console.ReadLine();

                            for (int i = 0; i < contador; i++)
                            {
                                if (empleados[i].Cedula == cedula)
                                {
                                    Console.WriteLine($"Nombre: {empleados[i].Nombre}");
                                    Console.WriteLine($"Dirección: {empleados[i].Direccion}");
                                    Console.WriteLine($"Teléfono: {empleados[i].Telefono}");
                                    Console.WriteLine($"Salario: {empleados[i].Salario}");
                                    return;
                                }
                            }

                            Console.WriteLine("No se encontró un empleado con la cédula ingresada.");
                            break;
                        case 2:

                            if (contador == 0)
                            {
                                Console.WriteLine("No hay empleados en el sistema.");
                                return;
                            }

                            // Copia del arreglo de empleados para no modificar el original
                            empleado[] copiaEmpleados = new empleado[contador];
                            Array.Copy(empleados, copiaEmpleados, contador);

                            // Copia del arreglo de empleados por nombre
                            Array.Sort(copiaEmpleados, (emp1, emp2) => emp1.Nombre.CompareTo(emp2.Nombre));

                            // Muestra los empleados ordenados por nombre
                            for (int i = 0; i < contador; i++)
                            {
                                Console.WriteLine($"Cédula: {copiaEmpleados[i].Cedula}");
                                Console.WriteLine($"Nombre: {copiaEmpleados[i].Nombre}");
                                Console.WriteLine($"Dirección: {copiaEmpleados[i].Direccion}");
                                Console.WriteLine($"Teléfono: {copiaEmpleados[i].Telefono}");
                                Console.WriteLine($"Salario: {copiaEmpleados[i].Salario}");
                                Console.WriteLine();
                            }
                    

                    break;
                        case 3:
                            if (contador == 0)
                            {
                                Console.WriteLine("No hay empleados en el sistema.");
                                return;
                            }

                            double sumaSalarios = 0;
                            for (int i = 0; i < contador; i++)
                            {
                                sumaSalarios += empleados[i].Salario;
                            }

                            double promedioSalarios = sumaSalarios / contador;

                            Console.WriteLine($"El promedio de los salarios es: {promedioSalarios}");
                    

                    break;
                        case 4:
                            if (contador == 0)
                            {
                                Console.WriteLine("No hay empleados en el sistema.");
                                return;
                            }

                            double salarioAlto = empleados[0].Salario;
                            double salarioBajo = empleados[0].Salario;

                            for (int i = 1; i < contador; i++)
                            {
                                if (empleados[i].Salario > salarioAlto)
                                {
                                    salarioAlto = empleados[i].Salario;
                                }
                                if (empleados[i].Salario < salarioBajo)
                                {
                                    salarioBajo = empleados[i].Salario;
                                }
                            }

                            Console.WriteLine($"El salario más alto es: {salarioAlto}");
                            Console.WriteLine($"El salario más bajo es: {salarioBajo}");
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }

            public void MostrarMenu()
            {
                while (true)
                {
                    Console.WriteLine("*-*- Menú Principal:-*-*");
                    Console.WriteLine("1. Agregar Empleados");
                    Console.WriteLine("2. Consultar Empleados");
                    Console.WriteLine("3. Modificar Empleados");
                    Console.WriteLine("4. Borrar Empleados");
                    Console.WriteLine("5. Inicializar Arreglos");
                    Console.WriteLine("6. Reportes");
                    Console.WriteLine("7. Salir");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AgregarEmpleado();
                            break;
                        case 2:
                            ConsultarEmpleados();
                            break;
                        case 3:
                            ModificarEmpleados();
                            break;
                        case 4:
                            BorrarEmpleados();
                            break;
                        case 5:
                            InicializarArreglos();
                            break;
                        case 6:
                            Reportes();
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }
        }

    }
      
}
