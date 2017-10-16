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
    public partial class TeamWindow : Form
    {
        SoccerContext db;

        public TeamWindow()
        {
            InitializeComponent();
            db = new SoccerContext();
            db.Teams.Load();
            dataGridView1.DataSource = db.Teams.Local.ToBindingList();

        }
        //добавление
        private void Teambutadd_Click(object sender, EventArgs e)
        {
            //создаем экземпляр формы
            TeamFormss tform = new TeamFormss();
            //указываем что форма будет диалоговым окном
            DialogResult result = tform.ShowDialog(this);
            //проверяем что возращает диалоговое окно
            if(result==DialogResult.Cancel)
            {
                return;
            }
            //создаем новый экземпляр(сущность)
            Team team = new Team();
            //переноси данные с формы в поля сущности
            //--------------------------------------
            team.Name = tform.textBox1.Text;
            team.Coach = tform.textBox2.Text;
            //---------------------------------------
            //добавляем все в хранилище 
            db.Teams.Add(team);
            //сохраняем изменения
            db.SaveChanges();
            MessageBox.Show("Элементы команды добавлены");
        }

        //редактирование
        private void Teambtnedit_Click(object sender, EventArgs e)
        {
            //проверка на выбор элемента
            if(dataGridView1.SelectedRows.Count>0)
            {
                //сохраняем выбранный элемент
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                //преобразуем выбранный элемент в перемунню id
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                //проверка
                if (converted==false)
                {
                    return;
                }
                //создаем новый экземпляр и сохраняем выбранный
                Team team = db.Teams.Find(id);
                //создаем экземпляр класс
                TeamFormss tform = new TeamFormss();
                //сохраняем в текстбокс данные из БД
                tform.textBox1.Text = team.Name;
                //сохраняем в текстбокс данные из БД
                tform.textBox2.Text = team.Coach;
                //указываем что созданное окно диалоговое
                DialogResult result = tform.ShowDialog(this);
                //проверка
                if(result==DialogResult.Cancel)
                {
                    return;
                }
                //сохраняем данные из формы в Базу данных
                //---------------------------------------
                team.Name = tform.textBox1.Text;
                team.Coach = tform.textBox2.Text;
                //---------------------------------------
                //добавляем все в хранилище 
                db.Teams.Add(team);
                //сохраняем изменения
                db.SaveChanges();
                MessageBox.Show("Элементы изменены!!!!");
            }

        }

        //удалить
        private void Teambtndelete_Click(object sender, EventArgs e)
        {
            //проверка на выбор элемента
            if (dataGridView1.SelectedRows.Count>0)
            {
                //сохраняем выбранный элемент
                int index = dataGridView1.SelectedRows[0].Index;
                
                int id = 0;
                //преобразуем выбранный элемент в перемунню id
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                //проверка
                if (converted==false)
                {
                    return;

                }
                //удаляем выделенный элемент
                Team team = db.Teams.Find(id);
                team.Players.Clear();
                db.Teams.Remove(team);
                db.SaveChanges();

            }
        }

        private void Teambtnitem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                //проверка на выбор элемента
                int index = dataGridView1.SelectedRows[0].Index;
                //преобразуем выбранный элемент в перемунню id
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                //проверка
                if (converted == false)
                {
                    return;
                }
                //Выводим выделенный элемент элемент
                Team team = db.Teams.Find(id);
                listItem.DataSource = team.Players.ToList();
                listItem.DisplayMember = "Name";
            }
            
        }
    }
}
