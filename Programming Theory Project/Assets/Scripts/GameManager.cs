using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public bool isGameOver = false;

    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private TextMeshProUGUI meatText;
    [SerializeField]
    private TextMeshProUGUI bonesText;
    [SerializeField]
    private TextMeshProUGUI victoryText;
    [SerializeField]
    private TextMeshProUGUI loseText;
    [SerializeField]
    private TextMeshProUGUI victorySubtext;
    [SerializeField]
    private Button returnButton;
    [SerializeField]
    private GameObject backgroundUI;

    private int bonesCollected;
    private int meatHunted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (meatHunted == 3)
        {
            isGameOver = true;
            StartCoroutine(WinGame());
        }
        else if (isGameOver)
        {
            StartCoroutine(LoseGame());
        }
    }

    IEnumerator WinGame()
    {
        playerAnimator.SetInteger("Animation_int", 4);

        yield return new WaitForSeconds(2.5f);

        backgroundUI.SetActive(true);
        victoryText.gameObject.SetActive(true);
        victorySubtext.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    IEnumerator LoseGame()
    {
        playerAnimator.SetInteger("Animation_int", 9);

        yield return new WaitForSeconds(2.5f);

        backgroundUI.SetActive(true);
        loseText.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
