using GUI.Api.Requests;
using GUI.Dto;

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
            _categories = getCategories();
            InitializeComponent();
            setCategoryCbList();
            setPageLabelText();
        }

        //GET PRODUCTS
        private void button1_Click(object sender, EventArgs e)
        {
           // try
            //{
                
                ProductSearch search = new ProductSearch();
                setSearch(search);
                var products = getProducts(search);
                _totalPages = products.TotalPages;
                _page = products.CurrentPage;
                setPageLabelText();
                dataGridView1.DataSource = products.Data;
           // }
            //catch(Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
        }

        //LOWER PAGE
        private void button2_Click(object sender, EventArgs e)
        {
            if (_page > 1)
                _page--;
            setPageLabelText();
        }

        //RAISE PAGE
        private void button3_Click(object sender, EventArgs e)
        {
            if(_page < _totalPages)
                _page++;
            setPageLabelText();
        }
        private void setPageLabelText()
        {
            label1.Text = $"Page: {_page} / {_totalPages}";
        }
        private void setSearch(ProductSearch search)
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
            if (string.IsNullOrEmpty(keyword))
                search.Keyword = keyword;

            if (minPrice > 0)
                search.MinPrice = minPrice;

            if (maxPrice > 0)
                search.MaxPrice = maxPrice;

            if (_page <= _totalPages && _page > 0)
                search.Page = _page;

            List<int> checkedCatIds = checkedListBox1.CheckedItems.Cast<CategoryCheckboxItem>().ToList().Select(x => x.Id).ToList();
            if (checkedCatIds.Count > 0)
                search.CategoryIds = checkedCatIds;
            
        }
        private List<CategoryDto> getCategories()
        {
             return _apiRequest.getCategories();
        }
        private PagedDto<ProductDto> getProducts(ProductSearch search)
        {
           return _apiRequest.getProducts(search);
        }
        private void setCategoryCbList()
        {
            CategoryCheckboxItem[] cbListItems = _categories.Select(x => new CategoryCheckboxItem
            {
                Id = x.CategoryId,
                Name = x.CategoryName
            }).ToArray();
            checkedListBox1.Items.AddRange(cbListItems);
        }
    }
}
