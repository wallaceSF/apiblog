using apiblog.Context;
using apiblog.Entities;
using apiblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Services
{
    public class LembreteService
    {
        private Pessoa _pessoa;

        public LembreteService(Pessoa pessoa)
        {
            _pessoa = pessoa;
        }

        public List<string> GetLembrete()
        {                   
            //adicionar depois em outro lugar
            Aniversariante aniversariante = new Aniversariante();
            List<ILembrete> listLembrete = new List<ILembrete>
            {
                aniversariante
            };

            List<string> lembrete = new List<string>();
            foreach (ILembrete list in listLembrete)
            {
                list.SetPessoa(_pessoa);
                lembrete.Add(list.GetLembrete());
            }

            return lembrete;
        }

        private List<ILembrete> ListAllLembretes()
        {

            List<ILembrete> listLembrete = new List<ILembrete>
            {
                new Aniversariante()
            };


            return listLembrete;

        }


    }

   
}