using System;
using System.IO;
using System.Windows.Forms;

namespace WFDP
{
    public partial class CodeEditor : Form
    {
        private string _sourceCode;

        public string SourceCode
        {
            get { return _sourceCode; }
        }

        public CodeEditor(string path)
        {
            _sourceCode = File.ReadAllText(path);
            InitializeComponent();
        }

        private void CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sourceCode = tbCode.Text;
            DialogResult = DialogResult.OK;
        }

        private void CodeEditor_Load(object sender, EventArgs e)
        {
            tbCode.Text = _sourceCode;
        }
    }
}
