using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
namespace Jumia.Models
{
    public class Role
    {

        public int RoleId { get; set; }

        [StringLength(45)]
        public string RoleName { get; set; }

        public bool AddProduct { get; set; }

        public bool UpdateProductInfo { get; set; }

        public bool UpdateProductPrice { get; set; }

        public bool UpdateProductDiscount { get; set; }

        public bool DeleteProduct { get; set; }

        public bool ActivateProduct { get; set; }

        public bool ActivateClient { get; set; }

        public bool SeeClientInfo { get; set; }

        public bool UpdateClientInfo { get; set; }

        public bool SeeClientOrders { get; set; }

        public bool SeeClientWishList { get; set; }

        public bool SeeClientShippingCart { get; set; }

        public bool AddStore { get; set; }

        public bool SeeStoreInfo { get; set; }

        public bool UpdateStoreInfo { get; set; }

        public bool UpdateStoreProducts { get; set; }

        public bool CreateDiscountCoupon { get; set; }

        public bool UpdateDiscountCoupon { get; set; }

        public bool StopDiscountCoupon { get; set; }

        public bool AddBrand { get; set; }

        public bool UpdateBrand { get; set; }

        public bool AddDepartment { get; set; }

        public bool UpdateDepartment { get; set; }

        public bool AddCategory { get; set; }

        public bool UpdateCategory { get; set; }

        public bool AddSubCategory { get; set; }

        public bool UpdateSubCategory { get; set; }

        public bool AddCountry { get; set; }

        public bool UpdateCountry { get; set; }

        public bool AddOrderStatus { get; set; }

        public bool UpdateOrderStatus { get; set; }

        public bool AddPaymentMethod { get; set; }

        public bool UpdatePaymentMethod { get; set; }
    }
}