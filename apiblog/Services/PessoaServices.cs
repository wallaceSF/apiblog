using System;
using System.Collections.Generic;
using System.Net;

using apiblog.Entities;
using apiblog.Interfaces;

namespace apiblog.Services
{
    public class PessoaServices
    {
        private IUnitOfWork _unitOfWork;

        public PessoaServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _unitOfWork.PessoaRepository.FindAll();
        }        

        public Pessoa Get(int id)
        {                       
            var Pessoa = _unitOfWork.PessoaRepository.Find(p => p.IdPessoa == id);

            if(Pessoa == null)
            {
                var NullReferenceException = new NullReferenceException("Não foi encontrado a pessoa");
              //  NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
            }

            return Pessoa;
        }        

        public void Create(Pessoa pessoaObjectParams)
        {
            _unitOfWork.PessoaRepository.Add(pessoaObjectParams);
            _unitOfWork.Save();            
        }

        public void Update(int id, Pessoa pessoaObjectParams)
        {                        
            var Pessoa = _unitOfWork.PessoaRepository.Find(p => p.IdPessoa == id);

            if (Pessoa == null)
            {
                var NullReferenceException = new NullReferenceException("Não foi encontrado a pessoa");
                NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
            }

            Pessoa.Nome = pessoaObjectParams.Nome;

            _unitOfWork.PessoaRepository.Update(Pessoa);
            _unitOfWork.Save();            
        }

        public void Delete(int id)
        {
            var Pessoa = _unitOfWork.PessoaRepository.Find(p => p.IdPessoa == id);

            if (Pessoa == null)
            {
                var NullReferenceException = new NullReferenceException("Não foi encontrado a pessoa");
                NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
            }
            
            _unitOfWork.PessoaRepository.Delete(Pessoa);
            _unitOfWork.Save();
        }

    }
}

 