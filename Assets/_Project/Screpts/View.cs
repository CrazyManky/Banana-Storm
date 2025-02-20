using _Project.Screpts.Elements;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent;
using UnityEngine;

namespace _Project.Screpts
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] protected ScreenOpen _screenOpen;
        
        public abstract void Init();
        public abstract void Init(SettingsPresenter presenter);
        public abstract void Close();
    }
}