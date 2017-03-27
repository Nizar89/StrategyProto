using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Datas/PlayerDatas", order = 1)]
public class PlayerDatas : ScriptableObject
{
    //order data
    public int _nbMaxOrder = 5;
    public float _speedOrder = 10f;
    public GameObject _prefabOrder;

}
