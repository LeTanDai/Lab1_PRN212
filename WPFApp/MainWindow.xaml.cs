using BusinessObjects;
using Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductReposity _productReposity;
        private readonly ICategoryReposity _categoryReposity;
        public MainWindow()
        {
            InitializeComponent();
            _productReposity = new ProductReposity();
            _categoryReposity = new CategoryReposity();
        }
        public void LoadCategoryList()
        {
            var list = _categoryReposity.GetCategories();
            cboCategory.ItemsSource = list;
            cboCategory.DisplayMemberPath = "CategoryName";
            cboCategory.SelectedValuePath = "CategoryId";
        }
        public void LoadProduct()
        {
            var list = _productReposity.GetProducts();
            dgData.ItemsSource = null;
            dgData.ItemsSource = list;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();   
            LoadProduct();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtProductID.Text))
                {
                    Product p = _productReposity.GetProductById(Int32.Parse(txtProductID.Text));
                    _productReposity.DeleteProduct(p);
                }
                else
                {
                    MessageBox.Show("You must select a product");
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                LoadProduct();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtProductID.Text))
                {
                    Product p = _productReposity.GetProductById(Int32.Parse(txtProductID.Text));
                    if(p != null)
                    {

                        p.ProductId = _productReposity.GetMaxProductId();
                        p.ProductName = txtProductName.Text;
                        p.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                        p.UnitPrice = Decimal.Parse(txtPrice.Text);
                        p.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                        _productReposity.UpdateProduct(p);

                    }
                }
                else
                {
                    MessageBox.Show("You must select a product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProduct();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product
                {
                    ProductId = _productReposity.GetMaxProductId(),
                    ProductName = txtProductName.Text,
                    UnitsInStock = short.Parse(txtUnitsInStock.Text),
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                };
                _productReposity.SaveProduct(p);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProduct();
            }

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgData.SelectedItem is Product selectedProduct)
            {
                txtProductID.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName.ToString();
                txtUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
                txtPrice.Text = selectedProduct.UnitPrice.ToString();
                cboCategory.SelectedValue = selectedProduct.CategoryId;
            }
        }
    }
}