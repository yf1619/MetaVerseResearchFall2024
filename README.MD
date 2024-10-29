Below is the updated README file, with the newly provided content integrated seamlessly.

# Fall 24 University at Buffalo Metaverse Research

## Members

- **Yiwei Feng** (University at Buffalo CSE undergraduate student)
- **WanXian Chen** (University at Buffalo CSE undergraduate student)
- **Sreyasee Das Bhattacharjee** (Assistant Professor of Teaching)

## Repository Structure

- **MetaVerseProject**:  
  The project we edited to implement AI avatars interacting in a metaverse environment.

- **PaperResource**:  
  Contains the papers referenced for the research project.

- **PythonLLM**:  
  A large language model (LLM) created to serve as an AI agent for interactions in the metaverse.

- **SENEM_Metaverse**:  
  An open-source project referenced for developing and implementing functionalities in this research.

## Meeting Minutes

- **Oct 10, 2024**:
  - Explore **Generative Models**. Start with Coursera for additional resources.
  - Create a **demo video** where each member uses their own AI avatar to communicate.
  - Prepare a **three-person demo video**:
    - Two members (Yiwei and another) engage in a casual conversation using audio.
    - A third person plays the role of an observer.
  - Investigate the possibility of implementing different **virtual environments** beyond the classroom:
    - Living Room
    - Hotel Room
    - Hospital
  - Record a demo for each of these environments.

## Yiwei WorkProgress

### Identify the API Used for Interaction Between Avatars

#### Explanation of the API for Text Interaction Between Avatars Through Chat Box

##### English

The text interaction between avatars in the **SENEM_Metaverse** project is facilitated using the Photon Chat API and Unity's TextMeshPro. Below are the detailed steps and file locations involved in implementing this functionality:

1. **Photon Chat API Setup**:

   - **File**: [ChatClient.cs](https://github.com/vipenti/SENEM_Metaverse/blob/1d34727e705100fe7aae061fef9cc3188b350744/Mevaterse_Classroom_2/Assets/Photon/PhotonChat/Code/ChatClient.cs)
   - **Relevant Lines**: 345-426
   - **Description**: The `ChatClient` class in Photon Chat API handles connecting to the chat server, subscribing to channels, and sending/receiving messages. Key methods include `Connect`, `Subscribe`, `PublishMessage`, and `SendPrivateMessage`.

2. **Chat UI Management**:

   - **File**: [ChatController.cs](https://github.com/vipenti/SENEM_Metaverse/blob/1d34727e705100fe7aae061fef9cc3188b350744/Mevaterse_Classroom_2/Assets/TextMesh%20Pro/Examples%20%26%20Extras/Scripts/ChatController.cs)
   - **Relevant Lines**: 1-51
   - **Description**: This script manages the chat UI elements such as input fields and chat display. It handles input submission and updates the chat display with new messages.

3. **Photon Chat Integration**:
   - **File**: [TextChat.cs](https://github.com/vipenti/SENEM_Metaverse/blob/main/Mevaterse_Classroom_2/Assets/Scripts/TextChat.cs)
   - **Relevant Lines**: 1-53
   - **Description**: This script integrates Photon Chat with Unity. It listens for user input, sends messages through Photon Chat using RPC calls, and displays received messages in the chat UI.

---

## Integration Guide for AI-Iris-Avatar and SENEM Metaverse Projects

To integrate both the **AI-Iris-Avatar** and the **SENEM Metaverse** projects in Unity, follow this structured plan to ensure both projects are prepared and work together seamlessly.

### **Step 1: Prepare the AI-Iris-Avatar Unity Project**

1. **Open the AI-Iris-Avatar project** in Unity.
2. **Select Dependencies**:
   - In the **Assets** window, right-click the necessary files (such as models, scripts, and prefabs) and choose **Select Dependencies** to ensure all required components are selected for export.
3. **Export as Unity Package**:
   - Go to **File → Export Package** and ensure all necessary assets are checked.
   - Save the package as `AI_Iris_Avatar.unitypackage`.
4. **Test the Package**:
   - Open a new Unity project and import the package to ensure there are no missing dependencies.

---

### **Step 2: Prepare the SENEM Metaverse Unity Project**

1. **Open the SENEM Metaverse project** in Unity.
2. **Organize Project Hierarchy**:
   - Create a folder in the **Assets** window (e.g., `AI_Avatar`) where the AI avatar and related assets will reside.
3. **Set Up Unity Version Compatibility**:
   - Confirm that both projects use **the same Unity version** to avoid compatibility issues (e.g., 2022.3.21f1 as recommended in the AI-Iris-Avatar documentation).
4. **Install Required Plugins and Libraries**:
   - Import the **Oculus Lipsync** library from the Unity Asset Store or GitHub to support avatar lip-sync functionality.
   - Add the **NativeWebSocket package** if you plan to use WebSocket for communication between the avatar and backend servers.

---

### **Step 3: Import the AI-Iris-Avatar into the SENEM Metaverse Project**

1. **Import the Package**:
   - In the SENEM Metaverse project, go to **Assets → Import Package → Custom Package**.
   - Select the `AI_Iris_Avatar.unitypackage` you created earlier and import it.
2. **Verify Prefabs and Assets**:
   - Check that all models, scripts, and prefabs have been imported correctly without any missing files.

---

### **Step 4: Backend and Communication Setup**

1. **Launch the AI Server**:
   - Navigate to the **AI-Iris-Avatar** backend folder and run the Python server with:
     ```bash
     python server.py --port 8080
     ```
2. **WebSocket Configuration**:

   - In the Unity project, set up WebSocket connections to allow communication between the **SENEM Metaverse** and the **AI backend**. You can use the **NativeWebSocket** library to handle these connections:

     - Add a C# script to open and maintain a WebSocket connection.

     ```csharp
     using NativeWebSocket;

     public class WebSocketConnection : MonoBehaviour {
         WebSocket websocket;

         async void Start() {
             websocket = new WebSocket("ws://localhost:8080");
             websocket.OnMessage += (bytes) => {
                 Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(bytes));
             };
             await websocket.Connect();
         }
     }
     ```

3. **Sync Lip Sync with Audio**:
   - Configure the **Oculus Lipsync library** to synchronize avatar lip movements with audio generated by the text-to-speech (TTS) module of the AI server.

---

### **Step 5: Test and Debug**

1. **Test WebSocket Communication**:
   - Send a text prompt from the SENEM Metaverse project to the AI backend. Verify if the avatar responds with the correct lip-sync and audio.
2. **Debug Missing Components or Scripts**:
   - If errors occur (e.g., missing assets or components), revisit the **AI-Iris-Avatar project** and ensure all dependencies were included during the export.

---

### **Step 6: Optimize and Customize**

1. **Performance Optimizations**:
   - Adjust the graphics settings or switch to **URP** (Universal Render Pipeline) if targeting mobile platforms.
2. **Custom Animations**:
   - Use Unity's **Mecanim system** to create idle and speaking animations for the avatar, and sync with Mixamo animations if required.

This version merges the new content within the original README’s structure. Let me know if further modifications are needed! ￼
