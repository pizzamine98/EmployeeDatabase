
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            EmpFileManager manage = new EmpFileManager();
            manage.filepath = @"C:\Users\Pizzamine98\Documents\empdat.json";
            manage.ReadJson();
            name0.Text = manage.emps[0].Name;
            jobtitle1.Text = manage.emps[0].JobTitle;
            if (true)
            UpdateList();
        }
        public List<string> vool;
        
        private void UpdateList()
        {
            EmpFileManager manage = new EmpFileManager();
            manage.filepath = @"C:\Users\Pizzamine98\Documents\empdat.json";
            if (true)
            {
                manage.filepath = "empdat.json";
            }
            manage.ReadJson();
            List<Employee> ListData = manage.emps;
            namez.ItemsSource = ListData;
            namez.DisplayMemberPath = "Name";
            namez.SelectedValuePath = "Id";
            namez.SelectedValue = "1";
            
            InitializeComponent();
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EmpFileManager manage = new EmpFileManager();
            manage.filepath = @"C:\Users\Pizzamine98\Documents\empdat.json";
            if (true)
            {
                manage.filepath = "empdat.json";
            }
            manage.ReadJson();
            // finding the next available employee id.
            bool found = false;
            int newid = 1;

            while (!found)
            {
                bool hasit = false;
                foreach(Employee emos in manage.emps)
                {
                    if(emos.Id == newid)
                    {
                        hasit = true;
                    }
                }
                if (!hasit)
                {
                    found = true;
                } else
                {
                    newid++;
                }
            }
            Employee tempo = new Employee();
            tempo.Id = newid;
            tempo.Name = name0.Text;
            tempo.JobTitle = jobtitle1.Text;
            manage.emps.Add(tempo);
            manage.WriteJson();
            lastAction.Text = "Employee Added. Number of employees = " + manage.emps.Count;
            UpdateList();
        }
        private void Selecto(object sender, RoutedEventArgs e)
        {
            EmpFileManager manage = new EmpFileManager();
            manage.filepath = @"C:\Users\Pizzamine98\Documents\empdat.json";
            if (true)
            {
                manage.filepath = "empdat.json";
            }
            manage.ReadJson();
            int nemps = manage.emps.Count;
            if (namez.SelectedValue != null)
            {
                for (int iss = 0; iss < nemps; iss++)
                {
                    // finds employee selected
                    if (manage.emps[iss].Id.ToString().Equals(namez.SelectedValue.ToString()))
                    {
                        name0.Text = manage.emps[iss].Name;
                        jobtitle1.Text = manage.emps[iss].JobTitle;

                        iss = nemps;
                    }
                }
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
            EmpFileManager manage = new EmpFileManager();
            manage.filepath = @"C:\Users\Pizzamine98\Documents\empdat.json";
            if (true)
            {
                manage.filepath = "empdat.json";
            }
            manage.ReadJson();
            int nemps = manage.emps.Count;
            for(int iss = 0; iss < nemps; iss++)
            {
                // finds employee selected
                if (manage.emps[iss].Id.ToString().Equals(namez.SelectedValue.ToString()))
                {
                    // modifies them
                    manage.emps[iss].Name = name0.Text;
                    manage.emps[iss].JobTitle = jobtitle1.Text;
                    
                    iss = nemps;
                }
            }
            // writes the modifications to a Json file.
            manage.WriteJson();
            lastAction.Text = "Employee \"" + name0.Text + "\" updated.";
            // updates the list
            UpdateList();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            EmpFileManager manage = new EmpFileManager();
            manage.filepath = @"C:\Users\Pizzamine98\Documents\empdat.json";
            manage.ReadJson();
            int nemps = manage.emps.Count;
            for (int iss = 0; iss < nemps; iss++)
            {
                // finds employee selected
                if (manage.emps[iss].Id.ToString().Equals(namez.SelectedValue.ToString()))
                {
                    // deletes them
                    manage.emps.Remove(manage.emps[iss]);
                    iss = nemps;
                }
            }
            // writes the modifications to a Json file.
            manage.WriteJson();
            lastAction.Text = "Employee Deleted. Number of employees = " + manage.emps.Count;
            // updates the list
            UpdateList();
        }
    }
}
