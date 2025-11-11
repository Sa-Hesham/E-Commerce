using AutoMapper;
using Domain.Contracts;
using Services.Abstracion.ServicesManger;
using Services.ProductServices;

namespace Services.ServiceManger;

public class ServiceManager (IUnitOfWork _unitofwork , IMapper _mapper ): IServiceManager
{
    private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(_unitofwork,_mapper));
    public IProductService productService => _productService.Value; 
}
