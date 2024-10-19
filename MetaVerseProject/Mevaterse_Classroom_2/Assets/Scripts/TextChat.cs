using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using System.Diagnostics;
using System.IO;

public class TextChat : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputField;
    public bool isSelected = false;
    private GameObject commandInfo;

    private void Start()
    {
        commandInfo = GameObject.Find("CommandInfo");
    }

    public void LateUpdate()
    {
        if(Input.GetKeyUp(KeyCode.Return) && !isSelected)
        {
            isSelected = true;
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);
            inputField.caretPosition = inputField.text.Length;
            commandInfo.SetActive(false);
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && isSelected)
        {
            isSelected = false;
            EventSystem.current.SetSelectedGameObject(null);
            commandInfo.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Return) && isSelected && inputField.text != "")
        {
            string userMessage = inputField.text;
            photonView.RPC("SendMessageRpc", RpcTarget.AllBuffered, PhotonNetwork.NickName, userMessage);
            inputField.text = "";
            isSelected = false;
            EventSystem.current.SetSelectedGameObject(null);
            commandInfo.SetActive(true);

            // Call the Python script to get AI response
            string aiResponse = GetAIResponse(userMessage);
            photonView.RPC("SendMessageRpc", RpcTarget.AllBuffered, "AI", aiResponse);
        }
    }

    [PunRPC]
    public void SendMessageRpc(string sender, string msg)
    {
        string message = $"<color=\"yellow\">{sender}</color>: {msg}";
        Logger.Instance.LogInfo(message);
        LogManager.Instance.LogInfo($"{sender} wrote in the chat: \"{msg}\"");
    }

    private string GetAIResponse(string userMessage)
    {
        string pythonScriptPath = "PythonLLM/ai_response.py";
        string pythonExePath = "python"; // Adjust if needed

        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = pythonExePath;
        start.Arguments = $"\"{pythonScriptPath}\" \"{userMessage}\"";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;

        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                var json = JsonUtility.FromJson<AIResponse>(result);
                return json.response;
            }
        }
    }

    private class AIResponse
    {
        public string response;
    }
}
