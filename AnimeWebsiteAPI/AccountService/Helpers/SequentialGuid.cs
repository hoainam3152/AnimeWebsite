namespace AccountService.Helpers
{
    public class SequentialGuid
    {
        public static Guid Generate()
        {
            // Lấy GUID mới
            Guid baseGuid = Guid.NewGuid();

            // Lấy Ticks hiện tại và chuyển sang byte
            byte[] guidBytes = baseGuid.ToByteArray();
            byte[] dateBytes = BitConverter.GetBytes(DateTime.UtcNow.Ticks);

            // Thay thế các byte cuối/đầu của GUID bằng các byte của Ticks để tạo tính sắp xếp
            // (Logic cụ thể thay đổi tùy theo hệ điều hành/database)

            // Ví dụ đơn giản: Thay thế 6 byte cuối bằng 6 byte của Ticks
            Array.Copy(dateBytes, 2, guidBytes, 10, 6);

            return new Guid(guidBytes);
        }
    }
}
