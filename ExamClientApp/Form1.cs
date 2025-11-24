using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.Logging;
using System.Windows.Forms;

namespace ExamClientApp
{
    public partial class Form1 : Form
    {
        int currentQuestionIndex = 0;
        int correctCount = 0;
        int wrongCount = 0;

        int?[] studentAnswers;

        bool checkAnswers = false;

        HubConnection connection;
        int countdown = 10;

        List<(string Question, string[] Options, int CorrectIndex)> questions =
            new List<(string, string[], int)>
        {
            ("ChatGPT gibi büyük dil modelleri hangi tür yapay zekâ kategorisine girer?",
             new [] {"Uzman Sistemler","Büyük Dil Modelleri (LLM)","Karar Aðaçlarý","Genetik Algoritmalar"}, 1),

            ("Transformers mimarisi ilk olarak hangi yýl tanýtýldý?",
             new [] {"2015","2017","2019","2021"}, 1),

            ("OpenAI’nin 2025’te duyurduðu GPT-5’in en önemli özelliði nedir?",
             new [] {"Görsel ve ses entegrasyonu","Sadece metin üretimi","Sadece kod yazma","Veri tabaný yönetimi"}, 0),

            ("Claude yapay zekâ modeli hangi þirket tarafýndan geliþtirildi?",
             new [] {"Anthropic","Google","Microsoft","Meta"}, 0),

            ("Microsoft Copilot hangi platformlarda kullanýlabiliyor?",
             new [] {"Sadece Windows","Windows, Mac, Web, iOS, Android","Sadece Xbox","Sadece Edge"}, 1),

            ("Yapay zekâda 'hallucination' terimi neyi ifade eder?",
             new [] {"Doðru bilgi üretimi","Yanlýþ veya uydurma bilgi üretimi","Görsel iþleme","Ses tanýma"}, 1),

            ("Stable Diffusion hangi alanda kullanýlan bir yapay zekâ modelidir?",
             new [] {"Görüntü üretimi","Ses sentezi","Veri analizi","Robotik"}, 0),

            ("Yapay zekâ etik tartýþmalarýnda en sýk gündeme gelen konu nedir?",
             new [] {"Veri gizliliði","Donaným maliyeti","Ýnternet hýzý","Yazýlým lisanslarý"}, 0),

            ("Reinforcement Learning hangi tür problemler için uygundur?",
             new [] {"Görüntü sýnýflandýrma","Deneme-yanýlma ile öðrenilen karar problemleri","Metin özetleme","Veri tabaný sorgularý"}, 1),

            ("Yapay zekâ ile üretilen içeriklerde telif hakký sorunu nasýl tartýþýlýyor?",
             new [] {"Ýçerikler her zaman özgün kabul edilir","Ýçeriklerin sahipliði belirsizdir","Ýçerikler kamu malýdýr","Ýçerikler sadece üreticiye aittir"}, 1),
        };

        public Form1()
        {
            InitializeComponent();
            studentAnswers = new int?[questions.Count];
        }

        private void StartCountdown()
        {
            this.Invoke(new Action(async () =>
            {
                while (countdown > 0)
                {
                    lblCountDown.Text = $"UYGULAMA {countdown} SANÝYE ÝÇÝNDE KAPANACAK";
                    await Task.Delay(1000);
                    countdown--;
                }

                this.Close();
            }));
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7155/examHub")
                .WithAutomaticReconnect()
                .Build();

            connection.On("ExamEnded", () =>
            {
                StartCountdown();
            });

            await connection.StartAsync();

            //await connection.StartAsync().ConfigureAwait(false);

            ShowQuestion();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void ShowQuestion()
        {
            var q = questions[currentQuestionIndex];
            lblQuestion.Text = q.Question;
            radioButton1.Text = q.Options[0];
            radioButton2.Text = q.Options[1];
            radioButton3.Text = q.Options[2];
            radioButton4.Text = q.Options[3];

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if (studentAnswers[currentQuestionIndex] != null)
            {
                int selected = studentAnswers[currentQuestionIndex].Value;
                if (selected == 0) radioButton1.Checked = true;
                if (selected == 1) radioButton2.Checked = true;
                if (selected == 2) radioButton3.Checked = true;
                if (selected == 3) radioButton4.Checked = true;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                ShowQuestion();
            }

            if (checkAnswers)
            {
                CheckAnswers(currentQuestionIndex);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                ShowQuestion();
            }

            if (checkAnswers)
            {
                CheckAnswers(currentQuestionIndex);
            }
        }

        private void SaveAnswer()
        {
            if (radioButton1.Checked) studentAnswers[currentQuestionIndex] = 0;
            else if (radioButton2.Checked) studentAnswers[currentQuestionIndex] = 1;
            else if (radioButton3.Checked) studentAnswers[currentQuestionIndex] = 2;
            else if (radioButton4.Checked) studentAnswers[currentQuestionIndex] = 3;
            else studentAnswers[currentQuestionIndex] = null; // Hiç seçilmemiþ
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            correctCount = 0;
            wrongCount = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (studentAnswers[i] != null)
                {
                    if (studentAnswers[i] == questions[i].CorrectIndex)
                        correctCount++;
                    else
                        wrongCount++;
                }
            }

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;

            lblResult.Text = $"Doðru: {correctCount}, Yanlýþ: {wrongCount}";
            MessageBox.Show($"Sýnav Bitti!\nDoðru: {correctCount}\nYanlýþ: {wrongCount}");

            btnFinish.Enabled = false;
            btnCheckAnswers.Visible = true;
        }

        private void btnCheckAnswers_Click(object sender, EventArgs e)
        {
            checkAnswers = true;
            CheckAnswers(questions.Count - 1);
        }

        private void CheckAnswers(int i)
        {
            int correctIndex = questions[i].CorrectIndex;

            RadioButton[] radios = { radioButton1, radioButton2, radioButton3, radioButton4 };

            foreach (var rb in radios)
            {
                rb.Font = new Font(rb.Font, FontStyle.Regular);
                rb.BackColor = SystemColors.Control;
            }

            radios[correctIndex].Font = new Font(radios[correctIndex].Font, FontStyle.Bold | FontStyle.Underline);
            radios[correctIndex].BackColor = Color.LightGreen;
        }

    }
}
