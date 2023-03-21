namespace FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lstCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = lstCity.GetItemText(lstCity.SelectedItem);
            //MessageBox.Show(text);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
        }
    }
}