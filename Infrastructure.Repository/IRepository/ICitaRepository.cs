﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.IRepository
{
    public interface ICitaRepository:IGenericRepository<Cita>
    {
        Cita ProximaCita(int idCliente);
    }
}
