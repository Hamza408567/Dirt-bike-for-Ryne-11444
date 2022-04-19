using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_character : MonoBehaviour
{
    [Header("Player Cutomization")]
    public GameObject[] character;
    public Avatar[] avatr;
    public Animator animator;

    private void OnEnable()
    {
        animator.avatar = avatr[PlayerPrefs.GetInt(Constants.SelectedCharacter)];
        character[PlayerPrefs.GetInt(Constants.SelectedCharacter)].SetActive(true);
    }

}
