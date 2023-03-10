using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class BG : MonoBehaviour
    {
        [SerializeField] private Image _self;

        private Color[] _colors = new Color[2] { new Color(1, 1, 1, 1), new Color(1, 1, 1, 0) };

        public void Show(Sprite source)
        {
            _self.sprite = source;
            _self.color = _colors[0];
        }

        public void Hide() => _self.color = _colors[1];
    }
}
