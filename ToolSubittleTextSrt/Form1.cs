using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ToolSubittleTextSrt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Assign events to ListBox
            listbxData.DragEnter += listbxData_DragEnter;
            listbxData.DragDrop += listbxData_DragEnter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Subtitle files (*.srt;*.vtt)|*.srt;*.vtt";
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

        private void btnDeleteMutilveFile_Click(object sender, EventArgs e)
        {
            // List of conditions to keep files
            var keepConditions = new List<string>
                {
                    "English",
                    "Vietnamese"
                };

            // Iterate through the list of files in ListBox
            for (int i = listbxData.Items.Count - 1; i >= 0; i--)
            {
                string fileName = listbxData.Items[i].ToString();

                // Check if the file does not contain the keywords to keep
                bool shouldDelete = !keepConditions.Any(condition => fileName.Contains(condition, StringComparison.OrdinalIgnoreCase));

                if (shouldDelete)
                {
                    try
                    {
                        // Delete file
                        File.Delete(fileName);
                        // Remove file from ListBox after successful deletion
                        listbxData.Items.RemoveAt(i);
                    }
                    catch (Exception ex)
                    {
                        // Display error message if there is an issue deleting the file
                        MessageBox.Show($"Error deleting file: {fileName}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void listbxData_DragDrop(object sender, DragEventArgs e)
        {
            // Get the list of files being dragged in
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Add the files to ListBox
            foreach (var file in files)
            {
                listbxData.Items.Add(file);
            }
        }

        private void listbxData_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Allow file drop
            }
            else
            {
                e.Effect = DragDropEffects.None; // Do not allow drop
            }
        }
    }
}