using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Registro.BLL
{
    public class RollBLL
    {
        //PROBLEMAAAAAAAAAAAA
        public static bool Guardar(Roll roll)
        {
            if (!Existe(roll.RolID))//Si no existe insertamos
                return Insertar(roll);
            else
                return Modificar(roll);//Aqui va modificar
        }
        private static bool Insertar(Roll roll)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que desee insertar al contexto
                contexto.Roll.Add(roll);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Roll roll)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(roll).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //Buscar la entidad que se desea eliminar
                var roll = contexto.Roll.Find(id);

                if (roll != null)
                {
                    contexto.Roll.Remove(roll);//Remover la cantidad
                    paso = contexto.SaveChanges() > 0;
                }
                else
                {
                    MessageBox.Show("Registro esta Vacio", "Exito",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Roll Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roll roll;
            try
            {
                roll = contexto.Roll.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return roll;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                //Ojo a esto
                encontrado = contexto.Roll.Any(e => e.RolID == id);
            }
            catch (Exception)
            {
                //Que hace el 
                throw;
            }
            finally
            {
                //Que hace el dispose
                contexto.Dispose();
            }
            return encontrado;
        }

        public static List<Roll> GetList(Expression<Func<Roll, bool>> criterio)
        {
            List<Roll> lista = new List<Roll>();
            Contexto contexto = new Contexto();
            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido
                lista = contexto.Roll.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        //Falta un exprecion Lambda
    }
}
