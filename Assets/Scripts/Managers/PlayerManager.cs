using UnityEngine;
using System.Collections;
 
public class PlayerManager : MonoBehaviour {
 
    public static PlayerManager instance { get; private set; }

    private GameObject player;
 
    // Use this for initialization
    void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy (gameObject);  
        }
        DontDestroyOnLoad (gameObject);
    }
   
    // Update is called once per frame
    void Update () {
   
    }

    public GameObject GetPlayer() {
        if (player == null) {
            player = GameObject.Find("Player");

            if (player == null) {
                throw new System.EntryPointNotFoundException("Player couldn't be found.");
            }
        }

        return player;
    }

    public Transform GetPlayerTransform() {
        return GetPlayer().transform;
    }

    public Vector2 GetPlayerPosition() {
        return GetPlayerTransform().position;
    }

    public float GetDistanceToPlayer(GameObject myGameObject) {
        return Vector2.Distance(PlayerManager.instance.GetPlayerPosition(), myGameObject.transform.position);
    }

    public Vector2 GetDirectionToPlayer(GameObject myGameObject) {
        return (GetPlayerPosition() - (Vector2)myGameObject.transform.position).normalized;
    }
}