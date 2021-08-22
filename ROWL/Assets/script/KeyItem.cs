using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public Dialogue Dialogue;
    public ParticleSystem itemParticleSystem;

    public GameFlagDefine.GameFlag GameFlag;

    private void Start()
    {
        itemParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        itemParticleSystem.Stop();
        if (GameFlag == GameFlagDefine.GameFlag.ManKeyItemGet)
        {
            if (other.gameObject.tag != "BoyCharacter")
            {
                return;
            }
            CooparationJudge.Instance.SetCooperationPoint(CooperationParam.CooperationIndex.ManKeyItemGet);
            Debug.Log("10pt�Q�b�g");
            Dialogue.DisplayDialogue("Im Man in Man");
        }


        if (!GameFlagDefine.GetGameFlag(GameFlag))
        {

            GameFlagDefine.SetGameFlag(GameFlag);
            Debug.Log("�J�M�Q�b�g");
        }
        else
        {
            return;

        }
        Dialogue.DisplayDialogue("got an EntranceKey!");

    }

}
