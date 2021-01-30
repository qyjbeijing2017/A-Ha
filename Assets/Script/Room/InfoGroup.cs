using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGroup : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEngine.UI.Text title;
    public UnityEngine.UI.Text content;

    public string text {
        get
        {
            return content.text;
        }
        set
        {
            content.text = value;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
