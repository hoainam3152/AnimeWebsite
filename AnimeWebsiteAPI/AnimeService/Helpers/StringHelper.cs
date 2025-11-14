namespace AnimeService.Helpers
{
    public static class StringHelper
    {
        public static List<string> SplitByComma(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new List<string>();
            }

            // StringSplitOptions.RemoveEmptyEntries đảm bảo các chuỗi rỗng không được thêm vào
            // (xảy ra khi chuỗi gốc là "a,,b")
            var parts = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var results = parts
                .Select (part => part.Trim())   // Loại bỏ khoảng trắng ở đầu và cuối mỗi phần tử
                .Where (part => !string.IsNullOrEmpty(part))    // Đảm bảo không còn chuỗi rỗng sau khi Trim()
                .ToList();

            return results;
        }
    }
}
