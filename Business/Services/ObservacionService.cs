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
    public class ObservacionService : IObservacionService
    {
        private readonly QtechContext _context;
        private readonly IMapper _mapper;

        public ObservacionService(QtechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void Create(ObservacionDTO ObservacionDTO)
        {
            Observacion Observacion = _mapper.Map<Observacion>(ObservacionDTO);

            _context.Observaciones.Add(Observacion);
            _context.SaveChanges();
        }

        public async void Delete(int id)
        {
            Observacion Observacion = _context.Observaciones.FirstOrDefault(a => a.Id == id);

            _context.Remove(Observacion);
            _context.SaveChanges();
        }

        public async Task<ICollection<ObservacionDTO>> GetAll()
        {
            List<Observacion> Observaciones = _context.Observaciones.ToList();
            ICollection<ObservacionDTO> alertaDTOs = _mapper.Map<ICollection<ObservacionDTO>>(Observaciones);

            return alertaDTOs;
        }

        public async Task<ObservacionDTO> GetById(int id)
        {
            Observacion Observacion = _context.Observaciones.FirstOrDefault(a => a.Id == id);
            ObservacionDTO ObservacionDTO = _mapper.Map<ObservacionDTO>(Observacion);

            return ObservacionDTO;
        }

        public async void Update(int id, ObservacionDTO ObservacionDTO)
        {
            Observacion Observacion = _context.Observaciones.FirstOrDefault(a => a.Id == id);

            Observacion.Id = ObservacionDTO.Id;
            Observacion.Idterrario = ObservacionDTO.Idterrario;
            Observacion.Fecha = ObservacionDTO.Fecha;
            Observacion.Texto = ObservacionDTO.Texto;

            _context.SaveChanges();
        }
    }
}
