using GUI.Api.Requests;
using GUI.Dto;
using RestSharp;

namespace GUI
{
    public partial class Form1 : Form
    {
        private ApiRequest _apiRequest;
        private int _page = 0;
        private List<CategoryDto> _categories;
        private int _totalPages = 0;
        public Form1()
        {
            _apiRequest = new ApiRequest();
            _categories = GetCategories();
            InitializeComponent();
            checkedListBox1.Items.AddRange(GetCategoryCbList());
            SetPageLabelText();
        }

        //GET PRODUCTS BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProductSearch search = new ProductSearch();
                SetSearch(search);
                SetProductData(search);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SetProductData(ProductSearch search)
        {
            PagedDto<ProductDto> products = GetProducts(search);
            _totalPages = products.TotalPages;
            _page = products.CurrentPage;
            SetPageLabelText();
            setPerPageTotalLabel(products);
            dataGridView1.DataSource = products.Data;
        }
        private void setPerPageTotalLabel(PagedDto<ProductDto> products)
        {
            label7.Text = $"Per Page: {products.PerPage} / Total Count: {products.TotalCount}";
        }
        //LOWER PAGE
        private void button2_Click(object sender, EventArgs e)
        {
            if (_page > 1)
                _page--;
            SetPageLabelText();
            ChangePage();
        }

        //RAISE PAGE
        private void button3_Click(object sender, EventArgs e)
        {
            if (_page < _totalPages)
                _page++;
            SetPageLabelText();
            ChangePage();
        }
        private void ChangePage()
        {
            ProductSearch search = new ProductSearch
            {
                Page = _page
            };
            SetProductData(search);
        }
        private void SetPageLabelText()
        {
            label1.Text = $"Page: {_page} / {_totalPages}";
        }
        private void SetSearch(ProductSearch search)
        {
            int id = 0;
            if (int.TryParse(textBox4.Text, out int i) && i > 0)
                id = i;
            if (id > 0)
            {
                search.Id = id;
                return;
            }

            decimal minPrice = 0;
            if (decimal.TryParse(textBox3.Text, out decimal mnP) && mnP > 0)
                minPrice = mnP;

            decimal maxPrice = 0;
            if (decimal.TryParse(textBox2.Text, out decimal mxP) && mxP > 0)
                maxPrice = mxP;

            string keyword = textBox1.Text;
            if (!string.IsNullOrEmpty(keyword))
                search.Keyword = keyword;

            if (minPrice >= 0)
                search.MinPrice = minPrice;

            if (maxPrice > 0 && maxPrice >= minPrice)
                search.MaxPrice = maxPrice;

            if (_page <= _totalPages && _page > 0)
                search.Page = _page;

            List<int> checkedCatIds = checkedListBox1.CheckedItems.Cast<CategoryCheckboxItem>().ToList().Select(x => x.Id).ToList();
            if (checkedCatIds.Count > 0)
                search.CategoryIds = checkedCatIds;

        }
        private List<CategoryDto> GetCategories()
        {
            return _apiRequest.GetCategories();
        }
        private PagedDto<ProductDto> GetProducts(ProductSearch search)
        {
            return _apiRequest.GetProducts(search);
        }
        private CategoryCheckboxItem[] GetCategoryCbList()
        {
            CategoryCheckboxItem[] cbListItems = _categories.Select(x => new CategoryCheckboxItem
            {
                Id = x.CategoryId,
                Name = x.CategoryName
            }).ToArray();
            return cbListItems;
        }

        //OPEN INSERT FORM
        private void button4_Click(object sender, EventArgs e)
        {
            AddProductForm addForm = new AddProductForm(this, GetCategoryCbList(), null);
            addForm.Show();
        }
        //DELETE PRODUCT
        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (CheckSelectedRows(rows))
            {
                try
                {
                    ProductDto product = GetSelectedProduct(rows[0]);
                    RestResponse response = _apiRequest.DeleteProduct(product.ProductId);
                    if (!response.IsSuccessful)
                        throw new Exception("Product could not be deleted");
                    else
                        SetProductData(new ProductSearch());

                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //UPDATE PRODUCT
        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (CheckSelectedRows(rows))
            {
                ProductDto product = GetSelectedProduct(rows[0]);
                UpdateProduct updateProduct = new UpdateProduct
                {
                    Id = product.ProductId,
                    Name = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    CategoryIds = product.Categories.Select(x=>x.CategoryId).ToList()
                };
                AddProductForm updateForm = new AddProductForm(this, GetCategoryCbList(), updateProduct);
                updateForm.Show();
            }
        }

        private bool CheckSelectedRows(DataGridViewSelectedRowCollection rows)
        {
            if (rows.Count != 1)
            {
                MessageBox.Show("One row must be selected.");
                return false;
            }
            return true;
        }

        private ProductDto GetSelectedProduct(DataGridViewRow row)
        {
            ProductDto product = row.DataBoundItem as ProductDto;
            if (product == null)
                throw new ArgumentNullException("Invalid Product.");
            return product;
        }
    }
}
