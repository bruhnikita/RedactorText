namespace RedactorText
{
    public partial class Form1 : Form
    {
        private List<string> ����� = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileNames.Length == 0) return;

            foreach (string ���� in openFileDialog1.FileNames)
            {
                Form1 newForm = new Form1();
                newForm.Text = ����;
                newForm.Show();

                try
                {
                    var �������� = new System.IO.StreamReader(����);
                    newForm.textBox1.Text = ��������.ReadToEnd();
                    newForm.���� = ����;
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
        }

        private string ����;

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(����))
            {
                try
                {
                    var �������� = new StreamWriter(����, false);
                    ��������.Write(textBox1.Text);
                    ��������.Close();
                }
                catch (Exception ������)
                {
                    MessageBox.Show(������.Message,
                      "������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                saveFileDialog1.FileName = "";
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
            openFileDialog1.Multiselect = true;
        }
    }
}