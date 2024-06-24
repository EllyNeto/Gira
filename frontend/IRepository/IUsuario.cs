using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Dto;
using frontend.Model;

namespace frontend.IRepository
{
    public interface IUsuario
    {
        Task <Usuario> Login(string email, string senha);
    }
}
