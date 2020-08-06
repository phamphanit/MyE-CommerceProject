namespace FinalProject.Helpers
{
    public static class MyExtensions
    {
        public static string ToVnd(this double donGia)
        {
            return donGia.ToString("#,###0") + "đ";
        }
    }
}