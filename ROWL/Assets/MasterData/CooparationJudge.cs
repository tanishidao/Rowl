using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class CooparationJudge : MonoBehaviour
{
    private static CooparationJudge instance;
    public static CooparationJudge Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (CooparationJudge)FindObjectOfType(typeof(CooparationJudge));
            
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    instance = go.AddComponent<CooparationJudge>();
                    go.name = instance.GetType().ToString();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }


    }
    public CooperationParam CooperationParam;
    public int CooperationPoint = 0;

    private void Start()
    {

        Addressables.LoadAssetAsync<CooperationParam>("Assets/MasterData/CooperationParam.asset").Completed += op =>
        {
            CooperationParam = op.Result;
        };
    }

    public void CooperationInit()
    {
        CooperationPoint = 0;
    }
    
    public void SetCooperationPoint(CooperationParam.CooperationIndex cooperationIndex)
    {
        var cooperationParam = CooperationParam.cooperationParams.
            Where(d => d.CooperationName == cooperationIndex).FirstOrDefault();
        CooperationPoint += cooperationParam.CooperationPoint;
    }



}
