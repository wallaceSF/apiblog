﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Entities
{
    public class Post
    {
        public int IdPost { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public virtual List<Comentario> Comentarios { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public virtual List<Categoria> Categorias { get; set; }

    }
}