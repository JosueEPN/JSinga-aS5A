using JSingañaS5A.Utils;

namespace JSingañaS5A
{
    public partial class App : Application
    {
        public static PersonRepositroy PersonRepo { get; set; }
        public App(PersonRepositroy personRepositroy)
        {
            InitializeComponent();

            MainPage = new Views.Principal();
            PersonRepo = personRepositroy;
        }
    }
}
