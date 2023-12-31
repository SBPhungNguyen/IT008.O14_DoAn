# Nhap

**Project’s Title: MyCrotchet**


**Logo:** 

![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/679bad33-95ba-4ecf-967e-3a25b30fe611)


**Contributors:**
-	Leader: Nguyễn Đặng Kim Phụng – 22521148 - [GitHub](https://github.com/SBPhungNguyen)
-	Member: Phan Huỳnh Thiên Phúc – 22521139 - [GitHub](https://github.com/thienphuc1606)
-	Member: Nguyễn Thị Thanh Sương – 22521268 - [GitHub](https://github.com/nguyenthithanhsuong)

**Supervisors:**
- Nguyễn Tấn Toàn - toannt@uit.edu.vn

**Video Demo:**
- https://www.youtube.com/watch?v=9vwIHLUsQXk

**Description:**
- Bắt đầu cuộc hành trình âm nhạc đầy thú vị của bạn cùng phần mềm MyCrotchet- một trò chơi hấp dẫn giúp biến thiết bị của bạn thành một cây piano ảo. Trò chơi này được thiết kế dành cho những người đam mê âm nhạc ở mọi lứa tuổi, mang đến sự kết hợp độc đáo giữa giải trí và giáo dục.

**Key Features:**
-	**Chơi mà học:** <br>
Người dùng được tiếp xúc với âm nhạc theo cách trực quan sinh động đối nghịch với sự trừu tương và khó tiếp cận mà âm nhạc thường đem lại. Tuy là một trò chơi giải trí, MyCrotchet được thiết kế với sự hoạt động gần như tương tự một cây piano thực sự. <br>
-	**Thiết kế nhỏ gọn:** <br>
MyCrotchet là một ứng dụng được thiết kế tối giản song không đem lại sự nhàm chán; giúp tập trung người sử dụng vào những tiện ích hữu hiệu nhất mà nó đem lại. <br>
-	**Hướng dẫn và mẹo vặt:** <br>
Người chơi mới có thể dễ dàng tiếp cận các chỉ dẫn cô đọng súc tích và những mẹo vặt hữu ích của trò chơi cũng góp phần cải thiện kĩ năng của người chơi một cách nhanh chóng. <br>
-	**Soạn nhạc:** <br>
Người dùng có thể tự do sáng tác cũng như trình bày những bản nhạc theo sự sáng tạo của riêng mình. <br>
-	**Lưu trữ hệ thống:** <br>
Những bản nhạc quý báu mà người dùng đã tận tâm biên soạn sẽ được lưu giữ một cách cẩn trọng trên cơ sở dữ liệu của mình hoặc lưu trên thiết bị của người dùng nếu họ muốn. <br>
-	**Đăng bản nhạc công khai:** <br>
Trong bối cảnh ngày càng gia tăng sự đa dạng và sáng tạo trong lĩnh vực nghệ thuật âm nhạc, chúng tôi hân hạnh giới thiệu tính năng Đăng bản nhạc Công khai nhằm tạo ra một môi trường nghệ thuật độc đáo, nơi mà cộng đồng người dùng có thể tương tác và chia sẻ niềm đam mê âm nhạc chung. <br>

**How to use:** <br>
*Phần mềm này yêu cầu máy tính của bạn có hỗ trợ sqlServer, nếu bạn chưa có ứng dụng  này, bạn có thể download tại https://www.microsoft.com/en-us/sql-server/sql-server-downloads* <br>
-	**Bước 1:** Hãy đảm bảo rằng repository bạn đang truy cập là public (công cộng), vì ứng dụng này được phát triển bởi chúng tôi như một dự án mã nguồn mở, nên chủ yếu về mặt cơ bản sẽ được chúng tôi thiết lập ở trạng thái public.

-	**Bước 2:** Tiếp tục bằng cách chọn nút “Code” màu xanh trên trang chính repository

-	**Bước 3:** Tại menu ở đây, điều hướng tới mục HTTPS và chọn “Download ZIP”
![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145269191/0edbaa40-345b-4a28-9224-9b33fab3f50c)

-	**Bước 4:** Sau khi ứng dụng hoàn thành tải xuống, hãy giải nén ứng dụng tại vị trí bạn mong muốn và chọn “Nhap.sln” để khởi chạy source code của chương trình

**Trước khi chạy Source Code của ứng dụng**, ta cần cài đặt Database vì ứng dụng này cần thiết sử dụng Database. Ứng dụng đã cung cấp Database xài sẵn trong thư mục Database -> MusicLogin.bacpac
Để sử dụng Database, người dùng cần có sẵn và chuẩn bị kết nối SQL Server Management Studio (SSMS) kết hợp với bất kỳ cơ sở hạ tầng SQL nào (Nên là SQL Server).
Sau khi cài đặt hoàn tất, đầu tiên, mở SSMS và thực hiện các bước sau:

-	**Bước 5:** Click chuột phải vào thư mục Database và bấm ‘Import Data-tier Application’.
![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/3a7de3f1-43ff-40c6-8cff-f5b9fb2a20bc)

-	**Bước 6:** Bấm Next ở mục Introduction. Ở mục Import Setting, chọn Import from Local Disk. Bấm Browse và chọn ‘MusicLogin.bacpac’ ở trong thư mục Database đã đề cập trên. Bấm Next khi hoàn thành chọn.
![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/498944dd-b6cb-4416-a21e-6dad157e0491)

-	**Bước 7:** Giữ nguyên mọi cài đặt trong Database Settings (Tên Database đã được đặt để đồng bộ với Source Code, nếu thay đổi sẽ khiến Source Code không chạy được). Bấm Next. Ở mục Summary, kiểm tra lại (Target->Name là tên Server trong SQL mà người dùng đã đặt.) Tiếp tục Bấm Next
![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/14b449c0-bd14-47e0-8adc-c2363d66310e)

-	**Bước 8:** Đợi một lúc để quá trình Import Database hoàn tất. Khi Import xong, đã có Database phù hợp với Code có thể sử dụng. Bấm Close.
![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/3542dddf-dc76-455c-ac91-0522c6434afb)

-	**Bước 9:** Ghi nhớ tên Server đã đặt trong SSMS
  
  ![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/41e872ae-c3d9-4158-bf3a-b7568b58a682)

(Trong trường hợp này, tên server là F)
Quay lại Source Code trong Microsoft Visual Studio đã mở: Mở ConnectionInfo.cs. Ở phần gạch chân, thay đổi F trong ‘Data Source = F’ thành tên Server đã đặt trong SSMS. Code có thể bắt đầu được sử dụng với Database
![image](https://github.com/SBPhungNguyen/IT008.O14_DoAn/assets/145027338/bd766a75-fe24-410b-b4af-fba7de7be947)

**Code of Conducting**
Vì mục đích tạo ra một môi trường thân thiện chúng tôi mong đợi tất cả các người đóng góp và cộng đồng:
1.	Tôn trọng và quan tâm đến người khác, hạn chế mọi hành vi quấy rối, phân biệt đối xử hoặc sử dụng ngôn ngữ xúc phạm.
2.	Lắng nghe tích cực và mở lòng đối với sự phê bình xây dựng, thể hiện sự thông cảm đối với người khác và giữ lòng tin tích cực
3.	KHÔNG được quấy rối, đe dọa công khai hoặc riêng tư; KHÔNG phân biệt đối xử hay thực hiện bất kỳ hành vi nào có mục đích xâm phạm. Đặc biệt, KHÔNG đăng thông tin cá nhân của người khác mà không có sự cho phép.
4.	Những hành động vi phạm vào quy tắc ứng xử có thể bị yêu cầu dừng. Tùy thuộc vào mức độ nghiêm trọng hoặc số lần tái phạm, người vi phạm có thể bị loại bỏ khỏi dự án và không được cho phép tham gia các dự án khác của nhóm.
5.	Nếu bạn phải chịu đựng hoặc phát hiện bất kỳ hành vi nào không được quy tắc ứng xử chấp nhận, xin liên hệ với Trưởng Nhóm để kịp thời có những biện pháp xử lý phù hợp.

**License: Tổ chức theo MIT License:**
Copyright 2023, Group_IT008.O14 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

