 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private Button newGameButton;
    public string newGameSceneName;

    private void OnEnable()
    {
        // var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        // newGameButton = rootVisualElement.Q<Button>("newButton");
  
        // newGameButton.RegisterCallback<ClickEvent>(ev => {
        //     SceneManager.LoadScene(newGameSceneName);
        // )};
    }
}
