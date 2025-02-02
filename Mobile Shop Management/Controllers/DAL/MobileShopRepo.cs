﻿using APIUsingDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Mobile_Shop_Management.DAL.Interface;
using Mobile_Shop_Management.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reactive.Subjects;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Mobile_Shop_Management.DAL
{
    public class MobileShopRepo :IMobileShop
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public MobileShopRepo(IConfiguration configuration) { 
            _config = configuration;

            _connectionString = _config.GetConnectionString("ConString");
        }
       
        public async Task<string> AddAddressOfCustomerbyId(AddressModel address)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddAddressOfCustomerbyId";
                    var values = new
                    {
                        Address=address.Address,
                        CustomerId=address.CustomerId,
                        IsSelected=address.IsSelected,

                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddColoQuantitybypId(AddColorQuantitybypId colorsize)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddColorOrQuantityByPId";
                    var values = new
                    {
                        ColorName=colorsize.ColorName,
                        ProductQuantity=colorsize.ProductQuantity,
                        ProductId=colorsize.ProductId,

                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddNewCustomer(CustomerModel addcustomer)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewCustomer";
                    var values = new
                    {
                        CustomerName = addcustomer.CustomerName,
                        CustomerEmail = addcustomer.CustomerEmail,
                        CustomerMobileNumber = addcustomer.CustomerMobileNumber,
                        Gender = addcustomer.Gender,
                        Address=addcustomer.Address,

                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddNewProduct(AddProductModel product)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewProduct";
                    var values = new
                    {
                        ProductName=product.ProductName,
                        ProductQuantity=product.ProductQuantity,
                        ProductCategory=product.ProductCategory,
                        ProductCompanyName = product.ProductCompanyName
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddSicePricebypId(AddSizePricebypid sizeprice)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddSizePriceByPID";
                    var values = new
                    {
                        ProductSize=sizeprice.ProductSize,
                        ProductPrice=sizeprice.ProductPrice,
                        ProductQuantity=sizeprice.ProductQuantity,
                        ProductId=sizeprice.ProductId,
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddToCart(AddToCart addToCart)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddToCard";
                    var values = new
                    {
                        ProductId=addToCart.ProductId,
                        CustomerId=addToCart.CustomerId,
                        Quantity=addToCart.Quantity,
                        ProductSize=addToCart.ProductSize,
                        
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddUserOrAdmin(AddNewUserOrAdminModel adduser)
        {

            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddNewEmployeeOrAdmin";
                    var values = new
                    {
                        FirstName = adduser.FirstName,
                        LastName = adduser.LastName,
                        Address = adduser.Address,
                        PhoneNumber = adduser.PhoneNumber,
                        Email = adduser.Email,
                        UserType = adduser.UserType,
                        Passwords = adduser.Passwords
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> DeleteCustomerById(int CustomerId)
        {
           int result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "RemoveCustomerById";
                    var values = new
                    {
                        CustomerId = CustomerId
                    };

                  result = await connection.QueryFirstAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<string> DeleteUserById(int UserId)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "RemoveUserById";
                    var values = new
                    {
                        UserId = UserId
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<IEnumerable<GetCustomerModel>> GetAllCustomers()
        {
            IEnumerable<GetCustomerModel> user = new List<GetCustomerModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "GetAllCustomersDetail";
                    var values = new
                    {

                    };

                    user = await connection.QueryAsync<GetCustomerModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return user.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <inheritdoc/>


        public async Task<GetAllUserModel> GetAllUser(int UserId)
        {
            GetAllUserModel user = new GetAllUserModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "ShowAllUserAdmin";
                    var values = new
                    {
                        UserId=UserId
                    };

                    user = await connection.QueryFirstAsync<GetAllUserModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<GetAllUserModel>> GetAllUsers()
        {

            IEnumerable<GetAllUserModel> user=new List<GetAllUserModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AllDetailsfEmployeesAdmin";
                    var values = new
                    {
                        
                    };

                    user = await connection.QueryAsync<GetAllUserModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return user.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetCustomerModel> GetCustomerDetailbyId(int CustomerId)
        {
            GetCustomerModel customerModel = new GetCustomerModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "GetEmployeeDetailById";
                    var values = new
                    {
                        CustomerId = CustomerId
                    };

                    customerModel = await connection.QueryFirstAsync<GetCustomerModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return customerModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetProductDetailModel> GetProductDetailbyId(int ProductId)
        {
            GetProductDetailModel customerModel = new GetProductDetailModel();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "ShowProductDetailsbyPId";
                    var values = new
                    {
                        ProductId = ProductId
                    };

                    customerModel = await connection.QueryFirstAsync<GetProductDetailModel>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return customerModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        public async Task<TokenModel> LoginUserOrAdmin(LoginUser loginUser)
        {
            TokenModel tokenModel = new TokenModel();
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "UsderOrAdminLogin";
                    var values = new
                    {
                        UserId = loginUser.UserId,
                        Passwords = loginUser.Passwords,
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                if (result != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securitykey = Encoding.ASCII.GetBytes("sachinkumarthisismysewcretkeyiamusing");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                          {
                             new Claim(ClaimTypes.PrimarySid, loginUser.UserId.ToString()),
                             new Claim(ClaimTypes.Email, loginUser.Email),
                             new Claim(ClaimTypes.UserData, loginUser.Passwords)
                          }),
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securitykey), 
                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    tokenModel.token = tokenHandler.WriteToken(token);
                    tokenModel.UserId=loginUser.UserId;
                    tokenModel.expiry = DateTime.Now.AddMinutes(10);
                    return tokenModel;
                }
                else
                    return null; 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateUsersOrAdmin(GetAllUsersModel adduser)
        {
            string result;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                //var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "UpdateEmployeeOrAdmin";
                    var values = new
                    {
                        UserId=adduser.UserId,
                        FirstName = adduser.FirstName,
                        LastName = adduser.LastName,
                        Address = adduser.Address,
                        PhoneNumber = adduser.PhoneNumber,
                        Email = adduser.Email,
                        UserType = adduser.UserType,
                        Passwords = adduser.Passwords,
                        //RegisterDate= adduser.RegisterDate,
                        IsActive= adduser.IsActive,
                        //IsDeleted= adduser.IsDeleted,
                    };

                    result = await connection.QueryFirstAsync<string>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
    

