using System;
using System.Collections.Generic;
using System.Net;

using apiblog.Entities;
using apiblog.Interfaces;
using apiblog.Validation;
using FluentValidation;

namespace apiblog.Services
{
    public class PessoaServices
    {
        private IUnitOfWork _unitOfWork;
        private PessoaValidator _pessoaValidator = null;

        public PessoaServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public PessoaServices(IUnitOfWork UnitOfWork, PessoaValidator pessoaValidator)
        {
            _unitOfWork = UnitOfWork;
            _pessoaValidator = pessoaValidator;
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
                NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
            }

            return Pessoa;
        }        

        public void Create(Pessoa pessoaObjectParams)
        {

            if (_pessoaValidator != null)
            {
                _pessoaValidator.ValidateAndThrow(pessoaObjectParams);              
            }

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

            if (_pessoaValidator != null)
            {
                _pessoaValidator.ValidateAndThrow(Pessoa);
            }

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

 