create database AnimeDatabase

use AnimeDatabase

create table Anime (
	Id int,
	Title nvarchar(255) not null,
	AlternateTitle nvarchar(255),
	CoverImage nvarchar(255),
	Author nvarchar(255),
	Synopsis nvarchar(MAX),
	constraint PK_Anime primary key (Id)
);

insert into Anime (Id, Title, AlternateTitle, CoverImage, Author, Synopsis)
values 
(103, N'One Piece - Đảo Hải Tặc', N'Vua Hải Tặc', N'one-piece.jpg', N'Eiichiro Oda', N'Anime được phát sóng lần đầu tiên vào năm 1999 và nhanh chóng trở thành một trong những series anime phổ biến nhất trên thế giới. Câu chuyện xoay quanh Monkey D. Luffy, một chàng trai trẻ với giấc mơ trở thành Vua Hải Tặc. Luffy, người có khả năng co giãn như cao su sau khi ăn nhầm Trái Ác Quỷ, lãnh đạo nhóm Hải Tặc Mũ Rơm đi khắp Grand Line để tìm kiếm kho báu huyền thoại One Piece và theo đuổi giấc mơ của mình. Series nổi tiếng với cốt truyện phong phú, nhân vật đa dạng, và những pha hành động hấp dẫn'),
(104, N'One Punch Man 3', N'One Punch Man Season 3, One Punch Man 3rd Season, OPM 3', N'one-punch-man.jpg', N'One, Murata Yusuke', N'Mùa 3 của One Punch Man.'),
(105, N'Gachiakuta', N'', N'gachiakuta.jpg', N'Suganuma Fumihiko', N'Thành phố, nơi các tầng lớp văn minh sinh sống - khu ổ chuột nơi tụ tập các đời con cháu của bọn tội phạm, hằng ngày đều bị người khác sỉ nhục, khinh bỉ, gọi họ là những thứ rác rưởi, lũ "dân tộc" gớm ghiếc, hai mặt trái của xã hội được ngăn cách bởi những bức tường cao vút, và bên dưới nơi ấy - Abyss - một bãi rác nơi bọn tội phạm bị lưu đày, ngay cả những người dân của khu ổ chuột dù đã quen sống bẩn thỉu nhưng vẫn rất sợ nơi này. Một cậu bé mồ côi - Rudo sống trong khu ổ chuột với người cha nuôi Regto sống sót bằng cách thực hiện các hoạt động tội phạm. Mặc sức Regto khuyên ngăn, Rudo vẫn không có ý định dừng lại vì cậu ta tin rằng đó là cách duy nhất để kiếm tiền và giúp đỡ Regto vì đã nuôi dạy cậu. Nhưng một ngày nọ, khi về đến nhà, những hình ảnh quen thuộc thường ngày được thay thế bằng một cảnh tượng mà cậu không thể nào tin được. Regto đã bị sát hại còn cậu thì bị buộc tội giết người. Bị kết án xuống Vực thẳm - địa ngục ghê tởm ấy, Rudo đã gào thét, thề với tất cả sự giận dữ lẫn nỗi thất vọng trong mình rằng chắc chắn cậu sẽ giết kẻ gây án và tiêu diệt tất cả những người đã buộc tội cậu sát hại gia đình mình.'),
(106, N'Black Clover (TV)', N'Black Clover (2017), Black Clover, Thế Giới Phép Thuật, Cỏ Ba Lá Đen', N'black-clover.jpg', N'Yoshihara Tatsuya', N'Asta và Yuno đã bị bỏ rơi cùng nhau tại cùng một nhà thờ và đã không thể tách rời kể từ đó. Khi còn trẻ, họ hứa sẽ cạnh tranh với nhau để xem ai sẽ trở thành Hoàng đế Magus tiếp theo. Tuy nhiên, khi chúng lớn lên, một số khác biệt giữa chúng trở nên đơn giản. Yuno là một thiên tài với ma thuật, với sức mạnh và khả năng kiểm soát tuyệt vời, trong khi Asta không thể sử dụng ma thuật chút nào, và cố gắng bù đắp cho sự thiếu hụt của mình bằng cách luyện tập thể chất. Khi họ nhận được Grimoa của họ ở tuổi 15, Yuno đã có một cuốn sách ngoạn mục với cỏ ba lá bốn lá (hầu hết mọi người đều có một cây cỏ ba lá), trong khi Asta không nhận được gì cả. Tuy nhiên, khi Yuno bị đe dọa, sự thật về sức mạnh của Asta đã được tiết lộ, anh đã nhận được một cây cỏ ba lá Grimoire, một cỏ ba lá đen! Bây giờ hai người bạn đang hướng tới trên thế giới, cả hai đều mong muốn cùng một mục tiêu!'),
(107, N'Học Viện Anh Hùng Mùa Cuối', N'Boku no Hero Academia: Final Season, My Hero Academia Final Season, My Hero Academia 8', N'my-hero-acdemia-8.jpg', N'Nagasaki Kenji, Nakayama Naomi', N'Mùa cuối của Boku no Hero Academia.'),
(108, N'Spy x Family 3rd Season', N'Spy x Family Season 3', N'spy-x-family-season3.jpg', N'Imai Yukiko', N'Mùa 3 của Spy x Family.'),
(109, N'Thợ Săn Tí Hon', N'Hunter x Hunter, HxH', N'hunter-x-hunter.jpg', N'Koujina Hiroshi', N'Thợ Săn là những người đi chu du thế giới, đối mặt với hiểm nguy. Từ bắt giữ tội phạm cho đến nhưng cuộc thám hiểm trên các hòn đảo để tìm kho báu. Câu chuyện bắt đầu khi người cha của một cậu bé tên Gon mất tích đã khá lâu, nên cậu bé quyết định trở thành Thợ Săn với hy vọng tìm được cha mình. Khi được 12 tuổi Gon bắt đầu cuộc hành trình của mình để được tham gia vào "Cuộc thi Thợ Săn Kỳ Tài", ai cũng biết tỉ lệ thành công rất thấp, có khi chết lúc nào không hay. Trong cuộc thi cậu đã kết bạn với Kurapica, Leorio và Killua. Với tình bạn, họ đã trải qua biết bao nhiêu là thử thách, hiểm nguy trên cuộc hành trình của một người Thợ Săn... Còn về phần họ trải qua những thử thách gì và như thế nào thì mời các bạn theo dõi...'),
(110, N'Kaijuu 8-gou 2nd Season', N'Kaiju No. 8 Season 2, 8Kaijuu, Monster #8, Kaiju No. Eight, Kaiju #8', N'kaiju-no8-season2.jpg', N'Miya Shigeyuki', N'Mùa 2 của Kaijuu 8-gou.'),
(111, N'Jujutsu Kaisen 2nd Season', N'Jujutsu Kaisen SS2, Chú Thuật Hồi Chiến Mùa 2, Sorcery Fight, JJK 2', N'jujustu-kaisen-season2.jpg', N'Goshozono Shouta', N'Jujutsu Kaisen mùa 2 sẽ tập trung vào thời kỳ Gojo Satoru còn là học sinh của trường Cao đẳng Chú thuật Tokyo, khám phá mối quan hệ của anh với Geto Suguru - nhân vật phản diện chính trong phiên bản điện ảnh và phần đầu của anime. Phim cũng giải thích tại sao Gojo là chú thuật sư mạnh nhất của thế hệ này và là mối đe dọa với những linh hồn bị nguyền rủa đang tìm cách hồi sinh Sukuna. Một nhân vật đặc biệt không kém cũng xuất hiện trong phần 2 là Fushiguro Toji - cha của Fushiguro Megumi - cũng là kẻ thù của Gojo Satoru.'),
(112, N'Sát Thủ Về Vườn', N'Sakamoto Days, Sakamoto Days Part 2', N'sakamoto-days.jpg', N'Watanabe Masaki', N'Thời gian trôi qua thật yên bình đối với Sakamoto kể từ khi anh ấy rời khỏi thế giới ngầm. Anh ấy đang điều hành một cửa hàng nhỏ trong khu phố với người vợ xinh đẹp và đứa con của mình, và có vẻ hơi... phát tướng rồi. Nhưng một ngày nọ, một nhân vật từ quá khứ của anh ấy đến thăm và đưa ra một lời đề nghị mà anh ấy không thể từ chối: quay trở lại thế giới sát thủ hoặc là chết!'),
(113, N'Bảy Viên Ngọc Rồng Siêu Cấp', N'Dragon Ball Super, Dragon Ball Chou, 7 Viên Ngọc Rồng Siêu Cấp', N'dragon-ball-super.jpg', N'Chioka Kimitoshi', N'Dragon Ball Serie mới có tên là Super hoặc Chou dài tập chiếu trên truyền hình, bối cảnh nối tiếp sau cuộc chiến với Ma nhân Buu !!!'),
(114, N'Jujutsu Kaisen - Chú Thuật Hồi Chiến', N'Chú Thuật Hồi Chiến, Sorcery Fight, Jujutsu Kaisen (TV)', N'jujustu-kaisen.jpg', N'Park Seong-Hu', N'Trong một thế giới nơi những con quỷ ăn thịt người không nghi ngờ gì, những mảnh vỡ của con quỷ huyền thoại và đáng sợ Ryoumen Sukuna đã bị thất lạc và nằm rải rác. Nếu bất kỳ con quỷ nào tiêu thụ các bộ phận cơ thể của Sukuna, sức mạnh mà chúng có được có thể phá hủy thế giới như chúng ta đã biết. May mắn thay, có một ngôi trường bí ẩn của các Phù thủy Jujutsu tồn tại để bảo vệ sự tồn tại bấp bênh của người sống khỏi xác sống!Yuuji Itadori là một học sinh trung học dành cả ngày để thăm ông nội nằm liệt giường của mình. Mặc dù anh ấy trông giống như một thiếu niên bình thường của bạn, nhưng sức mạnh thể chất to lớn của anh ấy là một điều đáng chú ý! Mọi câu lạc bộ thể thao đều muốn cậu tham gia, nhưng Itadori thà đi chơi với những đứa trẻ bị trường ruồng bỏ trong Câu lạc bộ huyền bí. Một ngày nọ, câu lạc bộ quản lý để có được bàn tay của họ trên một vật thể bị nguyền rủa bị phong ấn, nhưng họ ít biết nỗi kinh hoàng mà họ sẽ gây ra khi phá vỡ phong ấn ...'),
(115, N'Solo Leveling 2nd Season - Tôi Thăng Cấp Một Mình Mùa 2', N'Solo Leveling SS2, Ore dake Level Up na Ken Season 2: Arise from the Shadow, Solo Leveling Season 2: Arise from the Shadow, Solo Leveling Second Season', N'solo-leveling-season2.jpg', N'Nakashige Shunsuke', N'Solo Leveling (Season 2): Arise From The Shadow tiếp tục câu chuyện của Sung Jinwoo, người từng được biết đến là "Thợ săn yếu nhất của toàn nhân loại". Sau khi sở hữu sức mạnh chưa từng có để được thăng cấp trong một hầm ngục, Jinwoo đã trở thành Vua Bóng Tối và có khả năng điều khiển một đội quân hùng hậu. Từ đây, anh chàng bắt đầu hành trình mới với hy vọng chữa khỏi bệnh cho mẹ mình.'),
(116, N'One Piece - Đảo Hải Tặc', N'Vua Hải Tặc', N'one-piece.jpg', N'Eiichiro Oda', N'Anime được phát sóng lần đầu tiên vào năm 1999 và nhanh chóng trở thành một trong những series anime phổ biến nhất trên thế giới. Câu chuyện xoay quanh Monkey D. Luffy, một chàng trai trẻ với giấc mơ trở thành Vua Hải Tặc. Luffy, người có khả năng co giãn như cao su sau khi ăn nhầm Trái Ác Quỷ, lãnh đạo nhóm Hải Tặc Mũ Rơm đi khắp Grand Line để tìm kiếm kho báu huyền thoại One Piece và theo đuổi giấc mơ của mình. Series nổi tiếng với cốt truyện phong phú, nhân vật đa dạng, và những pha hành động hấp dẫn'),
(117, N'One Punch Man 3', N'One Punch Man Season 3, One Punch Man 3rd Season, OPM 3', N'one-punch-man.jpg', N'One, Murata Yusuke', N'Mùa 3 của One Punch Man.'),
(118, N'Gachiakuta', N'', N'gachiakuta.jpg', N'Suganuma Fumihiko', N'Thành phố, nơi các tầng lớp văn minh sinh sống - khu ổ chuột nơi tụ tập các đời con cháu của bọn tội phạm, hằng ngày đều bị người khác sỉ nhục, khinh bỉ, gọi họ là những thứ rác rưởi, lũ "dân tộc" gớm ghiếc, hai mặt trái của xã hội được ngăn cách bởi những bức tường cao vút, và bên dưới nơi ấy - Abyss - một bãi rác nơi bọn tội phạm bị lưu đày, ngay cả những người dân của khu ổ chuột dù đã quen sống bẩn thỉu nhưng vẫn rất sợ nơi này. Một cậu bé mồ côi - Rudo sống trong khu ổ chuột với người cha nuôi Regto sống sót bằng cách thực hiện các hoạt động tội phạm. Mặc sức Regto khuyên ngăn, Rudo vẫn không có ý định dừng lại vì cậu ta tin rằng đó là cách duy nhất để kiếm tiền và giúp đỡ Regto vì đã nuôi dạy cậu. Nhưng một ngày nọ, khi về đến nhà, những hình ảnh quen thuộc thường ngày được thay thế bằng một cảnh tượng mà cậu không thể nào tin được. Regto đã bị sát hại còn cậu thì bị buộc tội giết người. Bị kết án xuống Vực thẳm - địa ngục ghê tởm ấy, Rudo đã gào thét, thề với tất cả sự giận dữ lẫn nỗi thất vọng trong mình rằng chắc chắn cậu sẽ giết kẻ gây án và tiêu diệt tất cả những người đã buộc tội cậu sát hại gia đình mình.'),
(119, N'Black Clover (TV)', N'Black Clover (2017), Black Clover, Thế Giới Phép Thuật, Cỏ Ba Lá Đen', N'black-clover.jpg', N'Yoshihara Tatsuya', N'Asta và Yuno đã bị bỏ rơi cùng nhau tại cùng một nhà thờ và đã không thể tách rời kể từ đó. Khi còn trẻ, họ hứa sẽ cạnh tranh với nhau để xem ai sẽ trở thành Hoàng đế Magus tiếp theo. Tuy nhiên, khi chúng lớn lên, một số khác biệt giữa chúng trở nên đơn giản. Yuno là một thiên tài với ma thuật, với sức mạnh và khả năng kiểm soát tuyệt vời, trong khi Asta không thể sử dụng ma thuật chút nào, và cố gắng bù đắp cho sự thiếu hụt của mình bằng cách luyện tập thể chất. Khi họ nhận được Grimoa của họ ở tuổi 15, Yuno đã có một cuốn sách ngoạn mục với cỏ ba lá bốn lá (hầu hết mọi người đều có một cây cỏ ba lá), trong khi Asta không nhận được gì cả. Tuy nhiên, khi Yuno bị đe dọa, sự thật về sức mạnh của Asta đã được tiết lộ, anh đã nhận được một cây cỏ ba lá Grimoire, một cỏ ba lá đen! Bây giờ hai người bạn đang hướng tới trên thế giới, cả hai đều mong muốn cùng một mục tiêu!'),
(120, N'Học Viện Anh Hùng Mùa Cuối', N'Boku no Hero Academia: Final Season, My Hero Academia Final Season, My Hero Academia 8', N'my-hero-acdemia-8.jpg', N'Nagasaki Kenji, Nakayama Naomi', N'Mùa cuối của Boku no Hero Academia.'),
(121, N'Spy x Family 3rd Season', N'Spy x Family Season 3', N'spy-x-family-season3.jpg', N'Imai Yukiko', N'Mùa 3 của Spy x Family.'),
(122, N'Thợ Săn Tí Hon', N'Hunter x Hunter, HxH', N'hunter-x-hunter.jpg', N'Koujina Hiroshi', N'Thợ Săn là những người đi chu du thế giới, đối mặt với hiểm nguy. Từ bắt giữ tội phạm cho đến nhưng cuộc thám hiểm trên các hòn đảo để tìm kho báu. Câu chuyện bắt đầu khi người cha của một cậu bé tên Gon mất tích đã khá lâu, nên cậu bé quyết định trở thành Thợ Săn với hy vọng tìm được cha mình. Khi được 12 tuổi Gon bắt đầu cuộc hành trình của mình để được tham gia vào "Cuộc thi Thợ Săn Kỳ Tài", ai cũng biết tỉ lệ thành công rất thấp, có khi chết lúc nào không hay. Trong cuộc thi cậu đã kết bạn với Kurapica, Leorio và Killua. Với tình bạn, họ đã trải qua biết bao nhiêu là thử thách, hiểm nguy trên cuộc hành trình của một người Thợ Săn... Còn về phần họ trải qua những thử thách gì và như thế nào thì mời các bạn theo dõi...'),
(123, N'Kaijuu 8-gou 2nd Season', N'Kaiju No. 8 Season 2, 8Kaijuu, Monster #8, Kaiju No. Eight, Kaiju #8', N'kaiju-no8-season2.jpg', N'Miya Shigeyuki', N'Mùa 2 của Kaijuu 8-gou.'),
(124, N'Jujutsu Kaisen 2nd Season', N'Jujutsu Kaisen SS2, Chú Thuật Hồi Chiến Mùa 2, Sorcery Fight, JJK 2', N'jujustu-kaisen-season2.jpg', N'Goshozono Shouta', N'Jujutsu Kaisen mùa 2 sẽ tập trung vào thời kỳ Gojo Satoru còn là học sinh của trường Cao đẳng Chú thuật Tokyo, khám phá mối quan hệ của anh với Geto Suguru - nhân vật phản diện chính trong phiên bản điện ảnh và phần đầu của anime. Phim cũng giải thích tại sao Gojo là chú thuật sư mạnh nhất của thế hệ này và là mối đe dọa với những linh hồn bị nguyền rủa đang tìm cách hồi sinh Sukuna. Một nhân vật đặc biệt không kém cũng xuất hiện trong phần 2 là Fushiguro Toji - cha của Fushiguro Megumi - cũng là kẻ thù của Gojo Satoru.'),
(125, N'Sát Thủ Về Vườn', N'Sakamoto Days, Sakamoto Days Part 2', N'sakamoto-days.jpg', N'Watanabe Masaki', N'Thời gian trôi qua thật yên bình đối với Sakamoto kể từ khi anh ấy rời khỏi thế giới ngầm. Anh ấy đang điều hành một cửa hàng nhỏ trong khu phố với người vợ xinh đẹp và đứa con của mình, và có vẻ hơi... phát tướng rồi. Nhưng một ngày nọ, một nhân vật từ quá khứ của anh ấy đến thăm và đưa ra một lời đề nghị mà anh ấy không thể từ chối: quay trở lại thế giới sát thủ hoặc là chết!'),
(126, N'Bảy Viên Ngọc Rồng Siêu Cấp', N'Dragon Ball Super, Dragon Ball Chou, 7 Viên Ngọc Rồng Siêu Cấp', N'dragon-ball-super.jpg', N'Chioka Kimitoshi', N'Dragon Ball Serie mới có tên là Super hoặc Chou dài tập chiếu trên truyền hình, bối cảnh nối tiếp sau cuộc chiến với Ma nhân Buu !!!'),
(127, N'Jujutsu Kaisen - Chú Thuật Hồi Chiến', N'Chú Thuật Hồi Chiến, Sorcery Fight, Jujutsu Kaisen (TV)', N'jujustu-kaisen.jpg', N'Park Seong-Hu', N'Trong một thế giới nơi những con quỷ ăn thịt người không nghi ngờ gì, những mảnh vỡ của con quỷ huyền thoại và đáng sợ Ryoumen Sukuna đã bị thất lạc và nằm rải rác. Nếu bất kỳ con quỷ nào tiêu thụ các bộ phận cơ thể của Sukuna, sức mạnh mà chúng có được có thể phá hủy thế giới như chúng ta đã biết. May mắn thay, có một ngôi trường bí ẩn của các Phù thủy Jujutsu tồn tại để bảo vệ sự tồn tại bấp bênh của người sống khỏi xác sống!Yuuji Itadori là một học sinh trung học dành cả ngày để thăm ông nội nằm liệt giường của mình. Mặc dù anh ấy trông giống như một thiếu niên bình thường của bạn, nhưng sức mạnh thể chất to lớn của anh ấy là một điều đáng chú ý! Mọi câu lạc bộ thể thao đều muốn cậu tham gia, nhưng Itadori thà đi chơi với những đứa trẻ bị trường ruồng bỏ trong Câu lạc bộ huyền bí. Một ngày nọ, câu lạc bộ quản lý để có được bàn tay của họ trên một vật thể bị nguyền rủa bị phong ấn, nhưng họ ít biết nỗi kinh hoàng mà họ sẽ gây ra khi phá vỡ phong ấn ...'),
(128, N'Solo Leveling 2nd Season - Tôi Thăng Cấp Một Mình Mùa 2', N'Solo Leveling SS2, Ore dake Level Up na Ken Season 2: Arise from the Shadow, Solo Leveling Season 2: Arise from the Shadow, Solo Leveling Second Season', N'solo-leveling-season2.jpg', N'Nakashige Shunsuke', N'Solo Leveling (Season 2): Arise From The Shadow tiếp tục câu chuyện của Sung Jinwoo, người từng được biết đến là "Thợ săn yếu nhất của toàn nhân loại". Sau khi sở hữu sức mạnh chưa từng có để được thăng cấp trong một hầm ngục, Jinwoo đã trở thành Vua Bóng Tối và có khả năng điều khiển một đội quân hùng hậu. Từ đây, anh chàng bắt đầu hành trình mới với hy vọng chữa khỏi bệnh cho mẹ mình.');

SELECT
    [Id], [Title]
FROM
    [Anime] 
ORDER BY
    [Id] ASC 
OFFSET 0 ROWS          -- Tương đương với SKIP (Bỏ qua 10 hàng đầu tiên)
FETCH NEXT 10 ROWS ONLY

DROP TABLE Anime

--Database for AccountService

create database AccountDatabase

use AccountDatabase

create table Role (
	Id nvarchar(100),
	Name nvarchar(255),
	constraint PK_Role primary key (Id)
);

create table UserProfile (
	Id nvarchar(100),
	UserName nvarchar(255),
	Email nvarchar(255),
	PasswordHash nvarchar(max),
	PhoneNumber nvarchar(20),
	constraint PK_User primary key (Id)
);

create table UserRole (
	UserId nvarchar(100),
	RoleId nvarchar(100),
	constraint PK_UserRole primary key (UserId, RoleId),
	constraint FK_UserRole_User foreign key (UserId) references UserProfile(Id),
	constraint FK_UserRole_Role foreign key (RoleId) references Role(Id),
);

DROP TABLE UserRole;
DROP TABLE UserProfile;
DROP TABLE Role;