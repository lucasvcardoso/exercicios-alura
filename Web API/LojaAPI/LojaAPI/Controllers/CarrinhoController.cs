﻿using LojaAPI.DAO;
using LojaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        /*
         Por convenção nomeia-se os métodos do controller de acordo com os verbos HTTP aos quais esses métodos responderão
             */
        public Carrinho Get(int id)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            Carrinho carrinho = dao.Busca(id);
            return carrinho;
        }
    }
}
