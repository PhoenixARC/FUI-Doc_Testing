using System;
using System.IO;
using System.Windows.Forms;

namespace FUI_Doc_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public FourJUserInterface.Functions FUI0 = new FourJUserInterface.Functions();
        public FourJUserInterface.FUI FUI = new FourJUserInterface.FUI();

        private void LoadButton_Click(object sender, EventArgs e)
        {
            Console.Clear(); 
            FUI = new FourJUserInterface.FUI(); 
            FUI0 = new FourJUserInterface.Functions();
            FUI0.OpenFUI(textBox1.Text, FUI);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "FUI Files|*.fui";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = opf.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream filestream = new FileStream("out.txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.CurrentDirectory + "\\Controls720.fui";
        }


    }
}
