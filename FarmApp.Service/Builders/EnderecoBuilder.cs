﻿using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using System.Linq;

namespace FarmApp.Service.Builders
{
    public class EnderecoBuilder
    {
        private Endereco _endereco = new Endereco();
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IBairroRepository _bairroRepository;

        private EnderecoBuilder(
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository)
        {
            _cidadeRepository = cidadeRepository;
            _bairroRepository = bairroRepository;
        }

        public static EnderecoBuilder Init(
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository)
        {
            return new EnderecoBuilder(cidadeRepository, bairroRepository);
        }

        public Endereco Build() => _endereco;

        //private async Task<int> SetUf(string uf)
        //{
        //    int idUf = 0;
        //    if (!string.IsNullOrEmpty(uf))
        //    {
        //        idUf = await _ufRepository.GetUfByNomeAsync(uf);
        //        if (idUf == 0)
        //        {
        //           idUf = await _ufRepository.InsertAsync(new Uf() { NomeUf = uf });
        //        }
        //    }
        //    return idUf;
        //}

        //private async Task<int> SetCidade(string cidade, string uf)
        //{
        //    int idCidade = 0;
        //    if (!string.IsNullOrEmpty(cidade))
        //    {
        //        var idUf = await SetUf(uf);
        //        idCidade = await _cidadeRepository.GetCidadeIfExists(cidade, idUf);
        //        if (idCidade == 0)
        //        {
        //            idCidade = await _cidadeRepository.InsertAsync(new Cidade()
        //            {
        //                Iduf = idUf,
        //                NomeCidade = cidade
        //            });
        //        }
        //    }
        //    return idCidade;
        //}

        //private async Task<int> SetBairro(string bairro)
        //{
        //    int idBairro = 0;
        //    if (!string.IsNullOrEmpty(bairro))
        //    {
        //        idBairro = await _bairroRepository.GetBairroIfExists(bairro);
        //        if (idBairro == 0)
        //        {
        //            idBairro = await _bairroRepository.InsertAsync(new Bairro() { NomeBairro = bairro });
        //        }
        //    }
        //    return idBairro;
        //}
        public EnderecoBuilder SetNomeEndereco(string endereco)
        {
            if (!string.IsNullOrEmpty(endereco))
            {
                _endereco.NomeEndereco = endereco;
            }
            return this;
        }
        public EnderecoBuilder SetIdCidade(int idCidade)
        {
            var cidades = _cidadeRepository.GetAllAsync().Result;
            if(idCidade != 0 && cidades.Any(x => x.Id == idCidade))
            {
                _endereco.Idcidade = idCidade;
            }
            return this;
        }

        public EnderecoBuilder SetIdBairro(int idBairro)
        {
            var bairros = _bairroRepository.GetAllAsync().Result;
            if (idBairro != 0 && bairros.Any(x => x.Id == idBairro))
            {
                _endereco.Idbairro = idBairro;
            }
            return this;
        }
    }
}
