using _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent;

namespace _Project.Screpts.LiderBoardScreen
{
    public class LidearScreen : View
    {
        public override void Init()
        {
            _screenOpen.Open();
        }

        public override void Init(SettingsPresenter presenter)
        {
            return;
        }

        public override void Close()
        {
            Destroy(gameObject);
        }
    }
}