// using System.Windows.Forms;

namespace WinFormPractice
{
    public partial class FrmMain : Form
    {
        private Button[] buttons = new Button[100];
        private int treasurePosition;  // 보물 위치
        //private Timer gameTimer;  // 타이머
        private System.Windows.Forms.Timer deathTimer;  // 타이머
        private int timeLeft = 10;  // 제한 시간
        private const int maxTime = 10; // 최대 시간

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 타이머 설정
            deathTimer = new System.Windows.Forms.Timer();
            deathTimer.Interval = 1000;  // 1초
            deathTimer.Tick += GameTimer_Tick;

            // ProgressBar 설정
            progressBar1.Maximum = maxTime; // 제한시간 10초
            progressBar1.Value = 0; // 초기값 0

            // 버튼 초기화
            int i = 0;
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    buttons[i] = btn;
                    btn.Tag = i;
                    btn.Click += Btn_Click;
                    i++;
                }
            }

            // 보물 위치 랜덤 설정
            Random rand = new Random();
            treasurePosition = rand.Next(100);
            Console.WriteLine(treasurePosition);

            // 게임 시작
            StartGame();
        }

        private void StartGame()
        {
            timeLeft = maxTime;
            progressBar1.Value = 0;
            deathTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                progressBar1.Value = maxTime - timeLeft;
            }
            else
            {
                deathTimer.Stop();  // 타이머 종료
                MessageBox.Show("실패.", "게임 종료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetGame();
            }
        }

        private async void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;

            if (index == treasurePosition)
            {
                btn.BackColor = Color.Gold;
                btn.Text = "👑";
                deathTimer.Stop();  // 타이머 종료
                MessageBox.Show("보물 발견", "게임 승리", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetGame();
            }
            else
            {
                btn.Enabled = false;
                btn.Text = "❌";
            }
        }

        private void ResetGame()
        {
            // 게임 초기화
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != null)
                {
                    buttons[i].Enabled = true;
                    buttons[i].Text = "";
                    buttons[i].BackColor = Color.White;
                }
            }

            // 보물 위치 랜덤 지정
            Random rand = new Random();
            treasurePosition = rand.Next(100);
            Console.WriteLine(treasurePosition);

            // 게임 시작
            StartGame();
        }
    }
}
