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

namespace Glazki_save.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAgent.xaml
    /// </summary>
    public partial class AddAgent : Page
    {
        public AddAgent()
        {
            InitializeComponent();
            var filtItems = Transition.Context.AgentType.ToList();

            filtItems.Insert(0, new AgentType { Title = "Выберите тип" });
            AgentTypeCombo.ItemsSource = filtItems;
            AgentTypeCombo.SelectedIndex = 0;
        }
        private void DataView()
        {
            var tempDataAgent = Transition.Context.Agent.ToList();

            if (AgentTypeCombo.SelectedIndex > 0)
                tempDataAgent = tempDataAgent.Where(p => p.AgentTypeID == (AgentTypeCombo.SelectedItem as AgentType).ID).ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Agent agent = new Agent()
                {
                    Title = TxtName.Text,
                    AgentType = AgentTypeCombo.SelectedItem as AgentType,
                    Priority = Convert.ToInt32(TxtPriority.Text),
                    Logo = TxtLogo.Text,
                    INN = TxtINN.Text,
                    KPP = TxtKPP.Text,
                    DirectorName = TxtDirector.Text,
                    Address = TxtAddress.Text,
                    Phone = TxtPhone.Text,
                    Email = TxtEmail.Text,
                };
                Transition.Context.Agent.Add(agent);
                Transition.Context.SaveChanges();
                MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
            Transition.MainFrame.GoBack();
        }

        private void AgentTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView();
        }
    }
}
