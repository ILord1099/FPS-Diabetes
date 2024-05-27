using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
using DG.Tweening;
using Unity.VisualScripting;
using System.Text;
using JetBrains.Annotations;




namespace Quiz
{
    public class AnswerButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Color normalColor;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color correctColor;
        [SerializeField] private Color wrongColor;
        
        public bool IsCorrect { get; set; }

        public event Action<AnswerButton> OnAnswerSelected;
        
        private Image _image;
        
        private Text _text;

        private bool _isSelected;
        
        private bool _isInteractable;

        private Vector3 _scaleTo;
        private Vector3 _originalScale;
        



        void Start()
        {
            _originalScale = transform.localScale;
            _scaleTo = _originalScale * 1.3f;
        }

        private void Awake()
        {
            IsCorrect = false;
            _isSelected = false;
            _image = GetComponent<Image>();
            _text = GetComponentInChildren<Text>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!_isInteractable) return;
            if (_isSelected) return;
            Select();
            
            
        }

        public void Select()
        {
            _isSelected = true;
            _image.color = selectedColor;
            OnAnswerSelected?.Invoke(this);
        }

        public void Deselect()
        {
            _isSelected = false;
            _image.color = normalColor;
        }

        public void SetInteractable(bool value) => _isInteractable = value;

        public void UpdateAnswerColor() 
        {
            if (IsCorrect)
            {
                _image.color = correctColor;
                transform.DOScale(_scaleTo, 0.1f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                transform.DOScale(_originalScale, 0.3f)
                    .SetEase(Ease.OutBounce)
                    .SetDelay(0.1f);

                });
            }
            else
            {
                _image.color = wrongColor;
                transform.DOShakePosition(1f, 17f, 20, 100f);
            }
            
        }
        
        public void SetText(string text) => _text.text = text;

    }

}