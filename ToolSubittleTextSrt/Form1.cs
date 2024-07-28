using System.Text.RegularExpressions;
using System.Text;

namespace ToolSubittleTextSrt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Subtitle files (*.srt)|*.srt";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listbxData.Items.Clear();
                    foreach (string file in openFileDialog.FileNames)
                    {
                        listbxData.Items.Add(file);
                    }
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            foreach (string filePath in listbxData.Items)
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();
                Regex regexTimecode = new Regex(@"^\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}$");

                bool isInsideTextBlock = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (regexTimecode.IsMatch(lines[i]))
                    {
                        if (isInsideTextBlock)
                        {
                            sb.AppendLine();
                            isInsideTextBlock = false;
                        }
                        sb.AppendLine(lines[i]);
                    }
                    else if (string.IsNullOrWhiteSpace(lines[i]))
                    {
                        if (isInsideTextBlock)
                        {
                            sb.AppendLine();
                            isInsideTextBlock = false;
                        }
                        sb.AppendLine(lines[i]);
                    }
                    else
                    {
                        if (isInsideTextBlock)
                        {
                            sb.Append(" " + lines[i].Trim());
                        }
                        else
                        {
                            sb.Append(lines[i].Trim());
                            isInsideTextBlock = true;
                        }
                    }
                }

                // Ensure the last line ends properly
                if (isInsideTextBlock)
                {
                    sb.AppendLine();
                }

                File.WriteAllText(filePath, sb.ToString().Trim());
            }

            MessageBox.Show("Processing completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listbxData.Items.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            listbxData.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string filePath in listbxData.Items)
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();
                Regex regexExtraNumber = new Regex(@"^\d+$");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (regexExtraNumber.IsMatch(lines[i]) && i > 0 && string.IsNullOrWhiteSpace(lines[i - 1]) == false)
                    {
                        // Skip this line as it's an extraneous number after a subtitle text
                        continue;
                    }
                    else
                    {
                        sb.AppendLine(lines[i]);
                    }
                }

                File.WriteAllText(filePath, sb.ToString().Trim());
            }

            MessageBox.Show("Extra numbers removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listbxData.Items.Clear();
        }
    }
}
