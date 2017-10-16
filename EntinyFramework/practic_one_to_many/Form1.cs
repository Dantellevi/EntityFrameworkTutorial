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

namespace practic_one_to_many
{
    public partial class Form1 : Form
    {
        SoccerContext db;

        public Form1()
        {
            InitializeComponent();
            db = new SoccerContext();
            db.Players.Load();
            dataGridView1.DataSource = db.Players.Local.ToBindingList();


        }

        //добавление
        private void butadd_Click(object sender, EventArgs e)
        {
            //открывает новое окно для добавления элементов
            PlayerForm pfWindow = new PlayerForm();
            //из базы данных формируем список , только элементы таблицы Team
            List<Team> teams = db.Teams.ToList();
            //привязываем список команд к combobox в форме добавление/редактирования
            pfWindow.comboBox2.DataSource = teams;
            //передаем индификационный ключ для  фактического значения
            pfWindow.comboBox2.ValueMember = "Id";
            //отображаемые данные из столбца
            pfWindow.comboBox2.DisplayMember = "Name";
            //отображаем окно как диалоговое
            DialogResult result = pfWindow.ShowDialog(this);
            //проверяем на результат
            if(result==DialogResult.Cancel)
            {
                return;
            }

            //создаем новый экземпляр Player
            Player player = new Player();
            //присваиваем значения возраста
            player.Age = (int)pfWindow.numericUpDown1.Value;
            //присваиваем значение имени
            player.Name = pfWindow.textBoxName.Text;
            //присваиваем значение позиции
            player.Position = pfWindow.comboBoxPosition.SelectedItem.ToString();
            //присваиваем значения поля команда
            player.Team = (Team)pfWindow.comboBox2.SelectedItem;

            db.Players.Add(player);
            db.SaveChanges();

            MessageBox.Show("Игрок добавлен!!!");

        }


        //редактирования
        private void butedit_Click(object sender, EventArgs e)
        {
            //сохраняем индекс выбранного элемента(Id)
            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            //конвертируем в инт выбранный элемент из таблицы 
            bool convert = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            //проверка конвертации
            if(convert ==false)
            {
                return;
            }
            //создаем новый экземпляр и помещаем в его выбранные данные
            Player player = db.Players.Find(id);
            //новое окно редактирования
            PlayerForm plForm = new PlayerForm();
            //происзоводим перенос данных из базы данных в форму редактирования
            //---------------------------------------------------------------------- 
            plForm.numericUpDown1.Value = player.Age;
            plForm.comboBoxPosition.SelectedItem = player.Position;
            plForm.textBoxName.Text = player.Name;

            List<Team> teams = db.Teams.ToList();
            plForm.comboBox2.DataSource = teams;
            plForm.comboBox2.ValueMember = "Id";
            plForm.comboBox2.DisplayMember = "Name";

            if (player.Team != null)
                plForm.comboBox2.SelectedValue = player.Team.Id;
            //------------------------------------------------------------------------
            //открываем новое окно в качестве диалогового
            DialogResult result = plForm.ShowDialog(this);
            //проверяем резульат диалогового окна
            if(result==DialogResult.Cancel)
            {
                return;
            }


            //присваиваем значения возраста
            player.Age = (int)plForm.numericUpDown1.Value;
            //присваиваем значение имени
            player.Name =plForm.textBoxName.Text;
            //присваиваем значение позиции
            player.Position = plForm.comboBoxPosition.SelectedItem.ToString();
            //присваиваем значения поля команда
            player.Team = (Team)plForm.comboBox2.SelectedItem;

            //установка флаго о том что данные были изменен
            db.Entry(player).State = EntityState.Modified;
            //сохранение изменений
            db.SaveChanges();

            MessageBox.Show("Объект обновлен!!");

        }

        private void butDeleted_Click(object sender, EventArgs e)
        {
            //проверяем чтобы был выбран элемент
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //сохраняем индекс выбранного элемента(Id)
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                //конвертируем в инт выбранный элемент из таблицы 
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                //проверка конвертации
                if (converted == false)
                    return;
                //создаем новый экземпляр и помещаем в его выбранные данные
                Player player = db.Players.Find(id);
                //удаляем элементы из базы данных
                db.Players.Remove(player);
                //сохраняем изменения
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }
        }

        private void butTeam_Click(object sender, EventArgs e)
        {

            TeamWindow window = new TeamWindow();
            window.Show();


        }
    }
}
