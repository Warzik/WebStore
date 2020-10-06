using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Models;
using WebStore.Data.DataInterfaces;
using WebStore.Logic.DataInterfaces;
using WebStore.Logic.Models;
using WebStore.WebApplication.Models;

namespace WebStore.WebApplication.Helpers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CategoryDAL, ICategoryBLL>().ReverseMap();
			CreateMap<CustomerDAL, ICustomerBLL>().ReverseMap();
			CreateMap<OrderDAL, IOrderBLL>().ReverseMap();
			CreateMap<OrderDetailDAL, IOrderDetailBLL>().ReverseMap();
			CreateMap<PaymentDAL, IPaymentBLL>().ReverseMap();
			CreateMap<ProductDAL, IProductBLL>().ReverseMap();
			CreateMap<ProductDetailDAL, IProductDetailBLL>().ReverseMap();
			CreateMap<ReviewDAL, IReviewBLL>().ReverseMap();
			CreateMap<ShipperDAL, IShipperBLL>().ReverseMap();
			CreateMap<SupplierDAL, ISupplierBLL>().ReverseMap();
			CreateMap<WishDAL, IWishBLL>().ReverseMap();
			CreateMap<CategoryDAL, ICategoryBLL>().ReverseMap();

			CreateMap<CategoryBLL, ICategoryDAL>().ReverseMap();
			CreateMap<CustomerBLL, ICustomerDAL>().ReverseMap();
			CreateMap<OrderBLL, IOrderDAL>().ReverseMap();
			CreateMap<OrderDetailBLL, IOrderDetailDAL>().ReverseMap();
			CreateMap<PaymentBLL, IPaymentDAL>().ReverseMap();
			CreateMap<ProductBLL, IProductDAL>().ReverseMap();
			CreateMap<ProductDetailBLL, IProductDetailDAL>().ReverseMap();
			CreateMap<ReviewBLL, IReviewDAL>().ReverseMap();
			CreateMap<ShipperBLL, IShipperDAL>().ReverseMap();
			CreateMap<SupplierBLL, ISupplierDAL>().ReverseMap();
			CreateMap<WishBLL, IWishDAL>().ReverseMap();
			CreateMap<CategoryBLL, ICategoryDAL>().ReverseMap();

			CreateMap<CategoryBLL, ICategoryBLL>().ReverseMap();
			CreateMap<CustomerBLL, ICustomerBLL>().ReverseMap();
			CreateMap<OrderBLL, IOrderBLL>().ReverseMap();
			CreateMap<OrderDetailBLL, IOrderDetailBLL>().ReverseMap();
			CreateMap<PaymentBLL, IPaymentBLL>().ReverseMap();
			CreateMap<ProductBLL, IProductBLL>().ReverseMap();
			CreateMap<ProductDetailBLL, IProductDetailBLL>().ReverseMap();
			CreateMap<ReviewBLL, IReviewBLL>().ReverseMap();
			CreateMap<ShipperBLL, IShipperBLL>().ReverseMap();
			CreateMap<SupplierBLL, ISupplierBLL>().ReverseMap();
			CreateMap<WishBLL, IWishBLL>().ReverseMap();
			CreateMap<CategoryBLL, ICategoryBLL>().ReverseMap();

			CreateMap<Category, ICategoryBLL>().ReverseMap();
			CreateMap<Customer, ICustomerBLL>().ReverseMap();
			CreateMap<Order, IOrderBLL>().ReverseMap();
			CreateMap<OrderDetail, IOrderDetailBLL>().ReverseMap();
			CreateMap<Payment, IPaymentBLL>().ReverseMap();
			CreateMap<Product, IProductBLL>().ReverseMap();
			CreateMap<ProductDetail, IProductDetailBLL>().ReverseMap();
			CreateMap<Review, IReviewBLL>().ReverseMap();
			CreateMap<Shipper, IShipperBLL>().ReverseMap();
			CreateMap<Supplier, ISupplierBLL>().ReverseMap();
			CreateMap<Wish, IWishBLL>().ReverseMap();
			CreateMap<Category, ICategoryBLL>().ReverseMap();


			CreateMap<Category, CategoryBLL>().ReverseMap();
			CreateMap<Customer, CustomerBLL>().ReverseMap();
			CreateMap<Order, OrderBLL>().ReverseMap();
			CreateMap<OrderDetail, OrderDetailBLL>().ReverseMap();
			CreateMap<Payment,PaymentBLL>().ReverseMap();
			CreateMap<Product, ProductBLL>().ReverseMap();
			CreateMap<ProductDetail, ProductDetailBLL>().ReverseMap();
			CreateMap<Review, ReviewBLL>().ReverseMap();
			CreateMap<Shipper, ShipperBLL>().ReverseMap();
			CreateMap<Supplier, SupplierBLL>().ReverseMap();
			CreateMap<Wish, WishBLL>().ReverseMap();
			CreateMap<Category, CategoryBLL>().ReverseMap();


			CreateMap<Category, CategoryDAL>().ReverseMap();
			CreateMap<Customer, CustomerDAL>().ReverseMap();
			CreateMap<Order, OrderDAL>().ReverseMap();
			CreateMap<OrderDetail, OrderDetailDAL>().ReverseMap();
			CreateMap<Payment, PaymentDAL>().ReverseMap();
			CreateMap<Product, ProductDAL>().ReverseMap();
			CreateMap<ProductDetail, ProductDetailDAL>().ReverseMap();
			CreateMap<Review, ReviewDAL>().ReverseMap();
			CreateMap<Shipper, ShipperDAL>().ReverseMap();
			CreateMap<Supplier, SupplierDAL>().ReverseMap();
			CreateMap<Wish, WishDAL>().ReverseMap();
			CreateMap<Category, CategoryDAL>().ReverseMap();
		}
	}
}
