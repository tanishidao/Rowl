using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameResultMessage : MonoBehaviour
{
    public TextMeshProUGUI ClearText;
    private void Start()
    {
        if(CooparationJudge.Instance.CooperationPoint > 0)
        {
            ClearText.text = "��l�͈ꏏ�ɉƘH�ɂ���";
        }
        else
        {
            ClearText.text = "��l�͕ʁX�̓��ŋA���Ă�����";
        }
    }
}
