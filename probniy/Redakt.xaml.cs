using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace probniy
{
	/// <summary>
	/// Логика взаимодействия для Redakt.xaml
	/// </summary>
	public partial class Redakt : Window
	{
		public Agents agent1 = new Agents();
		public PoprigunEntities1 db = new PoprigunEntities1();
		public Redakt(Agents agent1 = null)
		{
			InitializeComponent();
			this.agent1 = agent1;
			typee.ItemsSource = db.Types.ToList();
		}
		public void Update()
		{
			MainWindow mw = new MainWindow();
			mw.agents.ItemsSource = db.Agents.ToList();
		}
		private void new_Click(object sender, RoutedEventArgs e)
		{
			using (PoprigunEntities1 db = new PoprigunEntities1())
			{
				if (@new.Content.ToString() == "Добавить")
				{
					Agents ag = new Agents { AgentType = typee.Text.ToString(), AgentName = Name.Text, AgentEmail = email.Text, AgentPhone = phone.Text, AgentLogo = null, AgentAddress = adrs.Text, AgentPrioritet = Convert.ToInt32(prior.Text), Director = director.Text, AgentINN = INN.Text, AgentKPP = KPP.Text };
					db.Agents.Add(ag);
					db.SaveChanges();
					Update();
				}
				else if (@new.Content == "Сохранить данные")
				{
					Agents agent = agent1;
					agent.AgentType = typee.Text;
					agent.AgentName = Name.Text;
					agent.AgentEmail = email.Text;
					agent.AgentPhone = phone.Text;
					agent.AgentLogo = null;
					agent.AgentAddress = adrs.Text;
					agent.AgentPrioritet = Convert.ToInt32(prior.Text );
					agent.Director= director.Text;
					agent.AgentINN = INN.Text;
					agent.AgentKPP = KPP.Text;

					db.Agents.AddOrUpdate(agent);
					db.SaveChanges();
					Update();
				}
				MessageBox.Show("Успешно");

			}
        }

		private void delete_Click(object sender, RoutedEventArgs e)
		{
			var deleted = db.Agents.ToList().FirstOrDefault(x => x.AgentName==Name.Text);
			db.Agents.Remove(deleted);
			db.SaveChanges();
			Update();
			MessageBox.Show("Агент удален");
		}

		private void exit_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}
