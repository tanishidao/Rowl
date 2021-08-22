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
            ClearText.text = "二人は一緒に家路についた";
        }
        else
        {
            ClearText.text = "二人は別々の道で帰っていった";
        }
    }
}
