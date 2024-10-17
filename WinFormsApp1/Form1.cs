namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            RestauranteDAO restauranteDAO = new RestauranteDAO();
            restauranteDAO.GetRestaurantsFromDatabase();

            flowLayoutPanel1.Controls.Clear();
            panel3.BackColor = Color.LightBlue;

            foreach (var restaurant in restauranteDAO.restaurants)
            {
                // Create a new Panel for each restaurant
                Panel panel = new Panel();
                panel.Height = 150; // Adjust the height to fit the image
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = SystemColors.Window;

                // Set width of the panel
                panel.Width = 400; // Adjust as needed

                // Create a PictureBox to display the image
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(100, panel.Height - 20); // Full height of the panel minus margin
                pictureBox.Location = new Point(panel.Width - pictureBox.Width - 10, 10); // Position at right side
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // Load the image from the imagePath (handle exceptions if the file is missing)
                try
                {
                    pictureBox.Image = Image.FromFile(restaurant.imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                    pictureBox.Image = Image.FromFile("default_image_path_here");
                }

                // Create a label for the restaurant name
                Label nameLabel = new Label();
                nameLabel.Text = $"Name: {restaurant.restaurantName}";
                nameLabel.Location = new Point(10, 10); // Adjust position to the left
                nameLabel.AutoSize = true;
                nameLabel.MaximumSize = new Size(panel.Width - pictureBox.Width - 20, 0); // Wrap the text before reaching the image

                // Create a label for the restaurant address
                Label addressLabel = new Label();
                addressLabel.Text = $"Address: {restaurant.restaurantAddress}";
                addressLabel.Location = new Point(10, 40); // Adjust position to the left
                addressLabel.AutoSize = true;
                addressLabel.MaximumSize = new Size(panel.Width - pictureBox.Width - 20, 0); // Wrap the text before reaching the image

                // Add the labels and picture box to the panel
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(addressLabel);
                panel.Controls.Add(pictureBox);

                // Add the panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
            }


        }

        private void Login_Click(object sender, EventArgs e)
        {

            this.Controls.Clear();
            //logic to change the screens here , use as example for other possible screen changes
            // Create an instance of the LoginForm controls (UI)
            LoginForm loginForm = new LoginForm();

            // Transfer all controls from LoginForm to the current form (Form1)
            foreach (Control control in loginForm.Controls)
            {
                this.Controls.Add(control);
            }


            this.Text = "Login";  // Change the window title 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.checkUser();  // Retrieve users from the database

            flowLayoutPanel1.Controls.Clear();
            panel3.BackColor = Color.LightBlue;

            foreach (var user in userDAO.Users)
            {
                // Create a new Panel for each user
                Panel panel = new Panel();
                panel.Height = 150; // Adjust the height to fit the content
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = SystemColors.Window;
                panel.Width = 400; // Set the width for each card

                // Create a label for the user name
                Label nameLabel = new Label();
                nameLabel.Text = $"Name: {user.name}";
                nameLabel.Location = new Point(10, 10); // Adjust position to the left
                nameLabel.AutoSize = true;
                nameLabel.MaximumSize = new Size(panel.Width - 20, 0); // Wrap text to fit the panel width

                // Create a label for the user's date of birth
                Label dobLabel = new Label();
                dobLabel.Text = $"Date of Birth: {user.dateOfBirth.ToString("yyyy-MM-dd")}";
                dobLabel.Location = new Point(10, 40); // Adjust position
                dobLabel.AutoSize = true;
                dobLabel.MaximumSize = new Size(panel.Width - 20, 0); // Wrap text before reaching the panel edge

                // Create a label for the user's gender
                Label genderLabel = new Label();
                genderLabel.Text = $"Gender: {user.gender}";
                genderLabel.Location = new Point(10, 70); // Adjust position
                genderLabel.AutoSize = true;
                genderLabel.MaximumSize = new Size(panel.Width - 20, 0); // Wrap text

                // Add the labels to the panel
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(dobLabel);
                panel.Controls.Add(genderLabel);
                if (user.gender == "Male")
                {
                    panel.BackColor = Color.LightBlue;
                }
                else
                {
                    panel.BackColor = Color.LightGreen;
                }

                // Add the panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
                
            }
        }

    }
}
