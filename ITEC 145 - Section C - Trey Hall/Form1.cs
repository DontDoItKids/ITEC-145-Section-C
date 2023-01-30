namespace ITEC_145___Section_C___Trey_Hall
{
    public partial class Form1 : Form
    {
        List<string> dataList = new List<string>();

        int dgRowIndex;
        int count = 0; //Should have made it -1 so starts with nothing selected

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
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
                {
                    for(int f = 0; f < dataGridView1.Columns.Count; f++)
                    {
                        sw.Write($"{dataGridView1.Rows[i].Cells[f].Value},");

                        if (f == dataGridView1.Columns.Count - 1)
                        {
                            sw.WriteLine();
                        }

                    }

                }
                sw.Close();
            }

        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgRowIndex = e.RowIndex;

            //Put it in a while loop so it only creates the button once
            while (count == 0)
            {
                Button btnDelete = new Button();
                btnDelete.Text = "Delete Row";
                btnDelete.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 9.75F, System.Drawing.FontStyle.Bold);
                btnDelete.Size = new Size(177, 23);
                btnDelete.Left = 459;
                btnDelete.Top = 42;
                btnDelete.BackColor = Color.White;
                btnDelete.FlatStyle = FlatStyle.Flat;


                //Just looked at the refrences for other buttons and added this line
                //its ESSENTIAL for the button to actually function
                btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

                Controls.Add(btnDelete);
                count++;
            }

        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dgRowIndex);
            //was suppose to also remove the data from the list!!!
        }

    }

}