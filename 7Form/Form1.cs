using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _7Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FilterButton(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox2.Text = GetStringBetweenBrackets(textBox1.Text);
            }
        }
        private String GetStringBetweenBrackets(String str)
        {
            if (str.Contains('(') && str.Contains(')'))
            {
                int a = str.IndexOf('(') + 1;
                int b = str.IndexOf(')');
                String result = str.Substring(a, b - a);
                return result;
            }
            else return "круглые скобки отсутствуют";
        }

        private void FilterWordsButton(object sender, EventArgs e)
        {
            if (textBox3.Text != "" &&
                textBox4.Text != "" && Сheck(textBox4.Text))
            {
                GetRepeatedWords(textBox3.Text, Convert.ToInt32(textBox4.Text));
            }
        }
        private bool Сheck(String s)
        {
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsDigit(arr[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private void GetRepeatedWords(string str1, int amount)
        {
            textBox5.Clear();
            string[] arr = str1.ToLower().Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim('.', ',');
            }
            string[] arr1 = arr.Where(x => arr.Count(z => z == x) > amount).Distinct().ToArray();
            foreach (String item in arr1)
            {
                textBox5.AppendText(item + Environment.NewLine);
            }
        }
    }
}
