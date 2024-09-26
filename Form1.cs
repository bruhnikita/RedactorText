namespace RedactorText
{
    public partial class Form1 : Form
    {
        private List<string> файлы = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileNames.Length == 0) return;

            foreach (string файл in openFileDialog1.FileNames)
            {
                Form1 newForm = new Form1();
                newForm.Text = файл;
                newForm.Show();

                try
                {
                    var Читатель = new System.IO.StreamReader(файл);
                    newForm.textBox1.Text = Читатель.ReadToEnd();
                    newForm.файл = файл;
                    Читатель.Close();
                }
                catch (System.IO.FileNotFoundException Ошибка)
                {
                    MessageBox.Show(Ошибка.Message + "\nНет такого файла",
                       "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception Ошибка)
                {
                    MessageBox.Show(Ошибка.Message + "\nНет такого файла",
                       "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private string файл;

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(файл))
            {
                try
                {
                    var Писатель = new StreamWriter(файл, false);
                    Писатель.Write(textBox1.Text);
                    Писатель.Close();
                }
                catch (Exception Ошибка)
                {
                    MessageBox.Show(Ошибка.Message,
                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var Писатель = new StreamWriter(saveFileDialog1.FileName, false);
                        Писатель.Write(textBox1.Text);
                        Писатель.Close();
                    }
                    catch (Exception Ошибка)
                    {
                        MessageBox.Show(Ошибка.Message,
                          "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.FileName = @"data\Text2.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
        }
    }
}