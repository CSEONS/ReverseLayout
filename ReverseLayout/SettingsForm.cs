using System.Windows.Forms;

namespace ReverseLayout
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            Text = "Настройки Reverse Layout";
            Size = new System.Drawing.Size(400, 300);

            var label = new Label
            {
                Text = "Здесь будут настройки приложения",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            Controls.Add(label);
        }
    }
}