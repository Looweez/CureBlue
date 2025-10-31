using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    public Image tutorialImageDisplay;
    public Button btnPrevious;         
    public Button btnNext;             
    public Button btnBackToMenu;        
    
    public Sprite[] tutorialSlides; 

    
    private int currentSlideIndex = 0;
    
    void Start()
    {
        DisplayCurrentSlide();
    }
    
    public void ShowNextSlide()
    {
        currentSlideIndex++;
        
        if (currentSlideIndex >= tutorialSlides.Length)
        {
            GoBackToMainMenu(); 
            return; 
        }
        DisplayCurrentSlide();
    }
    
    public void ShowPreviousSlide()
    {
        currentSlideIndex--;
       
        if (currentSlideIndex < 0)
        {
            currentSlideIndex = 0;  
        }
        DisplayCurrentSlide();
    }
    
    private void DisplayCurrentSlide()
    {
    
        if (tutorialSlides.Length > 0 && tutorialImageDisplay != null)
        {
            tutorialImageDisplay.sprite = tutorialSlides[currentSlideIndex];
        }

       
        btnPrevious.interactable = (currentSlideIndex > 0);
        btnNext.interactable = (currentSlideIndex < tutorialSlides.Length - 1);
    }
    
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
