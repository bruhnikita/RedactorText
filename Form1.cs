namespace RedactorText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;

            try
            {
                var Читатель = new System.IO.StreamReader(openFileDialog1.FileName);
                textBox1.Text = Читатель.ReadToEnd();
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

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
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
        }
    }
}
