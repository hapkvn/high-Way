# 🏎️ Highway Escape: 2D Endless Traffic Rider

An addictive, fast-paced 2D Endless Runner where players navigate through heavy highway traffic. Dodge obstacles, survive the chaos, and utilize strategic power-ups to achieve the highest score possible. 

https://github.com/user-attachments/assets/8a82db14-294b-4edb-b7a3-349148012a83

## 📸 Gameplay Showcase

<table>
  <tr>
    <td><img width="255" height="468" alt="Screenshot 2026-10-03 235352" src="https://github.com/user-attachments/assets/ec04984e-6214-4143-8415-a8951a86a95f" /></td>
    <td><img width="257" height="468" alt="Screenshot 2026-10-03 235402" src="https://github.com/user-attachments/assets/0b4c95bd-2640-4e42-a037-34b9f41df6e4" /></td>
    <td><img width="253" height="464" alt="Screenshot 2026-10-03 235408" src="https://github.com/user-attachments/assets/bf0f076d-05e3-40d1-a73c-b0ef99e49d80" /></td>
  </tr>
  <tr>
    <td><img width="252" height="465" alt="Screenshot 2026-10-03 235419" src="https://github.com/user-attachments/assets/764ce1aa-4b84-4bf0-9d06-a8e4d273168a" /></td>
    <td><img width="258" height="466" alt="Screenshot 2026-10-03 235429" src="https://github.com/user-attachments/assets/2ea80e8a-79cd-431c-9854-0f24d737dee4" /></td>
    <td><img width="257" height="465" alt="Screenshot 2026-10-03 235449" src="https://github.com/user-attachments/assets/4e98a537-ac3a-4d73-bcb6-b17e7d381e76" /></td>
  </tr>
  <tr>
    <td><img width="266" height="462" alt="Screenshot 2026-10-03 235456" src="https://github.com/user-attachments/assets/3ee096c1-cc96-4bc6-a0f2-86db9e98277a" /></td>
    <td><img width="257" height="466" alt="Screenshot 2026-10-03 235518" src="https://github.com/user-attachments/assets/acae0644-7b7d-4693-a050-2d90cd33f131" /></td>
    <td><img width="259" height="466" alt="Screenshot 2026-10-03 235533" src="https://github.com/user-attachments/assets/56ab7be0-e266-4184-bc41-a162bf32ccb5" /></td>
  </tr>
</table>

## 🌟 Core Features

*   **Endless 2D Scrolling:** Infinite procedural generation of traffic cars and dynamic obstacles on a multi-lane highway.
*   **Difficulty Scaling:** The game progressively speeds up and increases traffic density as the score gets higher.
*   **Comprehensive Settings:** Fully functional UI for Difficulty selection (Easy, Normal, Hard), SFX, and Background Music toggles.
*   **AdMob Integration:** Integrated Google AdMob banner ads and Rewarded Ads for extra lives or power-ups.

## 🚀 Dynamic Power-Ups

To survive the chaos, players can trigger powerful abilities:

1.  🔥 **Speed Up (Nitro Boost):** 
    *   Temporarily increases the game's timescale and scrolling speed.
    *   Grants invulnerability to minor collisions or pushes traffic out of the way for a short duration.
2.  🛡️ **Armored Truck (Shield):** 
    *   The player's car physically transforms into a heavy-duty truck.
    *   **Durability System:** The truck acts as a 3-hit shield. It can crash into 3 obstacles/cars without ending the game. Upon the 3rd collision, the shield breaks, and the vehicle reverts back to the standard fragile car.

## 🛠️ Technical Implementation

*   **Object Pooling:** Instead of instantiating and destroying objects (which causes memory leaks and lag), enemy cars and road segments are pooled and recycled for maximum mobile performance.
*   **2D Physics Engine:** Utilizes `Rigidbody2D` and `BoxCollider2D` for precise collision detection.
*   **Singleton Managers:** Structured architecture using `GameManager`, `AudioManager`, and `UIManager` to flawlessly handle game states (Start, Pause, Resume, Game Over).
*   **Distance-Based Scoring:** Real-time score calculation based on the actual Y-axis distance traveled by the background rather than simple timers.

## 🎮 Controls

*   **Touch/Drag:** Drag left or right on the screen to steer the vehicle across lanes.
*   **UI Buttons:** Tap on-screen buttons to activate the *Shield* or *Speed Up* power-ups.



## 👨‍💻 Developer

**[HUY HOANG]** 
*   **Role:** Game Developer (Unity / C#)
*   **GitHub:** [@hapkvn](https://github.com/hapkvn)
*   **Contact:** [huyhoangpkvnn75@gmail.com]
