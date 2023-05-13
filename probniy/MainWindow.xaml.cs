﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace probniy
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public PoprigunEntities1 db = new PoprigunEntities1();
		public MainWindow()
		{
			InitializeComponent();
			agents.ItemsSource = db.Agents.ToList();
			typee.ItemsSource = db.Agents.ToList();
			//typee.ItemsSource += "Все типы";
		}

		private void poisk_TextChanged(object sender, TextChangedEventArgs e)
		{
			using (PoprigunEntities1 db = new PoprigunEntities1())
			{
				//agents.ItemsSource = db.Agents.Where(x => x.AgentName == poisk.Text || x.AgentEmail == poisk.Text || x.AgentPhone == poisk.Text).ToList();
				agents.ItemsSource = db.Agents.ToList().Where(c => c.AgentName.Contains(poisk.Text) || c.AgentEmail.Contains(poisk.Text) || c.AgentPhone.Contains(poisk.Text));
				if (poisk.Text == "все")
				{
					agents.ItemsSource = db.Agents.ToList();
				}	
			}
		}

		private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
		{
			var item = db.Agents.ToList().Where(x => x.AgentType == typee.SelectedItem.ToString());
			agents.ItemsSource = db.Agents.ToList().Where(x => x.AgentType == typee.SelectedItem.ToString());
		}

		private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
		{

		}

		private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
		{

		}

		private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
		{
			
		}

		private void agents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			//kolVO.Text = db.ProductSale.FirstOrDefault(x => x.ProductCount)
		}

		private void redaktir_Click(object sender, RoutedEventArgs e)
		{
			if (redaktir.Content.ToString() == "Добавить")
			{
				Redakt red = new Redakt();
				red.Show();
				this.Close();
			}
			else if (redaktir.Content == "Редактировать")
			{
				var ret = (Agents)agents.SelectedItem;
				Redakt red = new Redakt(ret);
				red.Show();
				this.Close();
				red.Name.Text = Name.Text;
				red.email.Text = ret.AgentEmail;
				red.phone.Text = ret.AgentPhone;
				red.adrs.Text = ret.AgentAddress;
				red.prior.Text = ret.AgentPrioritet.ToString();
				red.director.Text = ret.Director;
				red.INN.Text = ret.AgentINN;
				red.KPP.Text = ret.AgentKPP;
				red.logo = null;
				red.typee.Text = ret.AgentType.ToString();
				red.@new.Content = "Сохранить данные";
			}	

		}

		private void Name_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Name.Text != null)
			{
				redaktir.Content = "Редактировать";
			}
			else { redaktir.Content = "Добавить"; }
		}
	}
}
