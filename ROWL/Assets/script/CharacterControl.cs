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
        var playableCharacterIsGirl = GirlCharacter.GetComponent<ThirdPersonUserControl>().enabled;///万能関数「var」の箱を作り、そこthirdpearsonusercontrolのenableを入れる(bool値？)
        if(playableCharacterIsGirl == true)///trueとはつまり、スクリプトが稼働しているかどうか(してる、していないでbool)P。enabledは初期値false濃厚
        {
            autoCam.SetTarget(BoyCharacter.transform);///ガール内のThirdPersonUserControlが稼働して「ないと」ターゲットをボーイにする？？？？
        }
        else
        {
            autoCam.SetTarget(GirlCharacter.transform);///ガール内のThirdPersonUserControlが稼働していたらターゲットをボーイにする？？？？
        }

        girlThirdPersonControl.enabled = !playableCharacterIsGirl;///各スクリプトの稼働時、bool値を代入して、ThirdPersonUserControlと連動させる。
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
