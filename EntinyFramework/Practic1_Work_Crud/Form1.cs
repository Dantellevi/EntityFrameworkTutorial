using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practic1_Work_Crud
{
    public partial class Form1 : Form
    {
        //создаем контекст данных
        PlayerContext db;
        public Form1()
        {
            InitializeComponent();
            db = new PlayerContext();
            //загружаем данные
            db.Players.Load();

            //переносим данные в GridView
            dataGridView1.DataSource = db.Players.Local.ToBindingList();



        }


        //добавление элемента в базу данных
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //создаем экземпляр окна редактирования
            EditWin edit = new EditWin();
            //создаем экземпляр класса DialogResult и помещаем в его форму редоктирования
            DialogResult result = edit.ShowDialog(this);
            //если возращается Cancel завершить операцию
            if (result == DialogResult.Cancel)
            {
                return;

            }
            //новый экземпляр Player
            Player pl = new Player();
            //------------------------------------------------помещаем в поля класса Player поля из формы редактирования-----------------------------
            pl.Age = (int)edit.numericUpDown1.Value;
            pl.Name = edit.textBox1.Text;
            pl.Position = edit.comboBox1.SelectedItem.ToString();
            //---------------------------------------------------
            //++++++++++++++добавляем все в базу данных и сохраняем изменения-------------------
            db.Players.Add(pl);
            db.SaveChanges();
            //-----------------------------------------------------------------------------------

            MessageBox.Show("Элементы добавлены в базу данных!!!");


        }

        //редактирование элемента в базе данных
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //проверяем выбран ли какой то из элементов, если да 
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //считываем индекс выбранного элемента
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                //парсим значения первого столбца и помещаем преобразованное значения в переменную id
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                //если преобразование не удалось то прерываем операцию
                if (converted == false)
                {
                    return;
                }
                //иначе отыскиваем нужный элемент по Id
                Player player = db.Players.Find(id);
                //открываем форму редактирования
                EditWin edit = new EditWin();

                edit.numericUpDown1.Value = player.Age;
                edit.comboBox1.SelectedItem = player.Position;
                edit.textBox1.Text = player.Name;

                DialogResult result = edit.ShowDialog(this);

                //если нажата кнопка Cancel прерываем операцию
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                //------------------------------------------------помещаем в поля класса Player поля из формы редактирования-----------------------------
                player.Age = (int)edit.numericUpDown1.Value;
                player.Name = edit.textBox1.Text;
                player.Position = edit.comboBox1.SelectedItem.ToString();
                //---------------------------------------------------

                db.SaveChanges();
                dataGridView1.Refresh();
                MessageBox.Show("объект обнавлен!!!");



            }

        }

        //удаление элемента из базы данных
        private void buttonDelete_Click(object sender, EventArgs e)
        {

            //проверяем выбран ли какой то из элементов, если да 
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //считываем индекс выбранного элемента
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                //парсим значения первого столбца и помещаем преобразованное значения в переменную id
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                //если преобразование не удалось то прерываем операцию
                if (converted == false)
                {
                    return;
                }
                //иначе отыскиваем нужный элемент по Id
                Player player = db.Players.Find(id);
                db.Players.Remove(player);
                db.SaveChanges();
                MessageBox.Show("элемент удален!!!");


            }
        }
    }
}
