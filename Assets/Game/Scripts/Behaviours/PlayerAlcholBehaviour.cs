using System;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerAlcholBehaviour : MonoBehaviour
    {
        [SerializeField] private float _maxIntoxication = 1000f;

        [SerializeField] private float _maxAlchol = 1000f;
        
        [SerializeField] private float _intoxicationIncrease = -20f;
        
        [SerializeField] private PlayerUIElement _playerUIElement;
        
        
        private float _currentIntoxication;

        private float _currentAlcholInBottle;

        private void Awake()
        {
            _currentIntoxication = _maxIntoxication;
            _currentAlcholInBottle = _maxAlchol;
            _playerUIElement.UpdateAlchol(_currentAlcholInBottle);
            _playerUIElement.UpdateIntoxication(_currentIntoxication);
        }

        public void Drink()
        {
            _currentAlcholInBottle -= 75f;
            _currentIntoxication += 35f;
            
            _playerUIElement.UpdateAlchol(_currentAlcholInBottle);
        }

        private void Update()
        {
            _currentIntoxication += _intoxicationIncrease * Time.deltaTime;

            var intoxicationAmount = _currentIntoxication / _maxIntoxication;
            

            if (_currentIntoxication >= _maxIntoxication)
            {
                _currentIntoxication = _maxIntoxication;
            }
            
        }
    }
}