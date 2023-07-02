using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItemPos : MonoBehaviour
{
    [System.Serializable]
    public class ItemList
    {
        public List<Vector3> itemPos;
    }

    public List<ItemList> saveItemPos;

    [Header("Item")]
    public GameObject itemParent;
    public int saveNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePos()
    {
        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            if (saveItemPos[saveNumber].itemPos.Count < itemParent.transform.childCount)
            {
                saveItemPos[saveNumber].itemPos.Add(itemParent.transform.GetChild(i).
                    transform.localPosition);
            }
            else
            {
                saveItemPos[saveNumber].itemPos[i] = itemParent.transform.GetChild(i).
                    transform.localPosition;
            }
        }
    }
}
