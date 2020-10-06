using Bogus;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebStore.Data.DataInterfaces;
using WebStore.Data.Models;
using WebStore.Data.RepositoryInterfaces;

namespace DataGeneration
{
	public class Generator : IGenerator
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IOrderDetailRepository _orderDetailRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly IPaymentRepository _paymentRepository;
		private readonly IProductDetailRepository _productDetailRepository;
		private readonly IProductRepository _productRepository;
		private readonly IReviewRepository _reviewRepository;
		private readonly IShipperRepository _shipperRepository;
		private readonly ISupplierRepository _supplierRepository;
		private readonly IWishRepository _wishRepository;
		private readonly ICustomerRepository _customerRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;


		Faker faker;

		public Generator(
		 ICategoryRepository categoryRepository,
		 IOrderDetailRepository orderDetailRepository,
		 IOrderRepository orderRepository,
		 IPaymentRepository paymentRepository,
		 IProductDetailRepository productDetailRepository,
		 IProductRepository productRepository,
		 IReviewRepository reviewRepository,
		 IShipperRepository shipperRepository,
		 ISupplierRepository supplierRepository,
		 IWishRepository wishRepository,
		 ICustomerRepository customerRepository,
		UserManager<ApplicationUser> userManager,
		 RoleManager<IdentityRole> roleManager
		)
		{
			_categoryRepository = categoryRepository;
			_orderDetailRepository = orderDetailRepository;
			_orderRepository = orderRepository;
			_paymentRepository = paymentRepository;
			_productDetailRepository = productDetailRepository;
			_productRepository = productRepository;
			_reviewRepository = reviewRepository;
			_shipperRepository = shipperRepository;
			_supplierRepository = supplierRepository;
			_wishRepository = wishRepository;
			_userManager = userManager;
			_roleManager = roleManager;
			_customerRepository = customerRepository;


			faker = new Faker("en");
		}

		public async System.Threading.Tasks.Task GenerateAplicationCustomersAsync(int numberOfCustomers)
		{
			await _roleManager.CreateAsync(new IdentityRole("Customer"));
			for (int i = 0; i < numberOfCustomers; i++)
			{
				try
				{
					var email = faker.Internet.Email();
					CustomerDAL customer = new CustomerDAL()
					{
						FirstName = faker.Name.FirstName(),
						LastName = faker.Name.LastName(),
						Room = faker.Address.BuildingNumber(),
						Building = faker.Address.BuildingNumber(),
						Address_1 = faker.Address.FullAddress(),
						Address_2 = faker.Address.SecondaryAddress(),
						City = faker.Address.City(),
						PostalCode = faker.Address.ZipCode(),
						Country = faker.Address.Country(),
						Phone = faker.Phone.PhoneNumber(),
						Email = email,
						CreditCard = faker.Finance.CreditCardNumber(),
						CreditCardTypeID = faker.Finance.CreditCardCvv(),
						CardExpMo = faker.Date.Future().Month.ToString(),
						CardExpYr = faker.Date.Future().Year.ToString(),
						DateEntered = faker.Date.Past()
					};
					var user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, Customer = customer };
					var result = await _userManager.CreateAsync(user);
					await _userManager.AddToRoleAsync(user, "Customer");
					await _userManager.AddPasswordAsync(user, "Pp0!asdasd");
				}
				catch (Exception e)
				{
					i--;
				}
			}

			Console.WriteLine("Generate Aplication Customers finished " + numberOfCustomers);
		}

		public void GeneratePayments(int numberOfPayment)
		{
			try
			{
				List<PaymentDAL> payments = new List<PaymentDAL>();
				for (int i = 0; i < numberOfPayment; i++)
				{
					try
					{

						payments.Add(new PaymentDAL()
						{
							PaymentType = faker.Finance.TransactionType(),
							Allowed = faker.Random.Bool()
						});
					}
					catch { i--; }
				}
				_paymentRepository.AddMany(payments);
				Console.WriteLine("Generate Payments finished " + payments.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in Payments");
			}

		}

		public async Task GenerateAplicationSuppliersAsync(int numberOfSuppliers)
		{
			await _roleManager.CreateAsync(new IdentityRole("Supplier"));
			var payments = _paymentRepository.GetAll().ToList();
			Random rnd = new Random();
			for (int i = 0; i < numberOfSuppliers; i++)
			{
				try
				{
					var email = faker.Internet.Email();
					SupplierDAL supplier = new SupplierDAL()
					{
						CompanyName = faker.Company.CompanyName(),
						ContactFName = faker.Name.FirstName(),
						ContactLName = faker.Name.LastName(),
						ContactTitle = faker.Lorem.Sentences(3, ". "),
						Address_1 = faker.Address.FullAddress(),
						Address_2 = faker.Address.SecondaryAddress(),
						City = faker.Address.City(),
						State = faker.Address.State(),
						PostalCode = faker.Address.ZipCode(),
						Country = faker.Address.Country(),
						Phone = faker.Phone.PhoneNumber(),
						Email = email,
						URL = faker.Internet.Url(),
						Logo = ImageToByteArray(faker.Image.PicsumUrl()),
						Notes = faker.Lorem.Sentences(6, ". "),
						PaymentID = payments[rnd.Next(payments.Count)].PaymentID,
						Color= faker.Internet.Color()
					};
					var user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, Supplier = supplier };
					var result = await _userManager.CreateAsync(user);
					await _userManager.AddToRoleAsync(user, "Supplier");
					await _userManager.AddPasswordAsync(user, "Pp0!asdasd");
				}
				catch (Exception e)
				{
					i--;
				}
			}
			Console.WriteLine("Generate Aplication Suppliers finished " + numberOfSuppliers);
		}


		public void GenerateCategories()
		{
			try
			{
				var categories = new List<ICategoryDAL>();
				//5
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Men",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool()
									 }
							 );
					}
					catch { i--; }
				}
				//4
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Women",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
									 }
							 );
					}
					catch { i--; }
				}
				//3
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girl",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool()
									 }
							 );
					}
					catch { i--; }
				}
				//2
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boy",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool()
									 }
							 );
					}
					catch { i--; }
				}
				//1
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Baby",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool()
									 }
							 );
					}
					catch { i--; }
				}
				_categoryRepository.AddMany(categories);

				categories = new List<ICategoryDAL>();

				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Mens T-shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId=5
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Mens Shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 5
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Mens Jeans and trousers",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 5
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Mens Shorts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 5
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Mens Beachwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 5
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Mens Underwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 5
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boyes T-shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 2
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boyes Shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 2
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boyes Jeans and trousers",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 2
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boyes Shorts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 2
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boyes Beachwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 2
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Boyes Underwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 2
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girls Dresses and sundresses",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 3
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girls T-shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 3
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girls Blouses and shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 3
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girls Jeans and shorts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 3
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girls Swimwear and beachwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 3
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Girls Underwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 3
									 }
							 );
					}
					catch { i--; }
				}

				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Womens Dresses and sundresses",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 4
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Womens T-shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 4
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Womens Blouses and shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 4
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Womens Jeans and shorts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 4
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Womens Swimwear and beachwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 4
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Womens Underwear",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 4
									 }
							 );
					}
					catch { i--; }
				}

				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Windbreakers",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}

				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Babies Shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Babies T-shirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Babies Sweatshirts",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Babies Shorts and Pants",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Babies Dresses and sundresses",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}
				for (int i = 0; i < 1; i++)
				{
					try
					{
						categories.Add(
									 new CategoryDAL()
									 {
										 CategoryName = "Babies Blouses and tunics",
										 Description = faker.Lorem.Sentences(2, ". "),
										 Picture = ImageToByteArray(faker.Image.PicsumUrl()),
										 Color = faker.Internet.Color(),
										 Active = faker.Random.Bool(),
										 ParentCategoryId = 1
									 }
							 );
					}
					catch { i--; }
				}

				_categoryRepository.AddMany(categories);
				Console.WriteLine("Generate Categories finished " + categories.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in Generate Categories ");
			}

		}

		public void GenerateProducts(int numberOfProducts)
		{
			try
			{
				var suppliers = _supplierRepository.GetAll().ToList();
				var categories = _categoryRepository.GetAll().Skip(5).ToList();
				List<IProductDAL> products = new List<IProductDAL>();
				Random rnd = new Random();
				for (int i = 0; i < numberOfProducts; i++)
				{
					try
					{
						products.Add(new ProductDAL()
						{
							UPC = faker.Commerce.Ean13(),
							ProductName = faker.Commerce.ProductName(),
							ProductDescription = faker.Lorem.Sentences(3, ". "),
							QuantityPerUnit = faker.Random.Number(1, 15),
							UnitPrice = Math.Round(faker.Random.Decimal(50, 2500), 2),
							UnitsInStock = faker.Random.Number(500),
							UnitsOnOrder = faker.Random.Number(100),
							ReorderLevel = 10,
							ProductAvailable = faker.Random.Bool(),
							MainPicture = ImageToByteArray(faker.Image.PicsumUrl()),
							Note = faker.Lorem.Sentences(3),
							ProductFirm = faker.Company.CompanyName(),
							Discount = faker.Random.Bool() == true ? faker.Random.Float(10, 60) : 0,
							CategoryID = categories[rnd.Next(6, categories.Count)].CategoryID,
							SupplierID = suppliers[rnd.Next(suppliers.Count)].SupplierID

						}) ;
					}
					catch { i--; }
				}

				_productRepository.AddMany(products);
				Console.WriteLine("Generate Products finished " + products.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in Products");

			}


		}
		public void GenerateProductDetails(int numberOfProductDetails)
		{
			try
			{
				var products = _productRepository.GetAll().ToList();
				List<ProductDetailDAL> productDetails = new List<ProductDetailDAL>();
				Random rnd = new Random();
				for (int i = 0; i < numberOfProductDetails; i++)
				{
					try
					{
						productDetails.Add(
						new ProductDetailDAL()
						{
							Color = faker.Commerce.Color(),
							Size = faker.Lorem.Letter(),
							Material = faker.Commerce.ProductMaterial(),
							Picture = ImageToByteArray(faker.Image.PicsumUrl()),
							ProductID = products[rnd.Next(products.Count)].ProductID,
						}
						);
					}
					catch
					{
						i--;
					}
				}
				_productDetailRepository.AddMany(productDetails);
				Console.WriteLine("Generate Product Details finished " + productDetails.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in Product Details");

			}

		}

		public void GenerateWhishes(int numberOfWhishes)
		{
			try
			{
				var products = _productRepository.GetAll().ToList();
				var customers = _customerRepository.GetAll().ToList();
				List<IWishDAL> wishes = new List<IWishDAL>();
				Random rnd = new Random();
				for (int i = 0; i < numberOfWhishes; i++)
				{
					try
					{
						wishes.Add(
						new WishDAL()
						{
							CustomerID = customers[rnd.Next(customers.Count)].CustomerID,
							ProductID = products[rnd.Next(products.Count)].ProductID,
						}
						);
					}
					catch { i--; }
				}
				_wishRepository.AddMany(wishes);
				Console.WriteLine("Generate Whishes finished " + wishes.Count);
			}
			catch (Exception e)
			{

				Console.WriteLine("Exception in Whishes");
			}

		}

		public void GenerateRewiews(int numberOfReview)
		{
			try
			{
				var products = _productRepository.GetAll().ToList();
				List<IReviewDAL> reviews = new List<IReviewDAL>();
				Random rnd = new Random();
				for (int i = 0; i < numberOfReview; i++)
				{
					try
					{
						reviews.Add(
						new ReviewDAL()
						{
							Stars = Math.Round(faker.Random.Double(1, 5), 2),
							Advantages = faker.Lorem.Sentences(1, ". "),
							Disadvantages = faker.Lorem.Sentences(1, ". "),
							Comment = faker.Lorem.Sentences(2, ". "),
							Email = faker.Internet.Email(),
							WritingDate=faker.Date.Past(),
							ProductID = products[rnd.Next(products.Count)].ProductID,
						}
						);
					}
					catch { i--; }
				}
				_reviewRepository.AddMany(reviews);
				Console.WriteLine("Generate Rewiews finished " + reviews.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in Rewiews");

			}

		}
		public void GenerateShippers(int numberOfShippers)
		{
			try
			{
				List<IShipperDAL> shippers = new List<IShipperDAL>();
				for (int i = 0; i < numberOfShippers; i++)
				{
					try
					{
						shippers.Add(
						new ShipperDAL()
						{
							CompanyName = faker.Company.CompanyName(),
							Phone = faker.Phone.PhoneNumber()
						}
						);
					}
					catch { i--; }
				}
				_shipperRepository.AddMany(shippers);
				Console.WriteLine("Generate Shippers finished " + shippers.Count);
			}
			catch (Exception e)
			{

				Console.WriteLine("Exception in Shippers");
			}

		}

		public void GenerateOrders(int numberOfOrders)
		{
			try
			{
				var customers = _customerRepository.GetAll().ToList();
				var shippers = _shipperRepository.GetAll().ToList();
				var payments = _paymentRepository.GetAll().ToList();
				List<IOrderDAL> orders = new List<IOrderDAL>();
				Random rnd = new Random();
				for (int i = 0; i < numberOfOrders; i++)
				{
					try
					{
						var orderDate = faker.Date.Past();
						var shipDate = faker.Date.Between(orderDate, faker.Date.Future());
						var requiredDate = faker.Date.Between(orderDate, faker.Date.Future());
						orders.Add(
							new OrderDAL()
							{
								OrderDate = orderDate,
								ShipDate = shipDate,
								RequiredDate = requiredDate,
								Fulfilled = faker.Random.Bool(),
								Paid = Math.Round(faker.Random.Decimal(1000, 5500), 2),
								PaymentDate = faker.Date.Between(orderDate, shipDate),
								CustomerID = customers[rnd.Next(customers.Count)].CustomerID,
								ShipperID = shippers[rnd.Next(shippers.Count)].ShipperID,
								PaymentID = payments[rnd.Next(payments.Count)].PaymentID
							}
							);
					}
					catch { i--; }
				}
				_orderRepository.AddMany(orders);
				Console.WriteLine("Generate Orders finished " + orders.Count);
			}
			catch (Exception e)
			{

				Console.WriteLine("Exception in Orders");
			}


		}



		public void GenerateOrderDetails(int numberOfOrderDeteils)
		{
			try
			{
				var products = _productRepository.GetAll().ToList();
				var productDetail = _productDetailRepository.GetAll().ToList();
				var orders = _orderRepository.GetAll().ToList();
				List<IOrderDetailDAL> orderDetails = new List<IOrderDetailDAL>();
				Random rnd = new Random();
				for (int i = 0; i < numberOfOrderDeteils; i++)
				{
					try
					{
						var orderDate = faker.Date.Past();
						var shipDate = faker.Date.Between(orderDate, faker.Date.Future());
						var requiredDate = faker.Date.Between(orderDate, faker.Date.Future());
						var price = Math.Round(faker.Random.Decimal(1000, 5500), 2);
						var quantity = faker.Random.Number(1, 20);
						var discount = faker.Random.Float();
						decimal total = price * (decimal)quantity * (decimal)discount;
						orderDetails.Add(
							new OrderDetailDAL()
							{
								Price = price,
								Quantity = quantity,
								Discount = discount,
								Total = total,
								ProductID = products[rnd.Next(products.Count)].ProductID,
								OrderID = orders[rnd.Next(orders.Count)].OrderID,
								ProductDetailID= productDetail[rnd.Next(productDetail.Count)].ProductDetailID
							}
							);
					}
					catch { i--; }
				}
				_orderDetailRepository.AddMany(orderDetails);
				Console.WriteLine("Generate Order Details finished " + orderDetails.Count);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception in Order Details");

			}


		}


		public byte[] ImageToByteArray(string imageUrl)
		{
			WebClient client = new WebClient();
			Stream stream;
			while (true)
			{
				try
				{
					stream = client.OpenRead(faker.Image.PicsumUrl());

					break;
				}
				catch (Exception e)
				{
					continue;

				}
			}

			Bitmap bitmap = new Bitmap(stream);

			using (var ms = new MemoryStream())
			{
				bitmap.Save(ms, bitmap.RawFormat);
				return ms.ToArray();
			}
		}



		//public void Load(byte[] byteImage)
		//{

		//	string base64 = Convert.ToBase64String(byteImage);
		//	string imgSrc = String.Format("data:image/gif;base64,{0}", base64);


		//}

	}
}
