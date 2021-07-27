using DoctorManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Interfaces
{
    public interface ITokenService
    {
        string addToken(Doctors user);
    }
}
