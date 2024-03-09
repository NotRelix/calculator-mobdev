namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string operandMath;
        double firstNum, secondNum;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            currentState = 1;
            this.result.Text = "0";
        }

        void SetNum(string text)
        {
            double number;
            if (double.TryParse(text, out number))
            {
                if (currentState == 1)
                {
                    firstNum = number;
                }
                else if (currentState == 2)
                {
                    secondNum = number;
                }
            }
        }

        void OnDelete(object sender, EventArgs e)
        {
            if (this.result.Text.Length > 0)
            {
                this.result.Text = this.result.Text.Remove(this.result.Text.Length - 1);
            }
            if (this.result.Text == "")
            {
                this.result.Text = "0";
            }

            SetNum(this.result.Text);
        }

        void OnNumberSelection(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnPressed = button.Text;

            if (this.result.Text == "0" || currentState < 0)
            {
                this.result.Text = string.Empty;
                if (currentState < 0)
                {
                    currentState *= -1;
                }
            }

            this.result.Text += btnPressed;

            SetNum(this.result.Text);
        }

        void OnOperatorSelection(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string btnPressed = button.Text;
            operandMath = btnPressed;
        }

        void OnPeriod(object sender, EventArgs e)
        {
            if (!this.result.Text.Contains("."))
            {
                this.result.Text += ".";
            }
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Calculate.DoCalculation(firstNum, secondNum, operandMath);
                this.result.Text = result;
                currentState = 1;
                SetNum(result);
            }
        }
    }

}