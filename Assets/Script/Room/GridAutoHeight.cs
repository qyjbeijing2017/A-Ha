using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.GridLayoutGroup))]
public class GridAutoHeight : MonoBehaviour
{
    UnityEngine.UI.GridLayoutGroup gridLayoutGroup;
    private void Awake()
    {
        gridLayoutGroup = GetComponent<UnityEngine.UI.GridLayoutGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetGridHeight(gridLayoutGroup.constraintCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetGridHeight(int num)     //每行Cell的个数
    {
        float childCount = this.transform.childCount;  //获得Layout Group子物体个数
        float height = ((childCount + num - 1) / num) * gridLayoutGroup.cellSize.y + 3.0f;  //行数乘以Cell的高度，3.0f是微调
        height += (((childCount + num - 1) / num) - 1) * gridLayoutGroup.spacing.y;     //每行之间有间隔
        gridLayoutGroup.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }
}
