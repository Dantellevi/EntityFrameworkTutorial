using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Practic_many_to_Many
{
    public partial class Form1 : Form
    {

        Context db;//создаем контекст данных
        public Form1()
        {
            db = new Context();
            InitializeComponent();
            db.Players.Load();//загружаем в проект
            dataGridView1.DataSource = db.Players.Local.ToBindingList();//загружаем в датагрид

        }

        private void addPl_Click(object sender, EventArgs e)
        {
            PlayerForm plf = new PlayerForm();//создаем экземпляр формы добавления
            List<Team> teams = db.Teams.ToList();//сохраняем данные о командах в список
            plf.listBox1.DataSource = teams;//переносим данные в список
            plf.listBox1.ValueMember = "Id";//свойство которое должно использовать при запросе
            plf.listBox1.DisplayMember = "Name";//свойство которое выводится при запросе

            DialogResult result = plf.ShowDialog(this);//создаем диалоговое окно

            if(result==DialogResult.Cancel)//проверяем
            {

                return;
            }

            Player player = new Player();//создаем новый объект игрок
            player.Age = (int)plf.numericUpDown1.Value;//сохраняем возраст
            player.Position = plf.textBoxPosit.Text;//сохраняем позицию
            player.Name = plf.textBoxName.Text;//имя

            teams.Clear(); // очищаем список и заново заполняем его выделенными элементами

            foreach(var item in plf.listBox1.SelectedItems)
            {
                teams.Add((Team)item);
            }

            player.Teams = teams;//сохраняем изменения выбранной команды
            db.Players.Add(player);//добавляем в базу новые данные 
            db.SaveChanges();//сохранем результат
            MessageBox.Show("Новый игрок добавлен");

        }

        private void butedit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count<1)//проверяем чтобы был выделен объект
            {
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;//сохраняем в индекс
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id); //извлекаем данные из столбца

            if(converted==false)
            {
                return;
            }

            Player player = db.Players.Find(id);//ищем необходимый объект

            PlayerForm plForm = new PlayerForm();//открываем форму редактирования
            plForm.numericUpDown1.Value = player.Age;
            plForm.textBoxName.Text = player.Name;
            plForm.textBoxPosit.Text = player.Position;
            // получаем список команд 
            List<Team> teams = db.Teams.ToList();
            plForm.listBox1.DataSource = teams;
            plForm.listBox1.ValueMember = "Id";
            plForm.listBox1.DisplayMember = "Name";
            foreach (Team t in player.Teams)
                plForm.listBox1.SelectedItem = t;

            DialogResult result = plForm.ShowDialog(this);

            if(result==DialogResult.Cancel)
            {
                return;
            }

            // проверяем наличие команд у игрока
            foreach (var team in teams)
            {
                if (plForm.listBox1.SelectedItems.Contains(team))
                {
                    if (!player.Teams.Contains(team))
                        player.Teams.Add(team);
                }
                else
                {
                    if (player.Teams.Contains(team))
                        player.Teams.Remove(team);
                }
            }

            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Информация обновлена");
        }

        private void butdelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count<1)
            {
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

            if(converted==false)
            {
                return;
            }

            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();

            MessageBox.Show("Футболист удален");

        }

        private void butaddTeam_Click(object sender, EventArgs e)
        {
            TeamForm tmForm = new TeamForm();

            DialogResult result = tmForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            Team team = new Team();
            team.Name = tmForm.textBoxNameTeam.Text;
            team.Coach = tmForm.textBoxNameCoych.Text;
            team.Players = new List<Player>();

            db.Teams.Add(team);
            db.SaveChanges();
            MessageBox.Show("Новая команда добавлена");
        }
    }
}
