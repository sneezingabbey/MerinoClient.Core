﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MerinoClient.Core.UI
{
    public class UiText : UiElement
    {
        private readonly Text _textComponent;

        public string Text
        {
            get => _textComponent.text;
            set => _textComponent.text = value;
        }

        public UiText(string text, Vector2 pos, Vector2 scale, Action onClick = null, Transform parent = null) : base(
            GameObject.Find("/UserInterface/MenuContent/Screens/Avatar/Favorite Button"), parent, pos,
            $"{text}UiButton")
        {
            var button = GameObject.GetComponentInChildren<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(new Action(() => onClick?.Invoke()));
            //Object.DestroyImmediate(GameObject.GetComponentInChildren<Button>());
            Object.DestroyImmediate(GameObject.GetComponentInChildren<Image>());

            _textComponent = GameObject.GetComponentInChildren<Text>();
            _textComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            Text = text;

            var allTextComponents = GameObject.GetComponentsInChildren<Text>(true);
            foreach (var t in allTextComponents)
            {
                if (t.transform == _textComponent.transform)
                    continue;

                Object.DestroyImmediate(t);
            }

            RectTransform.sizeDelta *= scale;
        }
    }
}
