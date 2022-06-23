using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitchCollider : MonoBehaviour
{
    [SerializeField] private GameObject levelChanger;

    private void OnTriggerEnter2D(Collider2D other) {
        levelChanger.GetComponent<LevelChanger>().FadeToLevel("LevelTestScene");
    }
}
