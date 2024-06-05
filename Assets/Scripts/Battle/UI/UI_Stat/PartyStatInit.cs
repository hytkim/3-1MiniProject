using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyStatInit : MonoBehaviour
{
    public GameObject party_Stat_Prefab;
    private List<GameObject> stats = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < BattleManager.Instance.party_List.Count; i++)
        {
            GameObject obj = Instantiate(party_Stat_Prefab, transform);
            StatManager stat_Obj = obj.GetComponent<StatManager>();
            stats.Add(obj);

            Ally player = BattleManager.Instance.party_List[i].GetComponent<Ally>();
            Sprite sprite = BattleManager.Instance.party_List[i].GetComponent<SpriteRenderer>().sprite;

            stat_Obj.InitStat(player, player.entity_index, sprite, player.level, player.player_Name);
        }
    }
}
