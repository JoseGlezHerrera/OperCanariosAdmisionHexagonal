using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Domain.Tools
{
    public interface IImagenHelper
    {
        string GetUniqueFileName(string nombre);
        void SaveImageBase64ToFile(string pathName, string filename, string imagenBase64);

        bool Delete(string pathName, string filename);
        bool Existe(string pathName, string filename);
    }
}
