using System;
using Core.Animations;
using UnityEngine;

namespace Day.CardDrawButton
{
    public class CardDrawButtonInput : MonoBehaviour
    {
        [SerializeField] private CardDrawButtonController _controller;

        private void OnMouseDown()
        {
            _controller.RenderButton(ButtonEventType.Down);
        }

        private void OnMouseUp()
        {
            _controller.RenderButton(ButtonEventType.Up);
        }

        private void OnMouseEnter()
        {
            _controller.RenderButton(ButtonEventType.Enter);
        }

        private void OnMouseExit()
        {
            _controller.RenderButton(ButtonEventType.Exit);
        }
    }
}