﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.Webapi.Domains
{
    public class ArtistaDomain
    {
        public int IdArtista { get; set; }

        public string Nome { get; set; }
        public int EstiloId { get; set; }

        public EstiloDomain Estilo { get; set; }
    }
}
