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
    /// Логика взаимодействия для AgentList.xaml
    /// </summary>
    public partial class AgentList : Page
    {
        public AgentList()
        {
            InitializeComponent();
            var filtItems = Transition.Context.AgentType.ToList();
            filtItems.Insert(0, new AgentType { Title = "Все типы" });
            AgentTypeBox.ItemsSource = filtItems;

            AgentTypeBox.SelectedIndex = 0;
            SortCBox.SelectedIndex = 0;

            ListAgent.ItemsSource = Transition.Context.Agent.ToList();
        }

        public void DataView()
        {
            var tempDataAgent = Transition.Context.Agent.ToList();

            if (AgentTypeBox.SelectedIndex > 0)
                tempDataAgent = tempDataAgent.Where(p => p.AgentTypeID == (AgentTypeBox.SelectedItem as AgentType).ID).ToList();

            if (SearchAgentBox.Text != "Введите для поиска" && SearchAgentBox.Text != null)
                tempDataAgent = tempDataAgent.Where(p => p.Title.ToLower().Contains(SearchAgentBox.Text.ToLower())
                    || p.Email.ToLower().Contains(SearchAgentBox.Text.ToLower()) || p.Phone.ToLower().Contains(SearchAgentBox.Text.ToLower()))
                    .ToList();
            switch (SortCBox.SelectedIndex)
            {
                case 1:
                    {
                        if (!(bool)CheckSort.IsChecked)
                            tempDataAgent = tempDataAgent
                                    .OrderBy(p => p.Title)
                                    .ToList();
                        else
                            tempDataAgent = tempDataAgent
                                    .OrderByDescending(p => p.Title)
                                    .ToList();

                        ListAgent.ItemsSource = tempDataAgent;
                        break;
                    }
                case 2:
                    {
                        if (!(bool)CheckSort.IsChecked)
                            tempDataAgent = tempDataAgent
                                    .OrderBy(p => p)
                                    .ToList();
                        else
                            tempDataAgent = tempDataAgent
                                    .OrderByDescending(p => p)
                                    .ToList();

                        ListAgent.ItemsSource = tempDataAgent;
                        break;
                    }
                case 3:
                    {
                        if (!(bool)CheckSort.IsChecked)
                            tempDataAgent = tempDataAgent
                                    .OrderBy(p => p.Priority)
                                    .ToList();
                        else
                            tempDataAgent = tempDataAgent
                                    .OrderByDescending(p => p.Priority)
                                    .ToList();

                        ListAgent.ItemsSource = tempDataAgent;
                        break;
                    }
            }
            ListAgent.ItemsSource = tempDataAgent;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Transition.MainFrame.Navigate(new AddAgent());
        }

        private void SortCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView();
        }

        private void SearchAgentBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchAgentBox.Text))
                SearchAgentBox.Text = "Введите для поиска";
        }

        private void SearchAgentBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchAgentBox.Text != "Введите для поиска")
                DataView();
        }

        private void SearchAgentBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchAgentBox.Text = null;
        } 

        private void AgentTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView();
        }

        private void ListAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataView();
        }

        private void CheckSort_Checked(object sender, RoutedEventArgs e)
        {
            DataView();
        }

        private void CheckSort_Unchecked(object sender, RoutedEventArgs e)
        {
            DataView();
        }
    }
}
