﻿using Ecommerce.DTO;
using Ecommerce.Frontend.Services.Contrat;
using System.Net.Http.Json;

namespace Ecommerce.Frontend.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        #region Properties and Fields

        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<ResponseDTO<SesionDTO>> Autorization(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorization", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Create(UsuarioDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Create", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(UsuarioDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Edit", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Get/{id}");
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> List(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/List/{rol}/{buscar}");
        }
        
        #endregion
    }
}
