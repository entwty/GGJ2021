using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views
{
    public class PlayerUIElement : MonoBehaviour
    {
        [SerializeField] private Image _intoxication;

        [SerializeField] private Image _alchol;


        public void UpdateIntoxication(float value)
        {
            _intoxication.fillAmount = value;
        }

        public void UpdateAlchol(float value)
        {
            _alchol.fillAmount = value;
        }
    }
}
