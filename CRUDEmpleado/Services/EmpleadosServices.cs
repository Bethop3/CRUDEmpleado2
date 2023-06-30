using CRUDEmpleado.Context;
using CRUDEmpleado.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUDEmpleado.Services
{
    internal class EmpleadosServices
    {
        public void Agregar(Empleado request)
        {
            try
            {
                using (var _Context = new ApplicationDbContext())
                {
                    Empleado res = new Empleado()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        FechaRegistro = DateTime.Now,
                        Correo = request.Correo
                    };
                    _Context.Empleados.Add(res);

                    _Context.SaveChanges();

                }

            }catch (Exception ex)
            {
                throw new Exception("Sucedio un error: "+ex);
            }
        }
        public Empleado? VerEmpleado ( int id )
        {
            try
            {
                using (var _Context = new ApplicationDbContext())
                {
                    Empleado empleado = _Context.Empleados.Where(empleado => empleado.PkEmpleado == id ).FirstOrDefault()!;
                    return empleado;
                }
            }
            catch
            {
                MessageBox.Show("Erro");
                return null;
            }
        }
    }
}
