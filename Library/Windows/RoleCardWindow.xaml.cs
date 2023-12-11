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
using System.Windows.Shapes;
using Library.Infrastructure;
using Library;
using Library.Infrastructure.ViewModels;
using Library.Pages;
using Library.Infrastructure.Mappers;
using Library.Infrastructure.Database;
using Library.Windows;

namespace Library.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientCardWindow.xaml
    /// </summary>



    public partial class RoleCardWindow : Window
    {
        private RoleViewModel _selectedItem = null;
        private RoleRepository _repository;
        public RoleCardWindow()
        {
            InitializeComponent();
        }

        public RoleCardWindow(RoleViewModel selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                FullName.Text = selectedItem.fio;
            }
            else
            {
                _selectedItem = selectedItem;
                FullName.Text = null;
            }
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _repository = new RoleRepository();
                    if (_selectedItem != null)
                    {
                        var entity = new RoleViewModel
                        {
                            id = _selectedItem.id,
                            fio = FullName.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Update(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Пусто");
                        }
                    }
                    else
                    {
                        var entity = new RoleViewModel
                        {
                            fio = FullName.Text,
                        };
                        if (_repository != null)
                        {
                            _repository.Add(entity);
                            Window.GetWindow(this).Close();
                        }
                        else
                        {
                            MessageBox.Show("Пусто");
                        }
                    }
                
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }   
}
