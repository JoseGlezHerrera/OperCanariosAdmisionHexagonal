﻿namespace Oper.Admision.Application.UseCases.Socios.ObtenerSocioPorId
{
    public class ObtenerSocioPorIdOutput
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}