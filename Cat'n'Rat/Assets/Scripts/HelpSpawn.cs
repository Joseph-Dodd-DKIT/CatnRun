using UnityEngine;

public class HelpSpawn : MonoBehaviour
{
    public float helpqueTime=5f;
    private float time = 0;
    public GameObject Help;

    public int DieCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time>helpqueTime)
        {
            GameObject go = Instantiate(Help);

            time = 0;

            Destroy(go, 15);
        }

        if (DieCount == 10)
        {
            helpqueTime = helpqueTime+0.1f;
            DieCount = 0;
            //Debug.Log("Help got Harder. "+helpqueTime);
        }

        time += Time.deltaTime;
    }
}
