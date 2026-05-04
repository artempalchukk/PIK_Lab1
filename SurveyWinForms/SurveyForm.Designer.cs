using System.Drawing;
using System.Windows.Forms;

namespace SurveyWinForms
{
    partial class SurveyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.pnlProgress = new Panel();
            this.progressBar = new ProgressBar();
            this.lblProgress = new Label();
            this.pnlQuestion = new Panel();
            this.lblQuestionNum = new Label();
            this.lblQuestion = new Label();
            this.pnlAnswer = new Panel();
            this.txtAnswer = new TextBox();
            this.pnlButtons = new Panel();
            this.btnPrev = new Button();
            this.btnNext = new Button();
            this.lblStatus = new Label();

            this.pnlTop.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            this.pnlAnswer.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // --- Form ---
            this.Text = "Гастрономічне опитування — Windows Forms";
            this.ClientSize = new Size(700, 540);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(15, 36, 25);   // темно-зелений
            this.Font = new Font("Segoe UI", 10F);

            // --- pnlTop (шапка) ---
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 72;
            this.pnlTop.BackColor = Color.FromArgb(20, 50, 34);
            this.pnlTop.Padding = new Padding(24, 10, 24, 8);
            this.pnlTop.Controls.Add(this.lblSubtitle);
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Гастрономічне опитування";
            this.lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(126, 217, 87);
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Height = 34;
            this.lblTitle.Padding = new Padding(0, 4, 0, 0);

            // lblSubtitle
            this.lblSubtitle.Text = "Розкажіть нам про свої смаки та уподобання";
            this.lblSubtitle.Font = new Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = Color.FromArgb(100, 160, 110);
            this.lblSubtitle.Dock = DockStyle.Top;
            this.lblSubtitle.Height = 20;

            // --- pnlProgress ---
            this.pnlProgress.Dock = DockStyle.Top;
            this.pnlProgress.Height = 32;
            this.pnlProgress.BackColor = Color.FromArgb(15, 36, 25);
            this.pnlProgress.Padding = new Padding(24, 8, 24, 0);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.progressBar);

            // progressBar
            this.progressBar.Dock = DockStyle.Fill;
            this.progressBar.Height = 6;
            this.progressBar.Minimum = 0;
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.ForeColor = Color.FromArgb(126, 217, 87);
            this.progressBar.BackColor = Color.FromArgb(40, 70, 50);

            // lblProgress
            this.lblProgress.Dock = DockStyle.Right;
            this.lblProgress.Width = 60;
            this.lblProgress.Font = new Font("Segoe UI", 9F);
            this.lblProgress.ForeColor = Color.FromArgb(100, 160, 110);
            this.lblProgress.TextAlign = ContentAlignment.MiddleRight;

            // --- pnlQuestion ---
            this.pnlQuestion.Dock = DockStyle.Top;
            this.pnlQuestion.Height = 100;
            this.pnlQuestion.BackColor = Color.FromArgb(22, 55, 38);
            this.pnlQuestion.Padding = new Padding(24, 10, 24, 10);
            this.pnlQuestion.Controls.Add(this.lblQuestion);
            this.pnlQuestion.Controls.Add(this.lblQuestionNum);

            // lblQuestionNum
            this.lblQuestionNum.Dock = DockStyle.Top;
            this.lblQuestionNum.Height = 20;
            this.lblQuestionNum.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblQuestionNum.ForeColor = Color.FromArgb(126, 217, 87);
            this.lblQuestionNum.Text = "ПИТАННЯ 1";

            // lblQuestion
            this.lblQuestion.Dock = DockStyle.Fill;
            this.lblQuestion.Font = new Font("Segoe UI", 12.5F);
            this.lblQuestion.ForeColor = Color.FromArgb(220, 245, 220);
            this.lblQuestion.TextAlign = ContentAlignment.MiddleLeft;

            // --- pnlAnswer ---
            this.pnlAnswer.Dock = DockStyle.Fill;
            this.pnlAnswer.BackColor = Color.FromArgb(18, 42, 28);
            this.pnlAnswer.Padding = new Padding(24, 12, 24, 12);
            this.pnlAnswer.Controls.Add(this.txtAnswer);

            // txtAnswer
            this.txtAnswer.Multiline = true;
            this.txtAnswer.ScrollBars = ScrollBars.Vertical;
            this.txtAnswer.Font = new Font("Segoe UI", 12F);
            this.txtAnswer.ForeColor = Color.FromArgb(200, 235, 200);
            this.txtAnswer.BackColor = Color.FromArgb(25, 55, 36);
            this.txtAnswer.BorderStyle = BorderStyle.FixedSingle;
            this.txtAnswer.Dock = DockStyle.Fill;
            this.txtAnswer.KeyDown += new KeyEventHandler(this.txtAnswer_KeyDown);

            // --- pnlButtons ---
            this.pnlButtons.Dock = DockStyle.Bottom;
            this.pnlButtons.Height = 56;
            this.pnlButtons.BackColor = Color.FromArgb(20, 50, 34);
            this.pnlButtons.Padding = new Padding(24, 8, 24, 8);
            this.pnlButtons.Controls.Add(this.btnNext);
            this.pnlButtons.Controls.Add(this.btnPrev);

            // btnPrev
            this.btnPrev.Text = "← Назад";
            this.btnPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnPrev.BackColor = Color.FromArgb(40, 80, 55);
            this.btnPrev.ForeColor = Color.FromArgb(126, 217, 87);
            this.btnPrev.FlatStyle = FlatStyle.Flat;
            this.btnPrev.FlatAppearance.BorderColor = Color.FromArgb(60, 110, 75);
            this.btnPrev.FlatAppearance.BorderSize = 1;
            this.btnPrev.Dock = DockStyle.Left;
            this.btnPrev.Width = 140;
            this.btnPrev.Cursor = Cursors.Hand;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // btnNext
            this.btnNext.Text = "Далі →";
            this.btnNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnNext.BackColor = Color.FromArgb(126, 217, 87);
            this.btnNext.ForeColor = Color.FromArgb(15, 36, 25);
            this.btnNext.FlatStyle = FlatStyle.Flat;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Dock = DockStyle.Right;
            this.btnNext.Width = 200;
            this.btnNext.Cursor = Cursors.Hand;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // --- lblStatus ---
            this.lblStatus.Text = string.Empty;
            this.lblStatus.Font = new Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = Color.FromArgb(126, 217, 87);
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            this.lblStatus.Dock = DockStyle.Bottom;
            this.lblStatus.Height = 36;
            this.lblStatus.BackColor = Color.FromArgb(15, 36, 25);

            // Controls order (bottom-up for Dock)
            this.Controls.Add(this.pnlAnswer);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblStatus);

            this.pnlTop.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.pnlQuestion.ResumeLayout(false);
            this.pnlAnswer.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlProgress;
        private ProgressBar progressBar;
        private Label lblProgress;
        private Panel pnlQuestion;
        private Label lblQuestionNum;
        private Label lblQuestion;
        private Panel pnlAnswer;
        private TextBox txtAnswer;
        private Panel pnlButtons;
        private Button btnPrev;
        private Button btnNext;
        private Label lblStatus;
    }
}
