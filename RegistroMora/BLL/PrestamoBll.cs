using Microsoft.EntityFrameworkCore;
using RegistroMora.DAL;
using RegistroMora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroMora.BLL
{
    public class PrestamoBLL
    {
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
            {
                return Insertar(prestamos);
            }
            else
            {
                return Modificar(prestamos);
            }


        }


      

        private static bool Insertar(Prestamos prestamos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                prestamos.Balance = prestamos.Monto;
                GuardarBalance(prestamos);
                db.Prestamos.Add(prestamos);
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Prestamos prestamos)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {

                prestamos.Balance = prestamos.Monto;
                ModificarBalance(prestamos);
                db.Entry(prestamos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var prestamos = db.Prestamos.Find(id);
                

                if (prestamos != null)
                {
                    EliminarBalance(prestamos);

                    db.Prestamos.Remove(prestamos);

                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> prestamos)
        {
            List<Prestamos> Lista = new List<Prestamos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Prestamos.Where(prestamos).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }

        public static void GuardarBalance(Prestamos prestamo)
        {
            Personas personas = new Personas();

            personas = PersonaBLL.Buscar(prestamo.PersonaId);
            personas.Balance += prestamo.Balance;

            PersonaBLL.Guardar(personas);
        }


        public static void ModificarBalance(Prestamos prestamo)
        {
            Personas persona = new Personas();
            Prestamos auxPrestamos = new Prestamos();

            auxPrestamos = PrestamoBLL.Buscar(prestamo.PrestamoId);
            persona = PersonaBLL.Buscar(prestamo.PersonaId);
            persona.Balance -= auxPrestamos.Balance;
            persona.Balance += prestamo.Balance;

            PersonaBLL.Guardar(persona);
        }

        public static void EliminarBalance(Prestamos prestamo)
        {
            Personas persona = new Personas();

            persona = PersonaBLL.Buscar(prestamo.PersonaId);
            persona.Balance -= prestamo.Balance;
            PersonaBLL.Guardar(persona);
        }


        private static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Prestamos.Any(d => d.PrestamoId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
