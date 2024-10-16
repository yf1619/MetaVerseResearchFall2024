using Photon.Voice.Unity;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PlayerVoiceController : MonoBehaviourPunCallbacks
{
    readonly string muteMsg = "<sprite index=2> \n     You are muted";
    readonly string unmuteMsg = "<sprite index=1> \n     Your mic is on!";

    private Recorder recorder;
    private TMP_Text info;
    private TMP_Text microphoneIndicator;
    private TMP_Text microphoneInfo;
    private PhotonView view;
    private TextChat textChat;

    public Speaker speaker;
    public AudioSource audioSource;
    public bool isTalking;
    private bool isTyping;

    private void Start()
    {
        recorder = GameObject.Find("VoiceManager").GetComponent<Recorder>();
        info = GameObject.Find("SoundState").GetComponent<TMP_Text>();
        microphoneIndicator = GameObject.Find("MicState").GetComponent<TMP_Text>();
        microphoneInfo = GameObject.Find("MicInfo").GetComponent<TMP_Text>();

        view = this.GetComponent<PhotonView>();
        textChat = GameObject.Find("TextChat").GetComponent<TextChat>();

        info.text = "";
        isTalking = false;
        isTyping = false;
        speaker.enabled = false;

        if (photonView.IsMine)
        {
            microphoneIndicator.text = muteMsg;

            if (Microphone.devices.Length > 0)
                microphoneInfo.text = $"Using: {Microphone.devices[0]}";
        }
    }

    public void Update()
    {
        if (!view.IsMine) return;

        isTyping = gameObject.GetComponent<PlayerController>().isTyping;

        if (Input.GetKeyUp(KeyCode.Tab) && !speaker.enabled && !textChat.isSelected && !isTyping)
        {
            view.RPC("ToggleMicRpc", RpcTarget.All, true);
            microphoneIndicator.text = unmuteMsg;
        }

        else if (Input.GetKeyUp(KeyCode.Tab) && speaker.enabled && !textChat.isSelected && !isTyping)
        {
            view.RPC("ToggleMicRpc", RpcTarget.All, false);
            microphoneIndicator.text = muteMsg;
        }

        if (speaker.enabled && recorder.LevelMeter.CurrentAvgAmp > 0.01f)
        {
            isTalking = true;
            info.text = "<color=\"green\">Transmitting audio</color>";
        }
        else
        {
            isTalking = false;
            info.text = "";
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (!photonView.IsMine) return;
        view.RPC("ToggleMicRpc", RpcTarget.All, speaker.enabled);
    }

    [PunRPC]
    public void ToggleMicRpc(bool value)
    {
        speaker.enabled = value;
        audioSource.enabled = value;
    }

}

