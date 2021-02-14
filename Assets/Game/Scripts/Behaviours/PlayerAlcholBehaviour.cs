using System;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerAlcholBehaviour : MonoBehaviour
    {
        [SerializeField] private float _maxIntoxication = 1000f;

        [SerializeField] private float _maxAlchol = 1000f;
        
        [SerializeField] private float _intoxicationDecreaseAmount = -20f;


        [SerializeField] private float _drinkingIntoxicationAmount = 35f;

        [SerializeField] private float _drinkingAlcholCost = 75f;
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
            _currentAlcholInBottle -= _drinkingAlcholCost;
            _currentIntoxication += _drinkingIntoxicationAmount;
            
            _playerUIElement.UpdateAlchol(_currentAlcholInBottle);
        }

        private void Update()
        {
            _currentIntoxication += _intoxicationDecreaseAmount * Time.deltaTime;

            var intoxicationAmount = _currentIntoxication / _maxIntoxication;
            

            if (_currentIntoxication >= _maxIntoxication)
            {
                _currentIntoxication = _maxIntoxication;
            }
            
        }
    }
}