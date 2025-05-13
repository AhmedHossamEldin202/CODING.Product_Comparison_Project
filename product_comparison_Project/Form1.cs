using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace product_comparison_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ProductReview
        {
            public string ProductName { get; set; }
            public string Specifications { get; set; }
            public decimal Price { get; set; }
            public string UserName { get; set; }
            public int Rating { get; set; }
        }

        private List<ProductReview> GetAllReviews()
        {
            return new List<ProductReview>
            { 
                new ProductReview { ProductName = "هاتف سامسونج", Specifications = "8GB RAM, 128GB", Price = 5000, UserName = "أحمد علي", Rating = 5 },
                new ProductReview { ProductName = "لابتوب HP", Specifications = "16GB RAM, 512GB SSD", Price = 15000, UserName = "منى حسن", Rating = 2 },
                new ProductReview { ProductName = "سماعات بلوتوث", Specifications = "ANC, بطارية 12 ساعة", Price = 700, UserName = "سعيد عمر", Rating = 4 },
            };
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var allReviews = GetAllReviews(); // جلب كل التقييمات
            List<ProductReview> filtered;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "المنتجات الجيدة":
                    filtered = allReviews.Where(r => r.Rating >= 4).ToList(); // تقييم جيد
                    break;
                case "المنتجات السيئة":
                    filtered = allReviews.Where(r => r.Rating <= 2).ToList(); // تقييم سيء
                    break;
                default:
                    filtered = allReviews; // كل المنتجات
                    break;
            }

            dataGridView1.DataSource = filtered; // عرض النتائج في الجدول
        }
    }
}
