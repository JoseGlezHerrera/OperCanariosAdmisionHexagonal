

using Oper.Admision.Domain.Tools;

namespace Oper.Admision.Infrastructure.Tools
{
    public class ImagenHelper : IImagenHelper
    {
        public bool Delete(string pathName, string filename)
        {
            try
            {   
                string fullName= Path.Combine(pathName, filename);
                if (File.Exists(fullName))
                {
                    File.Delete(fullName);
                }
                return true;
            }
            catch 
            {
               return false;
            }
        }

        public bool Existe(string pathName, string filename)
        {
            try
            {
                string fullName = Path.Combine(pathName, filename);
                return File.Exists(fullName);
            }
            catch
            {
                return false;
            }
        }

        public string GetUniqueFileName(string nombre)
        {
            return nombre;
            if (!string.IsNullOrEmpty(nombre))
            {
                if (nombre.Contains("."))
                {
                    nombre= nombre.Substring(0, nombre.IndexOf("."));
                }
                return Guid.NewGuid().ToString() + "_" + nombre + ".png";
            }
            else
                return null;
        }

        public void SaveImageBase64ToFile(string pathName, string filename, string imagenBase64)
        {
            if (! string.IsNullOrEmpty(imagenBase64))
            {
                var cadenaRef = "base64,";
                var index = imagenBase64.IndexOf(cadenaRef) + cadenaRef.Length;
                imagenBase64 = imagenBase64.Substring(index, imagenBase64.Length - index);

                byte[] imageBytes = Convert.FromBase64String(imagenBase64);

                var file = Path.Combine(pathName, filename);

                using (var stream = new FileStream(file, FileMode.Create))
                {
                    stream.Write(imageBytes, 0, imageBytes.Length);
                    stream.Flush();
                }
            }
            
        }
    }
}
