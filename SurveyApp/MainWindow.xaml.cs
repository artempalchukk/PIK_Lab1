using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SurveyApp
{
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            InitializeComponent();
            _answers = new string[_questions.Count];
            ProgressBar.Maximum = _questions.Count;
            ShowQuestion(0);
        }

        private void ShowQuestion(int index)
        {
            QuestionText.Text = _questions[index];
            AnswerBox.Text = _answers[index] ?? string.Empty;
            AnswerBox.Focus();

            ProgressText.Text = string.Format("{0} / {1}", index + 1, _questions.Count);
            ProgressBar.Value = index + 1;

            PrevButton.IsEnabled = index > 0;
            NextButton.Content = (index == _questions.Count - 1) ? "Зберегти результати" : "Далі →";
            StatusText.Text = string.Empty;
        }

        private void SaveCurrentAnswer()
        {
            _answers[_currentIndex] = AnswerBox.Text.Trim();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentAnswer();
            _currentIndex--;
            ShowQuestion(_currentIndex);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
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

        private void AnswerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                NextButton_Click(sender, new RoutedEventArgs());
                e.Handled = true;
            }
        }

        private void FinishSurvey()
        {
            bool hasAnswer = false;
            foreach (string a in _answers)
                if (!string.IsNullOrWhiteSpace(a)) { hasAnswer = true; break; }

            if (!hasAnswer)
            {
                StatusText.Foreground = new SolidColorBrush(Color.FromRgb(220, 80, 60));
                StatusText.Text = "Будь ласка, дайте відповідь хоча б на одне питання.";
                return;
            }

            try
            {
                string path = SaveResultsToFile();
                ShowCompletionScreen(path);
            }
            catch (Exception ex)
            {
                StatusText.Foreground = new SolidColorBrush(Color.FromRgb(220, 80, 60));
                StatusText.Text = "Помилка збереження: " + ex.Message;
            }
        }

        private string SaveResultsToFile()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = Path.Combine(desktop, "gastro_survey_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");

            using (var w = new StreamWriter(file, false, Encoding.UTF8))
            {
                w.WriteLine("=== ГАСТРОНОМІЧНЕ ОПИТУВАННЯ (WPF) ===");
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
            QuestionText.Text = "Смачно! Дякуємо за відповіді.";
            AnswerBox.IsEnabled = false;
            AnswerBox.Text = string.Empty;
            PrevButton.IsEnabled = false;
            NextButton.IsEnabled = false;
            ProgressText.Text = "Завершено";
            ProgressBar.Value = _questions.Count;
            StatusText.Foreground = new SolidColorBrush(Color.FromRgb(255, 122, 47));
            StatusText.Text = "Збережено: " + filePath;
        }
    }
}
