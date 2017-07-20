using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        List<User> Users;
        List<int> InputSymbol = new List<int>();

        public Form1()
        {
            Users = ValidateUser.GetDataFromDatabase();
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                InputSymbol.Clear();
                textBox1.Text = "";
            }

            if (e.KeyCode == Keys.Enter)
            {
                List<int> colMilliseconds = new List<int>();
                for (int i = 1; i < InputSymbol.Count(); i++)
                {
                    colMilliseconds.Add(InputSymbol[i] - InputSymbol[i - 1]);
                }
                Validate(ValidateUser.GetMeanSquareDeviationFromColMilliseconds(colMilliseconds));
            }            
            else if (e.KeyCode != Keys.Back)
                InputSymbol.Add(Convert.ToInt32(DateTime.Now.TimeOfDay.TotalMilliseconds));
            
        }

        // получаем Среднее квадратичное отклонение
        private void Validate(double MeanSquareDeviation)
        {
            User user = ValidateUser.GetUser(Users,  MeanSquareDeviation);

            if (user != null)
            {
                if (user.Password != textBox1.Text.Trim())
                    label2.Text = "Пароль неверный";
                else
                    label2.Text = "Пароль вводит - " + user.UserFio;
            }
            
        }
    }
}
