﻿using Business.DTOs;

namespace Business.Interfaces
{
    public interface IEspecieTerrarioService
    {
        #region CRUD
        Task<ICollection<EspecieTerrarioDTO>> GetAll();
        Task<EspecieTerrarioDTO> GetById(int idterrario, int idespecie);
        void Create(EspecieTerrarioDTO especieTerrarioDTO);
        void Update(int idterrario, int idespecie, EspecieTerrarioDTO especieTerrarioDTO);
        void Delete(int idterrario, int idespecie);
        #endregion

        #region Custom
        Task UpdateOfTerrario(long id, List<EspecieTerrarioDTO> list);
        #endregion
    }
}
