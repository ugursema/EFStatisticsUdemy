using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFStatisticsUdemy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EFStatisticsUdemyEntities db = new EFStatisticsUdemyEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            TotalCategory();
            TotalProduct();
            CustomerCount();
            OrderCount();
            ProductTotalStockCount();
            AverageProductPrice();
            TotalPcStock();
            TotalPriceByProductPc();
            productCountStockSmallerThen20();
            productStockCountCategoryAndStatus();
            CountryOrder();
            CountryOrderTurkeyEF();
            totalPriceMonitor();
            totalPriceTelevizyonef();
            lastProduct();
            lastProductCategory();
            ActiveProductCount();
            SsdStock();
            lastAddCustomerName();
            CountryDistinc();
        }

        void TotalCategory()
        {
            //toplam kategori sayısı
            int categoryCount = db.Tbl_Category.Count();
            lblCategoryCount.Text = categoryCount.ToString();
        }
        void TotalProduct()
        {

            //toplam ürün syısı
            int productCount = db.Tbl_Product.Count();
            lblProductCount.Text = productCount.ToString();
        }
        void CustomerCount()
        {
            // toplam müsteri sayısı
            int customerCount = db.Tbl_Customer.Count();
            lblCustomerCount.Text = customerCount.ToString();
        }
        void OrderCount()
        {
            // toplam müsteri sayısı
            int orderCount = db.Tbl_Order.Count();
            lblOrderCount.Text = orderCount.ToString();
        }
        void ProductTotalStockCount()
        {
            // toplam müsteri sayısı
            var totalProductStock = db.Tbl_Product.Sum(x => x.ProductStock);
            lblProductTotalStock.Text = totalProductStock.ToString();
        }
        void AverageProductPrice()
        {
            // ortalama ürün fiyatı
            var averageProductPrice = db.Tbl_Product.Average(x => x.ProductPrice);
            lblaverageProductPrice.Text = averageProductPrice.ToString();
        }

        void TotalPcStock()
        {
            //toplam pv stok sayısı
            var totalPcStok = db.Tbl_Product.Where(x => x.CategoryId == 1).Sum(y => y.ProductStock);
            lblTotalPcStock.Text = totalPcStok.ToString();
        }
        void TotalPriceByProductPc()
        {
            //Laptop i7 ÜRÜNÜN TOPLAM İŞLLEM HACMİ
            //stok sayısı bulma
            var totalPcSGetstok = db.Tbl_Product.Where(x => x.ProductName == "Laptop i7").Select(y => y.ProductStock).FirstOrDefault();
            //birim fiyatı alma
            var totalPcStokUnitPrice = db.Tbl_Product.Where(x => x.ProductName == "Laptop i7").Select(y => y.ProductPrice).FirstOrDefault();
            //toplam islem havmi
            var totalPcStokLaptop = totalPcSGetstok * totalPcStokUnitPrice;
            lblTotalPriceByProductPC.Text = totalPcStokLaptop.ToString();

        }
        //stok sayısı 20 den az olan ürünler

        void productCountStockSmallerThen20()
        {
            var productCountStockSmaller = db.Tbl_Product.Where(x => x.ProductStock < 20).Count();
            lblProductStockSmaller.Text = productCountStockSmaller.ToString();
        }
        //kategorisi telefon olan durumu aktif olan ürün sayısı
        void productStockCountCategoryAndStatus()
        {
            int id = db.Tbl_Category.Where(x => x.CategoryName == "Telefon").Select(y => y.CategoryId).FirstOrDefault();
            var productStockCountByCategoryNameIsPhoneAndStatusIsTrue = db.Tbl_Product.Where(x => x.CategoryId == (db.Tbl_Category.Where(w => w.CategoryName == "Telefon").Select(y => y.CategoryId).FirstOrDefault()) && x.ProductStatus == true).Sum(y => y.ProductStock);
            lblProductPhoneTrue.Text = productStockCountByCategoryNameIsPhoneAndStatusIsTrue.ToString();

        }
        void CountryOrder()
        {
            //// Ülkesi Türkiye olan ilk müşterinin ID bilgisini alıyor
            //int customerId = db.Tbl_Customer.Where(x => x.CustomerCountry == "Türkiye").Select(y => y.CustomerId).FirstOrDefault();
            //lblCountryOrderTurkey.Text=customerId.ToString();   
            // Ülkesi Türkiye olan   müşterinin sayısı 
            var x2 = db.Database.SqlQuery<int>("Select count(*) From Tbl_Order where CustomerId In (Select CustomerId From Tbl_Customer where CustomerCountry ='Türkiye')").FirstOrDefault();
            lblCountryOrderTurkey.Text = x2.ToString();
        }
        void CountryOrderTurkeyEF()
        {
            var turkishCustomerId = db.Tbl_Customer.Where(x => x.CustomerCountry == "Türkiye").Select(y => y.CustomerId).ToList();
            var orderCountFromTurkiyeWithEf = db.Tbl_Order.Count(z => turkishCustomerId.Contains(z.CustomerId.Value));

            lblCountryOrderTurkeyEF.Text = orderCountFromTurkiyeWithEf.ToString();
        }

        //Siparişler içinde kategorisi Televizyon olan ürünlerin Toplam Satış Fiyatı
        void totalPriceMonitor()
        {
            var orderTotalPriceCategoryIsMonitor = db.Database.SqlQuery<decimal?>(
                "SELECT SUM(o.TotalPrice) FROM Tbl_Order o " +
                "INNER JOIN Tbl_Product p ON o.ProductId = p.ProductId " +
                "INNER JOIN Tbl_Category c ON p.CategoryId = c.CategoryId " +
                "WHERE c.CategoryName = 'Televizyon'").FirstOrDefault() ?? 0;

            lbltotalPriceMonitor.Text = orderTotalPriceCategoryIsMonitor.ToString();
        }
        void totalPriceTelevizyonef()
        {
            var orderTotalPriceByCategoryTVEF = (from o in db.Tbl_Order
                                                 join p in db.Tbl_Product on o.ProductId equals p.ProductId
                                                 join c in db.Tbl_Category on p.CategoryId equals c.CategoryId
                                                 select o.TotalPrice).Sum();
            lbltotalPriceTV.Text=orderTotalPriceByCategoryTVEF.ToString();
 
        }
        //son eklenen ürün adı 
        void lastProduct()
        {
            var lastProductName=db.Tbl_Product.OrderByDescending(x=>x.ProductId).Select(y=>y.ProductName).FirstOrDefault();
            lblLastProduct.Text=lastProductName.ToString();
        }
        //son eklenen ürün kategori adı
        void lastProductCategory()
        {
            var lastProductNameId=db.Tbl_Product.OrderByDescending(x=>x.ProductId).Select(y=>y.CategoryId).FirstOrDefault();


            var lastProductCategoryName=db.Tbl_Category.Where(x=>x.CategoryId == lastProductNameId).Select(y=>y.CategoryName).FirstOrDefault();
            lblLastProductCategory.Text= lastProductCategoryName.ToString();
        }
       
        //aktif ürün sayısı 
        void ActiveProductCount()
        {
            var  activeProductCount = db.Tbl_Product.Where(x=>x.ProductStatus == true).Count();
            lblactiveProductCount.Text=activeProductCount.ToString();
        }
        //toplam ssd satış kazanç
        void SsdStock()
        {
            int ssdStock = db.Tbl_Product.Count(x => x.ProductName == "1TB SSD");
            var ssdPrice =db.Tbl_Product.Where(x=>x.ProductName== "1TB SSD").Select(y=>y.ProductPrice).FirstOrDefault();
            var totalSsdStockPrice = ssdStock * ssdPrice;
            lblSsdCount.Text=totalSsdStockPrice.ToString();
             
        }

        //Son Siparişteki Müşteri Adı
        void lastAddCustomerName()
        {

            var lastCustomerId = db.Tbl_Order.OrderByDescending(x=>x.OrderId).Select(y=>y.CustomerId).FirstOrDefault();
            var lastCustomerName= db.Tbl_Customer.Where(a=>a.CustomerId == lastCustomerId).Select(y=>y.CustomerName).FirstOrDefault();
            lbllastAddCustomer.Text=lastCustomerName.ToString();

        }
        //Kaç farklı Ülke var
        void CountryDistinc()
        {
            var countryCount = db.Tbl_Customer.Select(x=>x.CustomerCountry).Distinct().Count();
            lblCountryCount.Text=countryCount.ToString();
        }
    }
}
