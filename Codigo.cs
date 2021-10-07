using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicios> servicio;

        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<Servicios> GetAll()
        {   //El "_appContext.(Nombre exacto de la entidad), trae los datos extraidos de la base de datos.
            return _appContext.Servicios;
        }
 
        public Servicios GetServicioWithId(int id){
            //Traer de la lista de "Usuarios" un usuario con este identificador(Id).
            return _appContext.Servicios.Find(id);
        }

        public Servicios Create(Servicios newServicios)
        {
            var addServicio = _appContext.Servicios.Add(newServicios);//Agregar un nuevo elemento a la encomienda.
            _appContext.SaveChanges();//Para guardar la entidad que se acaba de crear.
            return addServicio.Entity; //Entity es para retornar el ususario que se acaba de crear
        }


        public Servicios Update(Servicios newServicios){
            var user = _appContext.Servicios.Find(newServicios.id);

            if(servicio != null){
                servicio.origen = newServicios.origen;
                servicio.destino = newServicios.destino;
                servicio.fecha = newServicios.fecha;
                servicio.hora = newServicios.hora;
                servicio.encomienda = newServicios.encomienda;
                //Guardar en base de datos.
                _appContext.SaveChanges();
            }
            
        return servicio;
        }
        public void Delete(int id){
        var user = _appContext.Servicios.Find(id);
        if (user == null)
            return;
        _appContext.Servicios.Remove(user);
        _appContext.SaveChanges();
        }

    }
}