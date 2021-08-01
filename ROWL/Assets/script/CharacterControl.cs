using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class CharacterControl: MonoBehaviour
{
    public GameObject GirlCharacter;
    public GameObject BoyCharacter;
    public AutoCam autoCam;

    private ThirdPersonUserControl girlThirdPersonControl;
    private ThirdPersonUserControl boyThirdPersonControl;

    private AICharacterControl girlAICharacterControl;
    private AICharacterControl boyAICharacterControl;

    private NavMeshAgent girlNavMeshAgent;
    private NavMeshAgent boyNavMeshAgent;

    private void Awake()
    {
        girlThirdPersonControl = GirlCharacter.GetComponent<ThirdPersonUserControl>();
        girlAICharacterControl = GirlCharacter.GetComponent<AICharacterControl>();
        girlNavMeshAgent = GirlCharacter.GetComponent<NavMeshAgent>();
        
        boyThirdPersonControl = BoyCharacter.GetComponent<ThirdPersonUserControl>();
        boyAICharacterControl = BoyCharacter.GetComponent<AICharacterControl>();
        boyNavMeshAgent = BoyCharacter.GetComponent<NavMeshAgent>();
    }

    public void CharacterChange()
    {
        var playableCharacterIsGirl = GirlCharacter.GetComponent<ThirdPersonUserControl>().enabled;///���\�֐��uvar�v�̔������A����thirdpearsonusercontrol��enable������(bool�l�H)
        if(playableCharacterIsGirl == true)///true�Ƃ͂܂�A�X�N���v�g���ғ����Ă��邩�ǂ���(���Ă�A���Ă��Ȃ���bool)P�Benabled�͏����lfalse�Z��
        {
            autoCam.SetTarget(BoyCharacter.transform);///�K�[������ThirdPersonUserControl���ғ����āu�Ȃ��Ɓv�^�[�Q�b�g���{�[�C�ɂ���H�H�H�H
        }
        else
        {
            autoCam.SetTarget(GirlCharacter.transform);///�K�[������ThirdPersonUserControl���ғ����Ă�����^�[�Q�b�g���{�[�C�ɂ���H�H�H�H
        }

        girlThirdPersonControl.enabled = !playableCharacterIsGirl;///�e�X�N���v�g�̉ғ����Abool�l�������āAThirdPersonUserControl�ƘA��������B
        girlAICharacterControl.enabled = playableCharacterIsGirl;
        girlNavMeshAgent.enabled = playableCharacterIsGirl;
        boyThirdPersonControl.enabled = playableCharacterIsGirl;
        boyAICharacterControl.enabled = !playableCharacterIsGirl;
        boyNavMeshAgent.enabled = !playableCharacterIsGirl;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            CharacterChange();
        }

    }
}
