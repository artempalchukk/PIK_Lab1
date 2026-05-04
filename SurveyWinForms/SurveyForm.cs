using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SurveyWinForms
{
    public partial class SurveyForm : Form
    {
        private readonly List<string> _questions = new List<string>
        {
            "Яка страва нагадує вам дитинство або рідний дім? Чому саме вона?",
            "Яку кухню світу ви могли б їсти щодня — італійську, японську, мексиканську, українську, або іншу? Що в ній особливого?",
            "Ви скоріше кухар чи гурман? Є у вас фірмова страва, яку ви готуєте краще за всіх?",
            "Складіть своє ідеальне меню на один день: сніданок, обід і вечеря. Що обов'язково має бути на столі?"
        };

        private readonly string[] _answers;
        private int _currentIndex;

        public SurveyForm()
        {
            InitializeComponent();
            _answers = new string[_questions.Count];
            progressBar.Maximum = _questions.Count;
            ShowQuestion(0);
        }

        private void ShowQuestion(int index)
        {
            lblQuestionNum.Text = "ПИТАННЯ " + (index + 1);
            lblQuestion.Text = _questions[index];
            txtAnswer.Text = _answers[index] ?? string.Empty;
            txtAnswer.Focus();
            txtAnswer.SelectAll();

            lblProgress.Text = string.Format("{0} / {1}", index + 1, _questions.Count);
            progressBar.Value = index + 1;

            btnPrev.Enabled = index > 0;
            btnNext.Text = (index == _questions.Count - 1) ? "Зберегти результати" : "Далі →";
            lblStatus.Text = string.Empty;
        }

        private void SaveCurrentAnswer()
        {
            _answers[_currentIndex] = txtAnswer.Text.Trim();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            _currentIndex--;
            ShowQuestion(_currentIndex);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();
            if (_currentIndex < _questions.Count - 1)
            {
                _currentIndex++;
                ShowQuestion(_currentIndex);
            }
            else
            {
                FinishSurvey();
            }
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                btnNext_Click(sender, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void FinishSurvey()
        {
            bool hasAnswer = false;
            foreach (string a in _answers)
                if (!string.IsNullOrWhiteSpace(a)) { hasAnswer = true; break; }

            if (!hasAnswer)
            {
                lblStatus.ForeColor = Color.FromArgb(220, 80, 60);
                lblStatus.Text = "Будь ласка, дайте відповідь хоча б на одне питання.";
                return;
            }

            try
            {
                string path = SaveResultsToFile();
                ShowCompletionScreen(path);
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.FromArgb(220, 80, 60);
                lblStatus.Text = "Помилка збереження: " + ex.Message;
            }
        }

        private string SaveResultsToFile()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = Path.Combine(desktop, "gastro_survey_winforms_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");

            using (var w = new StreamWriter(file, false, Encoding.UTF8))
            {
                w.WriteLine("=== ГАСТРОНОМІЧНЕ ОПИТУВАННЯ (Windows Forms) ===");
                w.WriteLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                w.WriteLine(new string('-', 50));
                w.WriteLine();
                for (int i = 0; i < _questions.Count; i++)
                {
                    w.WriteLine("Питання " + (i + 1) + ":");
                    w.WriteLine(_questions[i]);
                    w.WriteLine("Відповідь: " + (string.IsNullOrWhiteSpace(_answers[i]) ? "(без відповіді)" : _answers[i]));
                    w.WriteLine();
                }
                w.WriteLine(new string('-', 50));
            }

            return file;
        }

        private void ShowCompletionScreen(string filePath)
        {
            lblQuestion.Text = "Смачно! Дякуємо за відповіді.";
            lblQuestion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            txtAnswer.Enabled = false;
            txtAnswer.Text = string.Empty;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            lblProgress.Text = "Завершено";
            progressBar.Value = _questions.Count;
            lblStatus.ForeColor = Color.FromArgb(126, 217, 87);
            lblStatus.Text = "Збережено: " + filePath;
        }
    }
}
