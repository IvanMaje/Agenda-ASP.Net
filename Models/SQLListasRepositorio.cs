using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Agenda.Models
{
    public class SQLListasRepositorio: IListasAlmacen
    {
        private readonly AppDbContext contexto;

        public SQLListasRepositorio(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        /*
         *   Metodos de creacion
         */

        public void ListaNueva(ListaAmigos listaAmigos)
        {
            contexto.ListasAmigos.Add(listaAmigos);
            contexto.SaveChanges();
        }

        public void AmigoNuevo(Amigo amigo)
        {
            contexto.Amigos.Add(amigo);
            contexto.SaveChanges();
        }

        /*
         *   Metodos para obtener datos
         */

        public List<ListaAmigos> ObtenerListasDeAmigos()
        {
            return contexto.ListasAmigos.ToList<ListaAmigos>();
        }

        public ListaAmigos ObtenerLista(int id)
        {
            return contexto.ListasAmigos.Find(id);
        }

        public ListaAmigos ObtenerListaConAmigos(int id)
        {
            ListaAmigos lista = contexto.ListasAmigos.Find(id);
            lista.amigos = ObtenerAmigosDeLaLista(id);
            return lista;
        }



        public List<Amigo> ObtenerAmigosDeLaLista(int listaAmigoId)
        {
            return contexto.Amigos.Where(x => x.ListaAmigosId == listaAmigoId).ToList();
        }

        public Amigo ObtenerDatosAmigo(int id)
        {
            return contexto.Amigos.Find(id);
        }

        /*
         *   Metodos para editar datos
         */

        public void ModificarLista(ListaAmigos lista)
        {
            var employee = contexto.ListasAmigos.Attach(lista);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void ModificarAmigo(Amigo amigo)
        {
            var employee = contexto.Amigos.Attach(amigo);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
        }

        /*
         *   Metodos para borrar datos
         */

        public void EliminarLista(ListaAmigos lista)
        {
            List<Amigo> amigos = contexto.Amigos.Where(x => x.ListaAmigosId == lista.Id).ToList();
            foreach (Amigo a in amigos)
            {
                contexto.Amigos.Remove(a);
            }
            contexto.ListasAmigos.Remove(lista);
            contexto.SaveChanges();
        }

        public void EliminarAmigo(Amigo amigo)
        {
            contexto.Amigos.Remove(amigo);
            contexto.SaveChanges();
        }
        
    }
}
