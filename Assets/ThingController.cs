using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThingController : MonoBehaviour
{
    public AudioSource speakSource; 
    public TMP_Text dialogueText;
    public ScreenShake screenShake; 

    public AudioClip clip;

    private void Start() {
        StartCoroutine(WaitAndDo());
    }

    private IEnumerator WaitAndDo()
    {        
        yield return new WaitForSeconds(6f);
        GameManager.Instance.ChangeSong(clip); 
        GameManager.Instance.StartConversation("So here we are", 888); 
        yield return new WaitForSeconds(6f);
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("Just you and me once again!", 878); 
        yield return new WaitForSeconds(6f);
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("You think congratulations are in order?", 885);
        yield return new WaitForSeconds(6f); 
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("No, I will not congratulate you", 8858567);
        yield return new WaitForSeconds(6f);
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("Look at yourself, you are a wretch", 884); 
        yield return new WaitForSeconds(6f); 
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("Pitiful excuse of a father", 28656564); 
        yield return new WaitForSeconds(6f); 
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("You have done NOTHING HERE", 838);
        yield return new WaitForSeconds(6f); 
        GameManager.Instance.ChangePitch();
        GameManager.Instance.StartConversation("NOTHING I TELL YEE", 8884563);  
        yield return new WaitForSeconds(6f); 
        GameManager.Instance.ChangePitch();
        SceneManager.LoadScene("EndingCutscene"); 
    }


     private IEnumerator Type(string message)
    {
        speakSource.Play();
        for (int i = 0; i < message.Length; i++)
        {
            dialogueText.text += message[i]; 
            screenShake.StartShake(0.08f); 
            yield return new WaitForSeconds(0.1f);
        }

        //Typing is over

        speakSource.Stop();
        yield return new WaitForSeconds(1.5f); 
        
    }
}
