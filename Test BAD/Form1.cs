using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Test_BAD
{
    public partial class Form1 : Form
    {
        private string InputText { get; set; }
        private List<char> FirstSymbols { get; set; } = new List<char>();
        public Form1()
        {
            InitializeComponent();
            InputTextBox.Text += "The Tao gave birth to machine language.  Machine language gave birth\r\nto the assembler.\r\nThe assembler gave birth to the compiler.  Now there are ten thousand\r\nlanguages.\r\nEach language has its purpose, however humble.  Each language\r\nexpresses the Yin and Yang of software.  Each language has its place within\r\nthe Tao.\r\nBut do not program in COBOL if you can avoid it.\r\n        -- Geoffrey James, \"The Tao of Programming\"";
        }

        private void ResultButton_Click(object sender, System.EventArgs e)
        {
            ResultTextBox.Text = "";
            FirstSymbols = new List<char>();
            try
            {
            InputText = InputTextBox.Text;

            Regex trimmer = new Regex(@"\s\s+");
            InputText = trimmer.Replace(InputText, " ");

            var splitedWords = InputText
                .Split()
                .Select(x => x
                             .Trim(InputText
                             .Where(Char.IsPunctuation)
                             .Distinct()
                             .ToArray())).ToList();
            splitedWords.ForEach(x => x.Replace(".", string.Empty));
            splitedWords.RemoveAll(x=>x=="");
            splitedWords.ForEach(f => FirstSymbols.Add(f.GroupBy(x => x).FirstOrDefault(g => g.Count() == 1).Key));
            ResultTextBox.Text += FirstSymbols.GroupBy(x => x).FirstOrDefault(f=>f.Count()==1).Key;
            Console.WriteLine();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
