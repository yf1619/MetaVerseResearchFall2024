# Fall 24 University at Buffalo Metaverse Research

## Members

- **Yiwei Feng** (University at Buffalo CSE undergraduate student)
- **Adi Dwibedi** (University at Buffalo CSE postgraduate student)
- **Sreyasee Das Bhattacharjee** (Assistant Professor of Teaching)

## Related Repositories

- **AI-Avatar Repository Referenced**: [https://github.com/Scthe/ai-iris-avatar.git](https://github.com/Scthe/ai-iris-avatar.git)  
  Unity3d version:2022.3.21f1

# Main Project

- **MetaVerse Classroom Repository Referenced**: [https://github.com/vipenti/SENEM_Metaverse.git](https://github.com/vipenti/SENEM_Metaverse.git)  
  Unity3D version: 2021.3.22f1

## Repository Structure

- **MetaVerseProject**:  
  The project aiming to implement AI avatars(AI-iris-Avatr) interacting in a metaverse(SENEM_Metaverse) environment.

- **PaperResource**:  
  Contains the papers and medium article referenced for the research project.

- **PresentationFiles**:  
  Slides and visuals for the final presentation.

- **AIIrisAvatorExportPackage**:  
  The package file exported from AllrisAvatorExportPackage which is the imported package of integration plan step 1.

- **server**:  
  The AI-backend server required to run locally to set
  AI avatar from the AI-Iris-aviator project connecting to the
  local backend server .

---

## Integration Plan: AI-Iris-Avatar and SENEM Metaverse Projects

To integrate the **AI-Iris-Avatar** to the **SENEM Metaverse** projects in Unity, follow this structured plan to ensure both projects are prepared and work together seamlessly.

### **Step 1: Prepare the AI-Iris-Avatar Unity Project(Issues exist)**

1. **Open the AI-Iris-Avatar project** in Unity.
2. **Select Dependencies:**
   - In the **Assets** window, right-click the necessary files (such as models, scripts, and prefabs) and choose **Select Dependencies** to ensure all required components are selected for export.
3. **Export as Unity Package(**Accomplished**):**

   - Go to **File → Export Package** and ensure all necessary assets are checked.
   - Save the package as `AI_Iris_Avatar.unitypackage`.

4. **Test the Package:( **issues** from concole due to the compatibility issue)**
   - Open a new Unity project and import the package to ensure there are no missing dependencies.

---

### **Step 2: Prepare the SENEM Metaverse Unity Project(Issue exist)**

1. **Open the SENEM Metaverse project** in Unity.
2. **Organize Project Hierarchy(Foler created):**
   - Create a folder in the **Assets** window (e.g., `AI_Avatar`) where the AI avatar and related assets will reside.
3. **Set Up Unity Version Compatibility(Issues exist in the console of Unity):**
   - Confirm that both projects use **the same Unity version** to avoid compatibility issues (e.g., 2022.3.21f1 as recommended in the AI-Iris-Avatar documentation).
4. **Install Required Plugins and Libraries(Accomplished : two libararies are installed):**
   - Import the **Oculus Lipsync** library from the Unity Asset Store or GitHub to support avatar lip-sync functionality.
   - Add the **NativeWebSocket package** if you plan to use WebSocket for communication between the avatar and backend servers.

---

### **Step 3: Import the AI-Iris-Avatar into the SENEM Metaverse Project**

1. **Import the Package(Accomplished):**
   - In the SENEM Metaverse project, go to **Assets → Import Package → Custom Package**.
   - Select the `AI_Iris_Avatar.unitypackage` you created earlier and import it.
2. **Verify Prefabs and Assets(No asset appears):**
   - Check that all models, scripts, and prefabs have been imported correctly without any missing files.

---

### **Step 4: Backend and Communication Setup**

1. **Launch the AI Server:**

   - Navigate to the **AI-Iris-Avatar** backend folder and run the Python server with:
     ```bash
     python server.py --port 8080
     ```

2. **WebSocket Configuration(Accomplished: File has been added ):**

   To add this code to `WebSocket.cs`, ensure that the file supports Unity components and the NativeWebSocket library. The provided code is designed for Unity's MonoBehaviour, which might not align with the existing structure in `WebSocket.cs`.

   Instead, you can create a new script file specifically for handling WebSocket connections within Unity. Here is how you can proceed:

   - **Create a New Script:**

     - Create a new C# script in your Unity project, for example, `WebSocketConnection.cs`.

   - **Implement the WebSocket Connection:**

     - Add the provided code to this new script. Here is the complete script for `WebSocketConnection.cs`:

     ```csharp
     using UnityEngine;
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

         void Update() {
             #if !UNITY_WEBGL || UNITY_EDITOR
             websocket?.DispatchMessageQueue();
             #endif
         }

         private async void OnApplicationQuit() {
             await websocket.Close();
         }
     }
     ```

   - **Attach the Script to a GameObject(Not sure how to attach the script to the GameObject):**
     - Attach this script to a GameObject in your Unity scene to initialize the WebSocket connection when the scene starts.

   By following these steps, you can maintain a connection to the AI backend without directly modifying `WebSocket.cs` in a way that might conflict with its existing functionality.

3. **Sync Lip Sync with Audio(Not yet implemented):**
   - Configure the **Oculus Lipsync library** to synchronize avatar lip movements with audio generated by the text-to-speech (TTS) module of the AI server.

### **Step 5: Test and Debug**

1. **Test WebSocket Communication:**
   - Send a text prompt from the SENEM Metaverse project to the AI backend. Verify if the avatar responds with the correct lip-sync and audio.
2. **Debug Missing Components or Scripts:**
   - If errors occur (e.g., missing assets or components), revisit the **AI-Iris-Avatar project** and ensure all dependencies were included during the export.

---

### **Step 6: Optimize and Customize**

1. **Performance Optimizations:**
   - Adjust the graphics settings or switch to **URP** (Universal Render Pipeline) if targeting mobile platforms.
2. **Custom Animations:**
   - Use Unity's **Mecanim system** to create idle and speaking animations for the avatar, and sync with Mixamo animations if required.

---

### **问题描述与解决方案**

现阶段目标实现 MetaVerseProject 中加入一个 NPC avatar，能够 AI 语音或文字回复用户的 text 输入。ai-avatar 仓库中已经完全实现了 avatar 回复用户，并且嘴唇同步动作。本地 server 将用户输入传入 server，内置了大语言模型。

进度：yiweifeng 已经 根据 Integration Plan，进行操作 ，MetaVerseProject 已经 import 了 整个 ai-avatar project package 了，并添加了 NativeWebsocket.cs 连接 local python server 的文件。
但是 MetaVerseProject asset 里面 找不到引入的任何素材。

- **问题 1**：如何解决 MetaVerseProject 的 Unity 版本兼容问题？当前尝试使用 Unity 2022.3.21f1 直接打开项目但出现 console 报错。是否可以通过版本更改解决？如果不可行，具体应更改哪个文件？
  如果需要重新整合，可以从最初的 MetaVersProject，因为更改的文件并不多。
- **问题 2**：ai-avatar 仓库内容是否包含了整个 avatar 直接可设置到场景中？还是仅包含素材需要在 MetaVerseProject 中自行创建 NPC？

---

## Conclusion

This plan ensures a smooth integration of the AI-Iris-Avatar and SENEM Metaverse projects, allowing for robust interaction between the avatar and the metaverse environment. Thorough testing and optimization will enhance the performance and interactivity of the final application.
