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
    public partial class AddEditOrderForm : Form
    {
        public Order Order { get; set; }
        private List<Driver> drivers;

        public AddEditOrderForm(Order order, List<Driver> drivers)
        {
            InitializeComponent();
            this.drivers = drivers;

            // Заполнение ComboBox водителями
            comboBoxDriver.DataSource = drivers;
            comboBoxDriver.DisplayMember = "DriverFullName"; // Отображаем ФИО водителя
            comboBoxDriver.ValueMember = "DriverLicense";   // Используем DriverLicense как значение

            comboBoxOrderStatus.Items.Add("Открыт");
            comboBoxOrderStatus.Items.Add("Закрыт");

            if (order != null)
            {
                Order = order;
                textBoxDeparture.Text = order.DepartureAddress;
                textBoxDestination.Text = order.DestinationAddress;
                dateTimePickerStart.Value = order.StartTime;
                comboBoxOrderStatus.SelectedItem = order.Status ? "Открыт" : "Закрыт";

                // Выбираем водителя в ComboBox, соответствующего текущему заказу
                if (drivers != null && drivers.Count > 0)
                {
                    Driver selectedDriver = drivers.FirstOrDefault(d => d.DriverLicense == order.DriverLicense);
                    if (selectedDriver != null)
                    {
                        comboBoxDriver.SelectedItem = selectedDriver;
                    }
                }
            }
            else
            {
                Order = new Order();
                if (comboBoxDriver.Items.Count > 0)
                {
                    comboBoxDriver.SelectedIndex = 0; // Выбираем первого водителя по умолчанию
                }
                comboBoxOrderStatus.SelectedIndex = 0;  // Выбираем "Открыт" по умолчанию
            }
        }

        private bool IsDepartureValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxDeparture.Text))
            {
                errorProvider.SetError(textBoxDeparture, "Адрес отправления не может быть пустым.");
                return false;
            }
            else
            {
                errorProvider.SetError(textBoxDeparture, "");
                return true;
            }
        }

        private bool IsDestinationValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxDestination.Text))
            {
                errorProvider.SetError(textBoxDestination, "Адрес назначения не может быть пустым.");
                return false;
            }
            else
            {
                errorProvider.SetError(textBoxDestination, "");
                return true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxDriver.SelectedItem is Driver selectedDriver)
            {
                Order.DriverFullName = selectedDriver.DriverFullName;
                Order.DriverLicense = selectedDriver.DriverLicense;
                Order.CarBrandAndModel = $"{selectedDriver.CarBrand} {selectedDriver.CarModel}";
            }
            else
            {
                MessageBox.Show("Необходимо выбрать водителя.");
                return;
            }

            if (!IsDepartureValid() || !IsDestinationValid())
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки перед сохранением.");
                return;
            }
            Order.DepartureAddress = textBoxDeparture.Text;
            Order.DestinationAddress = textBoxDestination.Text;
            Order.StartTime = dateTimePickerStart.Value;
            Order.Status = comboBoxOrderStatus.SelectedItem.ToString() == "Открыт";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxDeparture_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDestination_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

