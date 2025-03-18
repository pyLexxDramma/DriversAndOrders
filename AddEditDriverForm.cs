using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriversAndOrders
{
    public partial class AddEditDriverForm : Form
    {
        public Driver Driver { get; set; }

        public AddEditDriverForm(Driver driver)
        {
            InitializeComponent();

            if (driver != null)
            {
                Driver = driver;
                textBoxFullName.Text = driver.DriverFullName;
                textBoxLicense.Text = driver.DriverLicense;
                textBoxBrand.Text = driver.CarBrand;
                textBoxModel.Text = driver.CarModel;
            }
            else
            {
                Driver = new Driver();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!IsFullNameValid() || !IsLicenseValid())
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки перед сохранением.");
                return;
            }

            Driver.DriverFullName = textBoxFullName.Text;
            Driver.DriverLicense = textBoxLicense.Text;
            Driver.CarBrand = textBoxBrand.Text;
            Driver.CarModel = textBoxModel.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsFullNameValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxFullName.Text))
            {
                errorProvider.SetError(textBoxFullName, "ФИО не может быть пустым.");
                return false;
            }
            else
            {
                errorProvider.SetError(textBoxFullName, "");
                return true;
            }
        }

        private bool IsLicenseValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxLicense.Text))
            {
                errorProvider.SetError(textBoxLicense, "Удостоверение не может быть пустым.");
                return false;
            }
            else
            {
                errorProvider.SetError(textBoxLicense, "");
                return true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxFullName_TextChanged(object sender, EventArgs e)
        {
            IsFullNameValid();
        }

        private void textBoxLicense_TextChanged(object sender, EventArgs e)
        {
            IsLicenseValid();
        }
    }
}