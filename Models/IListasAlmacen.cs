using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public interface IListasAlmacen
    {
        public void ListaNueva(ListaAmigos listaAmigos);
        public void AmigoNuevo(Amigo amigo);
        public List<ListaAmigos> ObtenerListasDeAmigos();
        public ListaAmigos ObtenerLista(int id);
        public ListaAmigos ObtenerListaConAmigos(int id);
        public Amigo ObtenerDatosAmigo(int id);
        public void ModificarLista(ListaAmigos lista);
        public void ModificarAmigo(Amigo amigo);
        public void EliminarLista(ListaAmigos lista);
        public void EliminarAmigo(Amigo amigo);
    }
}
