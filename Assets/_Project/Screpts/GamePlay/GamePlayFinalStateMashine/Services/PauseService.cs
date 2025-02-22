using System.Collections.Generic;
using _Project.Screpts.Services;

namespace _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services
{
    public class PauseService : IService
    {
        private List<IPauseItem> _pauseItems = new();

        public void AddPauseItem(IPauseItem pauseItem) => _pauseItems.Add(pauseItem);

        public void PauseExecute() => _pauseItems.ForEach((item) => { item.PauseActive(); });

        public void DisablePause() => _pauseItems.ForEach((item) => { item.DisablePause(); });
    }

    public interface IPauseItem
    {
        public void PauseActive();
        public void DisablePause();
    }
}