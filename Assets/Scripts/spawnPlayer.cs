using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using UnityEngine.U2D;

namespace SpaceJam.Player.Stats
{
    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public string cardName;
        public float per;
        public string spriteName;
    }

    [System.Serializable]
    class PlayersData
    {
        public List<PlayerData> players;

        public static PlayersData FromJSON(string json)
        {
            return JsonUtility.FromJson<PlayersData>(json);
        }
    }

    public class spawnPlayer : MonoBehaviour
    {
        public Transform Parent;
        public GameObject PlayerPrefab;
        public GridObjectCollection Collection;

        private bool isFirstRun = true;

        // Start is called before the first frame update
        private void Start()
        {
            InitializeData();
        }

        public void InitializeData()
        {
            TextAsset asset = Resources.Load<TextAsset>("JSON/PlayerDataStats");
            List<PlayerData> players = PlayersData.FromJSON(asset.text).players;


            if (isFirstRun == true)
            {
                foreach (PlayerData player in players)
                {
                    GameObject newPlayer = Instantiate<GameObject>(PlayerPrefab, Parent);
                    newPlayer.GetComponentInChildren<Player>().SetFromPlayerData(player);
                    newPlayer.transform.localPosition = new Vector3(0, 0, 0);
                    newPlayer.transform.localRotation = Quaternion.identity;
                    Collection.UpdateCollection();
                }

                isFirstRun = false;
            }
            else
            {
                int i = 0;
                foreach (Transform existingPlayerObject in Parent)
                {
                    existingPlayerObject.parent.GetComponentInChildren<Player>().SetFromPlayerData(players[i]);
                    existingPlayerObject.localPosition = new Vector3(0, 0, 0);
                    existingPlayerObject.localRotation = Quaternion.identity;
                    i++;
                }
                Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
            }
        }
    }
}