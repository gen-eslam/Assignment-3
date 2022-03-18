using System.IO;
namespace Assignment_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String path = "";
        FileStream fileStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        int count = 0;
        List<String> list = new List<String>();
        
       



        private void isEnabled(String path)
        {

            if (path != null)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
        }



        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

            }
            isEnabled(path);
            fileStream = new FileStream(path, FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(fileStream);
            streamReader = new StreamReader(fileStream);
            String Line;
            while ((Line = streamReader.ReadLine()) != null)
                list.Add(Line);
            streamReader.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]")|| System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers in ID and Age .");
                 textBox1.Clear();
                textBox4.Clear();   
            }


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("please enter all data");
            }
            else
            {
                fileStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(textBox1.Text + '|' + textBox2.Text + '|' + textBox3.Text + '|' + textBox4.Text);
                streamWriter.Flush();
                fileStream.Flush();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show("insert successed");

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            path = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            streamWriter.Close();
            streamReader.Close();
            fileStream.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            streamReader = new StreamReader(fileStream);

            streamReader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (count >= list.Count())
                MessageBox.Show("last element in file");
            else
            textBox5.Text = list[count].ToString().Replace("|", " ") ;
            count++;








        }
    }
}
