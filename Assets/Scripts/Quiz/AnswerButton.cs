using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    [RequireComponent(typeof(Button))]
    
    public class AnswerButton : MonoBehaviour
    {
        private Button _button;

        private Color _defaultColor;

        private TMP_Text _text;

        public string Text
        {
            get => _text.text;
            set => _text.SetText(value);
        }

        public event Action<AnswerButton> OnSelected;

        public bool Interactable
        {
            get => _button.interactable;
            set => _button.interactable = value;
        }

        private void OnEnable()
        {
            if (_button == null)
                _button = GetComponent<Button>();

            if (_text == null)
                _text = GetComponentInChildren<TMP_Text>();

            _defaultColor = _button.colors.normalColor;
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked() => OnSelected?.Invoke(this);

        public void Select()
        {
            var buttonColors = _button.colors;
            buttonColors.normalColor = buttonColors.selectedColor;
            _button.targetGraphic.color = buttonColors.selectedColor;
        }

        public void Deselect()
        {
            var buttonColors = _button.colors;
            buttonColors.normalColor = _defaultColor;
            _button.targetGraphic.color = _button.colors.normalColor;
        }

        public void UpdateColor(Color color) => _button.targetGraphic.color = color;
    }
}