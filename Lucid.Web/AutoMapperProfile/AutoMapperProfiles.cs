using AutoMapper;
using Lucid.Models;
using Lucid.Web.Models.CustomerTypes;
using Lucid.Web.Models.Customer;
using Lucid.Web.Models.VanModels;
using Lucid.Web.Models.ProductModels;
using Lucid.Web.Models.Sales;
using Lucid.Web.Models.ExpenseTypeModels;

namespace Lucid.Web.AutoMapperProfile
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerCreateVm>();
            CreateMap<CustomerCreateVm, Customer>();
            CreateMap<Customer, CustomerListVm>()
                .ForMember(dest => dest.Van, opt => opt.MapFrom(src => src.Van.Name));
            CreateMap<CustomerListVm, Customer>();
            CreateMap<Customer, CustomerEditVm>();
            CreateMap<CustomerEditVm, Customer>();


            CreateMap<CustomerType, CustomerTypeListVm>();
            CreateMap<CustomerTypeListVm, CustomerType>();
            CreateMap<CustomerType, CustomerTypeCreateVm>();
            CreateMap<CustomerTypeCreateVm, CustomerType>();
            CreateMap<CustomerType, CustomerTypeEditVm>();
            CreateMap<CustomerTypeEditVm, CustomerType>();
            
            CreateMap<Van, VanListVm>();
            CreateMap<VanListVm, Van>();
            CreateMap<Van, VanCreateVm>();
            CreateMap<VanCreateVm, Van>();
            CreateMap<Van, VanEditVm>();
            CreateMap<VanEditVm, Van>();

            CreateMap<Product, ListProductVm>();
            CreateMap<ListProductVm, Product>();
            CreateMap<Product, CreateProductVm>();
            CreateMap<CreateProductVm, Product>();
            CreateMap<Product, EditProductVm>();
            CreateMap<EditProductVm, Product>();

            CreateMap<Sale, ListSaleVm>()
                .ForMember(dest => dest.Customer, opt=>opt.MapFrom(src=>src.Customer.Name));
            CreateMap<ListSaleVm, Sale>()
                ;
            CreateMap<Sale, CreateSaleVm>();
            CreateMap<CreateSaleVm,Sale>();
            CreateMap<Sale, EditSaleVm>();
            CreateMap<EditSaleVm, Sale>();

            CreateMap<CreateSaleDetailsVm, SaleDetails>();
            CreateMap<SaleDetails, CreateSaleDetailsVm>();

            CreateMap<ExpenseType, ListExpenseTypeVm>();
            CreateMap<ListExpenseTypeVm, ExpenseType>();
            CreateMap<ExpenseType, CreateExpenseTypeVm>();
            CreateMap<CreateExpenseTypeVm, ExpenseType>();
            CreateMap<ExpenseType, EditExpenseTypeVm>();
            CreateMap<EditExpenseTypeVm, ExpenseType>();
            


        }
    }
}
