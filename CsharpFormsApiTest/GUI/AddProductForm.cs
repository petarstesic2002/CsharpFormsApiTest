using GUI.Api.Requests;
using GUI.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddProductForm : Form
    {
        private ApiRequest _apiRequest;
        private UpdateProduct? _updateProduct;
        private AddProduct? _newProduct;
        private Form1 _form1;
        public AddProductForm(Form1 frm, CategoryCheckboxItem[] cbListItems, UpdateProduct? updateProduct)
        {
            _apiRequest = new ApiRequest();
            _form1 = frm;
            InitializeComponent();
            checkedListBox1.Items.AddRange(cbListItems);
            if (updateProduct != null)
            {
                _updateProduct = updateProduct;
                BindForm(updateProduct);
            }
        }

        //Add Product
        private void button1_Click(object sender, EventArgs e)
        {
            SetProduct();
            try
            {
                RestResponse response = new RestResponse();
                if (_updateProduct != null)
                    response = _apiRequest.UpdateProduct(_updateProduct);
                else
                {
                    response = _apiRequest.AddProduct(_newProduct!);
                }
                if (!response.IsSuccessful)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                        MessageBox.Show(GetValidationErrors(response.Content!));
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Operation Successful", "Alert", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK || dr == DialogResult.None)
                    {
                        _form1.SetProductData(new ProductSearch());
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetValidationErrors(string content)
        {
            StringBuilder sBuilder = new StringBuilder();
            List<ValidationError> errors = JsonSerializer.Deserialize<List<ValidationError>>(content)!;
            Dictionary<string, List<string>> grouped = errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(i=>i.ErrorMessage).ToList());
            foreach (KeyValuePair<string, List<string>> kvp in grouped)
            {
                sBuilder.AppendLine($"Field: {kvp.Key}");
                foreach (string item in kvp.Value)
                    sBuilder.AppendLine(item);
            }
            return sBuilder.ToString();
        }
        private void SetProduct()
        {
            string name = textBox1.Text;
            string description = textBox2.Text;
            decimal price = 0;
            if (decimal.TryParse(textBox3.Text, out decimal p))
                price = p;
            int stockQuantity = 0;
            if (int.TryParse(textBox4.Text, out int sq))
                stockQuantity = sq;
            List<int> checkedCatIds = checkedListBox1.CheckedItems.Cast<CategoryCheckboxItem>().ToList().Select(x => x.Id).ToList();
            if (_updateProduct != null)
            {
                _updateProduct.Name = name;
                _updateProduct.Description = description;
                _updateProduct.Price = price;
                _updateProduct.StockQuantity = stockQuantity;
                _updateProduct.CategoryIds = checkedCatIds;
                return;
            }
            _newProduct = new AddProduct
            {
                Name = name,
                Description = description,
                Price = price,
                StockQuantity = stockQuantity,
                CategoryIds = checkedCatIds
            };
        }
        private void BindForm(UpdateProduct data)
        {
            textBox1.Text = data.Name;
            textBox2.Text = data.Description;
            textBox3.Text = data.Price.ToString();
            textBox4.Text = data.StockQuantity.ToString();
            List<int> checkedIndexes = checkedListBox1.Items
                                                      .Cast<CategoryCheckboxItem>()
                                                      .Select((item, index) => new { item, index })
                                                      .Where(x => data.CategoryIds.Contains(x.item.Id))
                                                      .Select(x => x.index)
                                                      .ToList();
            SetCategories(checkedIndexes);
        }
        private void SetCategories(List<int> checkedIndexes)
        {
            foreach(int item in checkedIndexes)
            {
                checkedListBox1.SetItemChecked(item, true);
            }
        }
    }
}
