namespace ITEC_145___Section_C___Trey_Hall
{
    public partial class Form1 : Form
    {
        List<string> dataList = new List<string>();
        int dgRowIndex;

        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader dataInput = new StreamReader(openFileDialog1.FileName);

                while (!dataInput.EndOfStream)
                {
                    dataList.Add(dataInput.ReadLine());
                }
                dataInput.Close();

                txtLoad.Text = $"Read {dataList.Count.ToString()} records. Data List now has {dataList.Count.ToString()} records.";

            }


        
        }

        private void btnToGrid_Click(object sender, EventArgs e)
        {
            foreach(string tmpStr in dataList)
            {
                string[] tmpStringArr = tmpStr.Split(",");

                dataGridView1.Rows.Add(tmpStringArr);

            }

            txtToGrid.Text = $"Added {dataList.Count.ToString()} records to Grid View.";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
                {
                    for(int f = 0; f < dataGridView1.Columns.Count; f++)
                    {
                        sw.Write($"{dataGridView1.Rows[i].Cells[f].Value}");

                        if(f != dataGridView1.Columns.Count - 1)
                        {

                        }

                    }
                    sw.WriteLine();

                }

                
            }
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //Thanks Steve
            dgRowIndex = e.RowIndex;

            //Put it in a while loop so it only creates the button once
            while (count == 0)
            {
                Button btnDelete = new Button();
                btnDelete.Text = "Delete Cell";
                btnDelete.Size = new Size(177, 23);
                btnDelete.Left = 459;
                btnDelete.Top = 41;
                btnDelete.BackColor = Color.White;
                //Just looked at the refrences for other buttons and added this line
                //ESSENTIAL for the button to actually function
                btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

                Controls.Add(btnDelete);
                count++;
            }


        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");

        }




    }


}