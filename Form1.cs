namespace KAITECH_Project
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float totalConsumption;
            

            while (true)
            {
                // Read and validate input value from textBox1
                if (!float.TryParse(textBox1.Text, out totalConsumption) || totalConsumption < 0)
                {
                    MessageBox.Show("Please enter a valid positive number for total consumption.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    break;
                }
            }

            // Calculate the bill and chip number
            double billAmount = CalculateBill(totalConsumption, out int chipNumber, out int Customer_Service);
            // Display the results in textBox2
            
            textBox2.Text = $"{billAmount.ToString("F2")} $";
            textBox3.Text = $"{chipNumber}";
            textBox4.Text = $"{Customer_Service} $";
            double Total_price = billAmount + Customer_Service;
            textBox5.Text = $"{Total_price.ToString("F2")} $";
        }

        private static double CalculateBill(float consumption, out int chipNumber, out int Customer_Service)
        {

            double bill = 0;
            
            chipNumber = 0;

            float[] prices = { 0.68f, 0.78f, 0.95f, 1.55f, 1.95f, 2.1f, 2.23f };
            
            if (consumption <= 100)
            {
                if (consumption > 50)
                {
                    bill = (50 * prices[0]) + (consumption - 50) * prices[1];
                    chipNumber = 2; // Chip number for consumption between 51 and 100
                    Customer_Service = 2;
                }
                else
                {
                    bill = consumption * prices[0];
                    chipNumber = 1; // Chip number for consumption up to 50
                    Customer_Service = 1;
                }
            }
            else if (consumption <= 650)
            {
                if (consumption <= 200)
                {
                    Customer_Service = 6;
                    bill = consumption * prices[2];
                    chipNumber = 3; // Chip number for consumption between 101 and 200
                }
                else if (consumption <= 350)
                {
                    Customer_Service = 11;
                    bill = 200 * prices[2] + (consumption - 200) * prices[3];
                    chipNumber = 4; // Chip number for consumption between 201 and 350
                }
                else
                {
                    Customer_Service = 15;
                    bill = 200 * prices[2] + 150 * prices[3] + (consumption - 350) * prices[4];
                    chipNumber = 5; // Chip number for consumption between 351 and 650
                }
            }
            else if (consumption <= 1000)
            {
                Customer_Service = 25;
                bill = consumption * prices[5];
                chipNumber = 6; // Chip number for consumption between 651 and 1000
            }
            else
            {
                Customer_Service = 40;
                bill = consumption * prices[6];
                chipNumber = 7; // Chip number for consumption above 1000
            }

            return bill;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
