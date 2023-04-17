﻿using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(UsuarioDTO UsuarioDTO)
        {
            Usuario Usuario = _mapper.Map<Usuario>(UsuarioDTO);

            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id && a.Borrado == 0);
            Usuario.Borrado = 1;

            _context.SaveChanges();
        }

        public async Task<ICollection<UsuarioDTO>> GetAll()
        {
            List<Usuario> Usuarios = _context.Usuarios.ToList();
            ICollection<UsuarioDTO> alertaDTOs = _mapper.Map<ICollection<UsuarioDTO>>(Usuarios);

            return alertaDTOs;
        }

        public async Task<UsuarioDTO> GetById(int id)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id);
            UsuarioDTO UsuarioDTO = _mapper.Map<UsuarioDTO>(Usuario);

            return UsuarioDTO;
        }

        public async void Update(int id, UsuarioDTO UsuarioDTO)
        {
            Usuario Usuario = _context.Usuarios.FirstOrDefault(a => a.Id == id);

            Usuario.Id = UsuarioDTO.Id;
            Usuario.Nombre = UsuarioDTO.Nombre;
            Usuario.NombreUsuario = UsuarioDTO.NombreUsuario;
            Usuario.Contrasena = UsuarioDTO.Contrasena;
            Usuario.Apellido1 = UsuarioDTO.Apellido1;
            Usuario.Apellido2 = UsuarioDTO.Apellido2;
            Usuario.FechaNacimiento = UsuarioDTO.FechaNacimiento;
            Usuario.Email = UsuarioDTO.Email;
            Usuario.Telefono = UsuarioDTO.Telefono;
            Usuario.FotoPerfil = UsuarioDTO.FotoPerfil;
            Usuario.Salt = UsuarioDTO.Salt;
            Usuario.Perfil = UsuarioDTO.Perfil;

            _context.SaveChanges();
        }
    }
}