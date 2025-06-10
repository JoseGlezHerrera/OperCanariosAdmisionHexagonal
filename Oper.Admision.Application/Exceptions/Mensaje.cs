using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.Exceptions
{
    public static class Mensaje
    {
        #region "CRUD Usuarios"
        public const string Usuario_Input = "InsertarUsuarioInput no puede ser NULL";

        public const string Sesion_Input = "InsertarSecionInput no puede ser NULL";


        public const string Socio_Input = "InsertarSocioInput no puede ser NULL";

        public const string Visita_Input = "InsertarVisitaInput no puede ser NULL";


        public static string Requerido(string propiedad) => $"El campo {propiedad} es requerido";

        public static string DNI_DUPLICADO(string dni) => $"El dni, {dni}, está registrado en otro usuario / socio.";

        public const string Rol_Input="El RolInput Rol no puede ser nulo.";
        #endregion

        #region "CRUD Terminales"
        public const string Terminal_Input = "Terminal no puede ser NULL";

        public static string USER_NULL(string dni) => $"El usuario con Dni:{dni}, es nulo. Revisar Password.";
        public static string USER_DNI_NULL(string email) => $"No existe usuario con el Email {email}.";
        public static string MAC_DUPLICADA(string mac) => $"Mac duplicado.La Mac, {mac}, está en otro terminal";

        #endregion

        #region "CRUD Salas"
        public const string Sala_Input = "Sala no puede ser NULL";
        public static string IP_DUPLICADA(string ip) => $"La IP, {ip}, está duplicada en la sala.";


        #endregion

        #region "CRUD Premios"
        public const string Premio_Input = "Premio no puede ser NULL";
        public const string Premio_BingoLinea_Porcentaje = "El importe por porcentaje tiene que estar entre 1-100 ";
        public const string Premio_NO_BingoLinea_Porcentaje = "El importe tiene que ser mayor a 0";
        public const string Premio_Asociado_PartidaTipos = "El premio está asociado a una o varias patidas tipos";
        #endregion

        #region "CRUD PremiosTipos"
        public const string PremioTipo_Input = "PremioTipo no puede ser NULL";

        #endregion

        #region "CRUD IncrementoBolaTope"
        public const string IncrementoBolaTope_Input = "IncrementoBolaTope no puede ser NULL";

        
        #endregion

        #region "CRUD PromocionCarton"
        public const string PromocionCarton_Input = "Promoción Cartón no puede ser NULL";
        public const string CANTIDAD_REGALADA = "Cantidad Regalada no pueder ser negativo.";
        public const string PromocionCarton_Existe_PartidasTipos = "No se puede eliminar una promoción Cartón asociados a una o varias partidas tipos.";
        public static string PROMOCION_NULL(int promocionId) => $" No existe promoción Carton con id: {promocionId}";

        #endregion

        #region "CRUD SerieCarton"
        public const string SerieCarton_Input = "Serie Carton no puede ser NULL";
        public const string SerieCartonAsociadoPartidaTipo = "Esta serie cartón está asociada a una o más partidas tipos.";
        public static string SerieCarton_Nombre_Repetido(string nombre) => $"El nombre de la Serie Cartón, {nombre}, ya está asignado.";


        #endregion
        #region "CRUD PartidaTipo"
        public const string PartidaTipo_Input = "Partida Tipo no puede ser NULL";
        public const string PartidaTipo_Asociados_Programacion = "La Partida Tipo está asociada a una o varias programaciones.";
        #endregion
        #region "CRUD Programacion"
        public const string Programacion_Input = "Programación no puede ser NULL";
        public static string Programacion_Nombre_Repetido(string nombre) => $"El nombre de la programación, {nombre}, ya está asignado a otra programación";
        public static string Programacion_Momento_Repetido(string nombre) => $"El tiempo para que se ejecute la programación (día de la semana, Día y Mes) ya está asignado a otra programación";

        

        #endregion

        #region "CRUD ProgramacionPrima"
        public const string ProgramacionPrima_Input = "Programación Prima no puede ser NULL";
        #endregion

        #region "CRUD ProgramacionPartida"
        public const string ProgramacionPartida_Input = "Programación Partida no puede ser NULL";
        #endregion

        #region "CRUD ProgramacionTipo"
        public const string ProgramacionTipo_Input = "Programación Tipo no puede ser NULL";
        #endregion

        #region "CRUD Empresas"
        public const string Empresa_Input = "Empresa no puede ser NULL";
        public static string Empresa_NUL(int empresaId) => $"La empresa con id,{empresaId}, es null";

        public static string PorcentajePremio => "El porcentaje de premios en la partida es igual o superior a 100%";
        #endregion

        #region "CRUD Anuncios"
        public const string Anuncio_Input = "Anuncio no puede ser NULL";
        public static string NombreArchivoUnico(string nombre) => $"El nombre imagen/video del anuncio,{nombre}, no es único. Cambiar su nombre para guardar.";

        #endregion

        #region "Log"

        public const string Log_Input = "El logInput no puede ser NULL";
        public const string Log_SalaId ="El valor SalaId tiene que ser mayor a cero.";
        public static string Log_Sala_NULL (int salaId) => $"La sala con id ={salaId} no existe";
        #endregion


        public const string ErrorConexionRed = "Error conexión Red";
    }
}
