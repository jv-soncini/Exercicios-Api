﻿using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios Login(LoginViewModel Login);
    }
}
