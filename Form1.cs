namespace RedactorText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;

            try
            {
                var �������� = new System.IO.StreamReader(openFileDialog1.FileName);
                textBox1.Text = ��������.ReadToEnd();
                ��������.Close();
            }

            catch (System.IO.FileNotFoundException ������)
            {
                MessageBox.Show(������.Message + "\n��� ������ �����",
               "������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception ������)
            {
                MessageBox.Show(������.Message + "\n��� ������ �����",
               "������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var �������� = new StreamWriter(saveFileDialog1.FileName, false);
                    ��������.Write(textBox1.Text);
                    ��������.Close();
                }

                catch (Exception ������)
                {
                    MessageBox.Show(������.Message,
              "������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.FileName = @"data\Text2.txt";
            openFileDialog1.Filter = "��������� ����� (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "��������� ����� (*.txt)|*.txt|All files (*.*)|*.*";
        }
    }
}
