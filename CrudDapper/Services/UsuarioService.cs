﻿using AutoMapper;
using CrudDapper.Dto;
using CrudDapper.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudDapper.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<UsuarioListarDto>> BuscarUsuarioPorId(int usuarioId)
        {
            ResponseModel<UsuarioListarDto> response = new ResponseModel<UsuarioListarDto>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>("select * from Usuarios where id = @id", new { Id = usuarioId}); ;
                
                if(usuarioBanco == null)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Situacao = false;
                    return response;
                }

                var usuarioMapeado = _mapper.Map<UsuarioListarDto>(usuarioBanco);
                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuario localizado com sucesso!";
            }

            return response;

        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");
                if(usuariosBanco.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Situacao = false;
                    return response;
                }

                var usuarioMapeado = _mapper.Map<List<UsuarioListarDto>>(usuariosBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuários localizados com sucesso!";

            }

            return response;
        }
    }
}
