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
