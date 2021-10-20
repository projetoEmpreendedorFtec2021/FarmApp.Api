using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FarmApp.Service.Builders
{
    public class ContaFarmaciaBuilder
    {
        private ContaFarmaciaPoco _contaFarmacia = new ContaFarmaciaPoco();
        private readonly IContaFarmaciaRepository _contaFarmaciaRepository;

        private ContaFarmaciaBuilder(
            IContaFarmaciaRepository contaFarmaciaRepository)
        {
            _contaFarmaciaRepository = contaFarmaciaRepository;
        }

        public static ContaFarmaciaBuilder Init(IContaFarmaciaRepository contaFarmaciaRepository)
        {
            return new ContaFarmaciaBuilder(contaFarmaciaRepository);
        }

        public ContaFarmaciaPoco Build() => _contaFarmacia;

        public ContaFarmaciaBuilder SetRazaoSocial(string razaoSocial)
        {
            if (!string.IsNullOrEmpty(razaoSocial))
            {
                _contaFarmacia.RazaoSocial = razaoSocial;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetCnpj(string cnpj)
        {
            if (!string.IsNullOrEmpty(cnpj))
            {
                _contaFarmacia.Cnpj = cnpj;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetNomeFantasia(string nomeFantasia)
        {
            if (!string.IsNullOrEmpty(nomeFantasia))
            {
                _contaFarmacia.NomeFantasia = nomeFantasia;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetAlvara(string alvara)
        {
            if (!string.IsNullOrEmpty(alvara))
            {
                _contaFarmacia.Alvara = alvara;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetSite(string site)
        {
            if (!string.IsNullOrEmpty(site))
            {
                _contaFarmacia.Site = site;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetTelefone(string telefone)
        {
            if (!string.IsNullOrEmpty(telefone))
            {
                _contaFarmacia.Telefone = telefone;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetEmail(string email)
        {
            ContaFarmaciaPoco contaExistente = _contaFarmaciaRepository.GetContaFarmaciaPorEmail(email);

            if (contaExistente != null)
            {
                throw new Exception("E-mail já cadastrado");
            }

            _contaFarmacia.Email = email;
            return this;
        }

        public ContaFarmaciaBuilder SetCelular(string celular)
        {
            var padrao = @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$";
            if (Regex.IsMatch(celular, padrao))
            {
                _contaFarmacia.Celular = celular;
            }
            return this;
        }

        public ContaFarmaciaBuilder SetNumeroEndereco(string numero)
        {
            if (string.IsNullOrEmpty(numero))
            {
                throw new ArgumentNullException(nameof(_contaFarmacia.NumeroEndereçofarmacia));
            }
            _contaFarmacia.NumeroEndereçofarmacia = numero;
            return this;
        }

        public ContaFarmaciaBuilder SetIdCep(int idCep)
        {
            if (idCep == 0)
            {
                throw new ArgumentNullException(nameof(idCep));
            }

            _contaFarmacia.Idcep = idCep;
            return this;
        }
    }
}
