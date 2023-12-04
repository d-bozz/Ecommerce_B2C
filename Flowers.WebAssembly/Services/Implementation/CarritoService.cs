using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Flowers.DTO;
using Flowers.WebAssembly.Services.Contract;


namespace Flowers.WebAssembly.Services.Implementation
{
    public class CarritoService : ICarritoService
    {
        #region Properties and Fields

        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        #endregion

        #region Constructor

        public CarritoService(
            ILocalStorageService localStorageService, 
            ISyncLocalStorageService syncLocalStorageService, 
            IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        #endregion

        #region Methods

        public event Action ShowItems;

        public async Task AddCarrito(CarritoDTO model)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito == null) 
                { 
                    carrito = new List<CarritoDTO>();
                }

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == model.Producto.IdProducto);

                if (encontrado != null)
                {
                    carrito.Remove(encontrado);
                }

                carrito.Add(model);
                await _localStorageService.SetItemAsync("carrito",carrito);

                if (encontrado != null)
                {
                    _toastService.ShowSuccess("El producto fue actualizado en el carrito");
                }
                else
                {
                    _toastService.ShowSuccess("El producto fue agregado al carrito");
                }

                ShowItems.Invoke();
            }
            catch (Exception)
            {
                _toastService.ShowError("No se pudo agregar al carrito");
            }
        }

        public async Task CleanCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            ShowItems.Invoke();
        }

        public int QuantityProducts()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count();
        }

        public async Task RemoveCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito != null) 
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                    if (elemento != null)
                    { 
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        ShowItems.Invoke();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }        
        }

        public async Task<List<CarritoDTO>> ReturnCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito == null)
            {
                carrito = new List<CarritoDTO>();
            }
            return carrito;
        }

        #endregion
    }
}
