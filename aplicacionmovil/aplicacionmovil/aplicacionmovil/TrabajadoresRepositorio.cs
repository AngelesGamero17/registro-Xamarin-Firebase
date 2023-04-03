using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;

namespace aplicacionmovil
{
    public class TrabajadoresRepositorio
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://aplicacion-5d9c9-default-rtdb.firebaseio.com/");

        internal async Task<bool> Save(Trabajador trabajador)
        {
        var data=await firebaseClient.Child(nameof(Trabajador)).PostAsync(JsonConvert.SerializeObject(trabajador));
        if(!string.IsNullOrEmpty(data.Key))
        {
            return true;
        }
        return false;
    }

        internal async Task<List<Trabajador>>GetAll()
            
        {
            return (await firebaseClient.Child(nameof(Trabajador)).OnceAsync<Trabajador>()).Select(item => new Trabajador
            {
                Celular = item.Object.Celular,
                Correo = item.Object.Correo,
                Direccion = item.Object.Direccion,
                DNI = item.Object.DNI,
                Description =item.Object.Description,
                Nombre=item.Object.Nombre,
                Image=item.Object.Image,
                Id=item.Key
            }).ToList();
        }
            internal async Task<List<Trabajador>> GetAllByNombre(string nombre)
        {
            return (await firebaseClient.Child(nameof(Trabajador)).OnceAsync<Trabajador>()).Select(item => new Trabajador
            {
                Celular = item.Object.Celular,
                Correo = item.Object.Correo,
                Direccion = item.Object.Direccion,
                DNI = item.Object.DNI,
                Description = item.Object.Description,
                Nombre = item.Object.Nombre,
                Image = item.Object.Image,
                Id = item.Key
            }).Where(c=>c.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
        }

        internal async Task<Trabajador>GetById(string id)
        {
            return (await firebaseClient.Child(nameof(Trabajador) + "/" + id).OnceSingleAsync<Trabajador>());
        }
        internal async Task<bool> Update(Trabajador trabajador)
        {
            await firebaseClient.Child(nameof(Trabajador) + "/" + trabajador.Id).PutAsync(JsonConvert.SerializeObject(trabajador));
            return true;
        }

        public async Task<bool>Delete(string id)
        {
            await firebaseClient.Child(nameof(Trabajador)+"/"+id).DeleteAsync();
            return true;
        }

    }
}