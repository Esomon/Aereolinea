using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace aereolinia.Models
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Aviones> Aviones { get; set; }
        public DbSet<Vuelos> Vuelos { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<TypeEmpleado> TypeEmpleado { get; set; }

    }

    public class Aviones
    {

        public int AvionesID { get; set; }
        [Required(ErrorMessage = "Modelos Requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Año Requerido ")]
        public string Fabricacion { get; set; }
        [Required(ErrorMessage = "Capacidad Requerida De Persona ")]
        public string Capacidad { get; set; }

    }

    public class Vuelos
    {
        public int VuelosID { get; set; }
        [Required(ErrorMessage = "Ciudad Requerida")]
        public string City { get; set; }
        [Required(ErrorMessage = "Fecha Requerida")]
        public string Fecha { get; set; }
        [Required(ErrorMessage = "Aerolinea Requerida")]
        public string Aerolinea { get; set; }


    }
    public class TypeEmpleado
    {
        public int TypeEmpleadoID { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Name { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Apellido Requerido")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Tipo de  Requerido")]
        public int TypeEmpleadoID { get; set; }
        public virtual TypeEmpleado TypeEmpleado { get; set; }

    }

}
