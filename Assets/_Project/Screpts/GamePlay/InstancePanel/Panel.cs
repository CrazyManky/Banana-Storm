using UnityEngine;

namespace _Project.Screpts.GamePlay.InstancePanel
{
    public class Panel : MonoBehaviour,IPullObject
    {
        private float _speed;
        public bool IActive { get; private set; }

        public void Active(bool active)
        {
            IActive = active;
            gameObject.SetActive(IActive);
        }

        public void SetSpeed(float speed)
        {
            if (speed == 0)
                return;
            _speed = speed;
        }

        public void Update() => transform.Translate(Vector3.down * (_speed * Time.deltaTime));
    }

    public interface IPullObject
    {
        public bool IActive {get;}
        public void Active(bool active);
    }
}