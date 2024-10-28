namespace Counter.Views
{
    public partial class CounterPage : ContentPage
    {
        public CounterPage()
        {
            InitializeComponent();
            BindingContext = new Models.Count();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Count count)
            {
                // Zapisujemy dane licznika do pliku
                var fileName = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid()}.counter.txt");
                count.Filename = fileName;
                File.WriteAllText(fileName, $"{count.Title}|{count.Value}");

                // Przekierowanie po zapisaniu licznika
                await Shell.Current.GoToAsync("//AllCounterPage");
            }
        }
    }
}
