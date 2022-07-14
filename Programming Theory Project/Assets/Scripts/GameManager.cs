using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int MeatHunted
    {
        get { return meatHunted; }
        set
        {
            meatHunted = value;
            meatText.text = $"Meat Hunted: {meatHunted}";
        }
    }

    public int BonesCollected
    {
        get { return bonesCollected; }
        set
        {
            bonesCollected = value;
            bonesText.text = $"Bones Collected: {bonesCollected}";
        }
    }

    [SerializeField]
    private TextMeshProUGUI meatText;
    [SerializeField]
    private TextMeshProUGUI bonesText;

    private int bonesCollected;
    private int meatHunted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
