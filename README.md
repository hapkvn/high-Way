# 🏎️ Highway Escape: 2D Endless Traffic Rider

Tựa game 2D Endless Runner tốc độ cao đưa người chơi luồn lách qua các luồng giao thông đông đúc trên cao tốc. Né tránh chướng ngại vật, sinh tồn giữa hỗn loạn và tận dụng các vật phẩm hỗ trợ chiến lược để đạt điểm số cao nhất.

## 🌟 Tính năng Nổi bật

*   **Cuộn 2D Vô tận (Endless 2D Scrolling):** Tạo vô tận các xe cộ và chướng ngại vật động trên đường cao tốc nhiều làn.
*   **Tăng độ khó theo tiến trình (Difficulty Scaling):** Trò chơi tự động tăng dần tốc độ và mật độ giao thông khi điểm số của người chơi càng cao.
*   **Cài đặt Toàn diện:** Giao diện người dùng đầy đủ chức năng để lựa chọn độ khó (Dễ, Bình thường, Khó), bật/tắt âm thanh hiệu ứng (SFX) và nhạc nền (BGM).
*   **Tích hợp AdMob:** Tích hợp quảng cáo biểu ngữ (Banner) và quảng cáo thưởng (Rewarded Ads) của Google AdMob để nhận thêm mạng hoặc vật phẩm hỗ trợ.

## 🚀 Vật phẩm Hỗ trợ Động (Power-Ups)

Để sinh tồn trong dòng xe cộ hỗn loạn, người chơi có thể kích hoạt các kỹ năng mạnh mẽ:

1.  🔥 **Tăng tốc (Speed Up / Nitro Boost):**
    *   Tạm thời tăng tốc độ khung hình và tốc độ cuộn của trò chơi.
    *   Cung cấp khả năng miễn nhiễm với các va chạm nhỏ hoặc hất văng xe cộ trên đường trong một khoảng thời gian ngắn.
2.  🛡️ **Xe tải bọc thép (Armored Truck / Shield):**
    *   Xe của người chơi biến đổi thành một chiếc xe tải hạng nặng.
    *   **Hệ thống độ bền (Durability System):** Xe tải hoạt động như một lớp khiên chịu được 3 lần va chạm. Nó có thể đâm vào 3 chướng ngại vật/xe cộ mà không làm kết thúc trò chơi. Sau lần va chạm thứ 3, khiên vỡ và xe trở lại dạng xe con bình thường.

## 🛠️ Triển khai Kỹ thuật

*   **Object Pooling (Tái sử dụng đối tượng):** Thay vì khởi tạo và hủy liên tục (gây rò rỉ bộ nhớ và giật lag), các xe địch và phân đoạn đường được gom nhóm và tái sử dụng nhằm tối ưu hóa hiệu năng tối đa trên thiết bị di động.
*   **Hệ thống Vật lý 2D:** Sử dụng `Rigidbody2D` và `BoxCollider2D` để phát hiện va chạm chính xác.
*   **Singleton Managers:** Kiến trúc cấu trúc sử dụng `GameManager`, `AudioManager` và `UIManager` để xử lý mượt mà các trạng thái trò chơi (Bắt đầu, Tạm dừng, Tiếp tục, Kết thúc trò chơi).
*   **Tính điểm theo Quãng đường:** Tính toán điểm số thời gian thực dựa trên khoảng cách trục Y thực tế mà nền di chuyển thay vì dùng bộ đếm thời gian đơn thuần.

## 🎮 Cách điều khiển

*   **Nút bấm Điều hướng UI:** Chạm và giữ các nút điều hướng trên màn hình (Lên, Xuống, Trái, Phải) được quản lý thông qua các giao diện `IPointerDownHandler` và `IPointerUpHandler` để điều khiển di động chuẩn xác.
*   **Nút Kỹ năng:** Chạm vào các nút UI trên màn hình để kích hoạt tức thì *Khiên* hoặc *Tăng tốc*.

## 👨‍💻 Nhà phát triển

**[HUY HOANG]** 
*   **Vai trò:** Game Developer (Unity / C#)
*   **GitHub:** [@hapkvn](https://github.com/hapkvn)
*   **Liên hệ:** [huyhoangpkvnn75@gmail.com]
