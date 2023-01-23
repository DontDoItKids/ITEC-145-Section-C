namespace ITEC_145___Section_C___Trey_Hall
{
    public partial class Form1 : Form
    {
        List<string> dataList = new List<string>();
        

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
            //saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(DataGridViewRow DGRow in dataGridView1.Rows)
                {
                    if (DGRow.Cells[0].Value != null)
                    {
                        StreamWriter outputData = new StreamWriter(saveFileDialog1.FileName);
                        outputData.WriteLine(DGRow.Cells[0].Value.ToString());

                        outputData.Close();
                    }
                }
                

            }
        }
    }


}