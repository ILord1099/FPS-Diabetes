using Helper;
using UnityEngine;

namespace Quiz.Components
{
    public class ButtonsGroup : MonoBehaviour
    {
        [SerializeField] private CircularBuffer<AnswerButton> buffer;
        [field: SerializeField] public AnswerButton[] Buttons { get; set; }

        private int _bufferSize;

        private void OnEnable()
        {
            foreach (var button in Buttons)
            {
                button.OnSelected += AddButton;
            }
        }

        private void OnDisable()
        {
            foreach (var button in Buttons)
            {
                button.OnSelected -= AddButton;
            }
        }

        private void AddButton(AnswerButton button)
        {
            if (buffer.Contains(button)) return;

            if (buffer.Count == _bufferSize)
                buffer.Dequeue().Deselect();

            button.Select();
            buffer.Enqueue(button);
        }

        public void Reset()
        {
            for (var i = 0; i < buffer.Count; i++) buffer.Dequeue().Deselect();
            buffer.Clear();
        }

        public void CreateBuffer(int size = 1)
        {
            _bufferSize = size;
            buffer = new CircularBuffer<AnswerButton>(_bufferSize);
        }

        public AnswerButton[] GetSelectedButtons()
        {
            var selectedButtons = new AnswerButton[buffer.Count];
            for (var i = 0; i < buffer.Count; i++) selectedButtons[i] = buffer.Dequeue();

            return selectedButtons;
        }
    }
}