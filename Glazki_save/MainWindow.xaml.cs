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
using Glazki_save.DataBase;
using Glazki_save.Pages;

namespace Glazki_save
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new AgentList());
            Transition.MainFrame = FrmMain;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Transition.MainFrame.GoBack();
        }
    }
}
