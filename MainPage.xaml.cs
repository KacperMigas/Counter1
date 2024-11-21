namespace Counter;

public partial class MainPage : ContentPage
{
    private int _counterIndex = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnAddCounterClicked(object sender, EventArgs e)
    {
        var counterLayout = new VerticalStackLayout { Padding = 10 };


        var nameEntry = new Entry
        {
            Placeholder = "Wpisz nazwę licznika",
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Margin = new Thickness(5)
        };

        var nameLabel = new Label
        {
            Text = $"Licznik {_counterIndex++}",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center
        };

        var counterLabel = new Label
        {
            Text = "0",
            FontSize = 25,
            HorizontalOptions = LayoutOptions.Center
        };

        var minusButton = new Button { Text = "-" };
        var plusButton = new Button { Text = "+" };

        int counterValue = 0;

        minusButton.Clicked += (s, e) =>
        {
            counterValue--;
            counterLabel.Text = counterValue.ToString();
        };

        plusButton.Clicked += (s, e) =>
        {
            counterValue++;
            counterLabel.Text = counterValue.ToString();
        };


        nameEntry.TextChanged += (s, e) =>
        {
            nameLabel.Text = string.IsNullOrWhiteSpace(nameEntry.Text)
                ? $"Licznik {_counterIndex}"
                : nameEntry.Text;
        };


        counterLayout.Children.Add(nameEntry);
        counterLayout.Children.Add(nameLabel);
        counterLayout.Children.Add(counterLabel);
        counterLayout.Children.Add(new HorizontalStackLayout { Children = { minusButton, plusButton } });

        CountersStack.Children.Add(counterLayout);
    }
}
