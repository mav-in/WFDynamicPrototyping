using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace WFDP
{
    public partial class MainForm : Form
    {
        private IConverter _converter;

        // Прописываем зависимость InProcessCompiler
        [Dependency] public InProcessCompiler Compiler { get; set; }

        // Injection IConverter
        public MainForm(IConverter converter)
        {
            _converter = converter;
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            tbOut.Text = _converter.Convert(tbIn.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var path = @"..\..\HtmlConverter.cs";
            var ce = new CodeEditor(path);

            // Если диалог OK - что-то делаем
            if (ce.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Компилируем программу и добавляем новый экземпляр объекта - Instance
                    //_converter = Compiler.CompileAndInstantiate(ce.SourceCode) as IConverter;
                    _converter = (IConverter) Compiler.CompileAndInstantiate(ce.SourceCode);
                    // Сохраняем новый исходник
                    File.WriteAllText(path, ce.SourceCode, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
