using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class SetDoorAction : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;

    public enum DoorOpenRestriction
    {
        Invalide = -1,
        IsGirlOnly,
        IsBoyOnly,
        IsGetKeyItem

    };
    public DoorOpenRestriction ThisDoorOpenRestriction = DoorOpenRestriction.Invalide;
    public string OnlyTag = string.Empty;

    private AICharacterControl notOnlyAICharacter;


    private void Start()
    {
        switch (ThisDoorOpenRestriction)
        {
            case DoorOpenRestriction.Invalide:
                break;
            case DoorOpenRestriction.IsBoyOnly:
                OnlyTag = "BoyCharacter";
                break;
            case DoorOpenRestriction.IsGirlOnly:
                OnlyTag = "GirlCharacter";
                break;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (ThisDoorOpenRestriction == DoorOpenRestriction.IsGetKeyItem &&
            GameFlagDefine.GameFlagDictionary[GameFlagDefine.GameFlag.KeyItemGet])
        {
            SceneManager.LoadScene("ResultScene");
            return;
        }
        if (ThisDoorOpenRestriction != DoorOpenRestriction.Invalide)
        {
            Debug.LogError(OnlyTag);
            if (other.tag != OnlyTag)
            {
                notOnlyAICharacter = other.GetComponent<AICharacterControl>();
                notOnlyAICharacter.Stop = true;
                return;
            }
        }
        if (!isOpen)
        {
            ///this.transform.GetChild(0).localEulerAngles = new Vector3(0, -90, 0);
            isOpen = true;
            animator.SetBool("IsOpen", isOpen);
            Debug.Log("IsOpen");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (ThisDoorOpenRestriction != DoorOpenRestriction.Invalide)
        {
            if (other.tag != OnlyTag)
            {
                return;
            }
        }
        if (isOpen)
        {
            if (notOnlyAICharacter != null)//AI�͔������ɂ͓���Ȃ�
            {
                notOnlyAICharacter.Stop = false;
            }
            /// this.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);

            isOpen = false;
            animator.SetBool("IsOpen", isOpen);
            Debug.Log("IsOpen�ӂ��邷");
        }
    }
}
