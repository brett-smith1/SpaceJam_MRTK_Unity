using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;


namespace SpaceJam.Player.Stats
{
    public class Player : MonoBehaviour
    {

        public static Player ActivePlayer;

        public TextMeshPro PlayerName;
        public TextMeshPro CardName;
        public TextMeshPro PlayerPer;
        public SpriteRenderer PlayerImg;

        private SpriteRenderer myRenderer;

        [SerializeField]
        private SpriteAtlas atlas;

        [HideInInspector]
        public PlayerData data;


        public void SetFromPlayerData(PlayerData data)
        {
            this.data = data;

            PlayerName.text = data.name;
            CardName.text = data.name;
            PlayerPer.text = data.per.ToString();
            transform.parent.name = data.name;

            myRenderer = GetComponentInChildren<SpriteRenderer>();
            myRenderer.sprite = atlas.GetSprite(data.spriteName);

        }

    }
}
