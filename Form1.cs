using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DriversAndOrders
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private bool isDriversList = true;
        private List<Driver> drivers = new List<Driver>();
        private List<Order> orders = new List<Order>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrivers();
        }

        private void LoadDrivers()
        {
            try
            {
                drivers = dbHelper.GetDrivers();
                dataGridViewDrivers.AutoGenerateColumns = false;
                dataGridViewDrivers.Columns.Clear();
                dataGridViewDrivers.Columns.Add("DriverId", "ID");
                dataGridViewDrivers.Columns.Add("DriverFullName", "ФИО");
                dataGridViewDrivers.Columns.Add("DriverLicense", "Удостоверение");
                dataGridViewDrivers.Columns.Add("CarBrand", "Марка");
                dataGridViewDrivers.Columns.Add("CarModel", "Модель");

                dataGridViewDrivers.Columns["DriverId"].DataPropertyName = "DriverId";
                dataGridViewDrivers.Columns["DriverFullName"].DataPropertyName = "DriverFullName";
                dataGridViewDrivers.Columns["DriverLicense"].DataPropertyName = "DriverLicense";
                dataGridViewDrivers.Columns["CarBrand"].DataPropertyName = "CarBrand";
                dataGridViewDrivers.Columns["CarModel"].DataPropertyName = "CarModel";

                dataGridViewDrivers.DataSource = drivers;
                dataGridViewDrivers.Visible = true;
                dataGridViewOrders.Visible = false;
                labelCurrentList.Text = "Список: Водители";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке водителей: " + ex.Message);
            }
        }

        private void LoadOrders()
        {
            try
            {
                orders = dbHelper.GetOrders();
                dataGridViewOrders.AutoGenerateColumns = false;
                dataGridViewOrders.Columns.Clear();
                dataGridViewOrders.Columns.Add("OrderId", "ID");
                dataGridViewOrders.Columns.Add("DriverFullName", "ФИО водителя");
                dataGridViewOrders.Columns.Add("DriverLicense", "Удостоверение");
                dataGridViewOrders.Columns.Add("CarBrandAndModel", "Марка и модель");
                dataGridViewOrders.Columns.Add("DepartureAddress", "Адрес выезда");
                dataGridViewOrders.Columns.Add("DestinationAddress", "Адрес назначения");
                dataGridViewOrders.Columns.Add("StartTime", "Время начала");
                dataGridViewOrders.Columns.Add("Status", "Статус");

                dataGridViewOrders.Columns["OrderId"].DataPropertyName = "OrderId";
                dataGridViewOrders.Columns["DriverFullName"].DataPropertyName = "DriverFullName";
                dataGridViewOrders.Columns["DriverLicense"].DataPropertyName = "DriverLicense";
                dataGridViewOrders.Columns["CarBrandAndModel"].DataPropertyName = "CarBrandAndModel";
                dataGridViewOrders.Columns["DepartureAddress"].DataPropertyName = "DepartureAddress";
                dataGridViewOrders.Columns["DestinationAddress"].DataPropertyName = "DestinationAddress";
                dataGridViewOrders.Columns["StartTime"].DataPropertyName = "StartTime";
                dataGridViewOrders.Columns["Status"].DataPropertyName = "Status";
                dataGridViewOrders.Columns["Status"].ValueType = typeof(bool);

                dataGridViewOrders.DataSource = orders;
                dataGridViewOrders.Visible = true;
                dataGridViewDrivers.Visible = false;
                labelCurrentList.Text = "Список: Заказы";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке заказов: " + ex.Message);
            }
        }

        private void buttonSwitchList_Click(object sender, EventArgs e)
        {
            isDriversList = !isDriversList;
            if (isDriversList)
            {
                LoadDrivers();
                labelCurrentList.Text = "Список: Водители";
            }
            else
            {
                LoadOrders();
                labelCurrentList.Text = "Список: Заказы";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (isDriversList)
            {
                using (var addDriverForm = new AddEditDriverForm(null))
                {
                    if (addDriverForm.ShowDialog() == DialogResult.OK)
                    {
                        Driver newDriver = addDriverForm.Driver;
                        try
                        {
                            dbHelper.AddDriver(newDriver);
                            LoadDrivers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при добавлении водителя: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                using (var addOrderForm = new AddEditOrderForm(null, drivers))
                {
                    if (addOrderForm.ShowDialog() == DialogResult.OK)
                    {
                        Order newOrder = addOrderForm.Order;
                        try
                        {
                            dbHelper.AddOrder(newOrder);
                            LoadOrders();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при добавлении заказа: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (isDriversList)
            {
                if (dataGridViewDrivers.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridViewDrivers.SelectedRows[0].Index;
                    Driver selectedDriver = drivers[selectedRowIndex];

                    using (var editDriverForm = new AddEditDriverForm(selectedDriver))
                    {
                        if (editDriverForm.ShowDialog() == DialogResult.OK)
                        {
                            Driver updatedDriver = editDriverForm.Driver;
                            try
                            {
                                dbHelper.UpdateDriver(updatedDriver);
                                dbHelper.UpdateOrdersForDriverUpdate(updatedDriver.DriverId, updatedDriver.DriverFullName, updatedDriver.DriverLicense, updatedDriver.CarBrand, updatedDriver.CarModel);
                                LoadDrivers();
                                LoadOrders();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при обновлении водителя: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите водителя для редактирования.");
                }
            }
            else
            {
                if (dataGridViewOrders.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridViewOrders.SelectedRows[0].Index;
                    Order selectedOrder = orders[selectedRowIndex];

                    using (var editOrderForm = new AddEditOrderForm(selectedOrder, drivers))
                    {
                        if (editOrderForm.ShowDialog() == DialogResult.OK)
                        {
                            Order updatedOrder = editOrderForm.Order;
                            try
                            {
                                dbHelper.UpdateOrder(updatedOrder);
                                LoadOrders();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при обновлении заказа: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите заказ для редактирования.");
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (isDriversList)
            {
                if (dataGridViewDrivers.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridViewDrivers.SelectedRows[0].Index;
                    Driver selectedDriver = drivers[selectedRowIndex];

                    if (MessageBox.Show("Вы уверены, что хотите удалить водителя?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            dbHelper.DeleteDriver(selectedDriver.DriverId);
                            dbHelper.DeleteOrdersForDriverDeletion(selectedDriver.DriverId);
                            LoadDrivers();
                            LoadOrders();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении водителя: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите водителя для удаления.");
                }
            }
            else
            {
                if (dataGridViewOrders.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridViewOrders.SelectedRows[0].Index;
                    Order selectedOrder = orders[selectedRowIndex];

                    if (MessageBox.Show("Вы уверены, что хотите удалить заказ?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            dbHelper.DeleteOrder(selectedOrder.OrderId);
                            LoadOrders();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении заказа: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите заказ для удаления.");
                }
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isDriversList)
            {
                LoadDrivers();
            }
            else
            {
                LoadOrders();
            }
        }

        private void dataGridViewDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработчик не нужен
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Обработчик не нужен
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDriversList)
            {
                buttonEdit_Click(sender, e); // Используем существующий обработчик кнопки "Изменить"
            }
            else
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDriversList)
            {
                buttonDelete_Click(sender, e); // Используем существующий обработчик кнопки "Удалить"
            }
            else
            {
                buttonDelete_Click(sender, e);
            }
        }

        private void dataGridViewDrivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewDrivers.ClearSelection();
                dataGridViewDrivers.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridViewOrders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewOrders.ClearSelection();
                dataGridViewOrders.Rows[e.RowIndex].Selected = true;
            }
        }

        private void BackupDatabase()
        {
            try
            {
                string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DriversAndOrders.db");
                string backupDirectory = Properties.Settings.Default.BackupPath;

                // Создаем каталог для резервных копий, если он не существует
                Directory.CreateDirectory(backupDirectory);

                string backupFile = Path.Combine(backupDirectory, $"DriversAndOrders_{DateTime.Now:yyyyMMddHHmmss}.db");

                File.Copy(sourceFile, backupFile, true);
                Console.WriteLine($"База данных успешно скопирована в {backupFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании резервной копии базы данных: {ex.Message}");
            }
        }

        private void backupTimer_Tick(object sender, EventArgs e)
        {
            BackupDatabase();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}