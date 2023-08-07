using WebAPI.Models;

namespace WebAPI.HienThi
{
    public class Loi
    {
        public ResponseAPI <dynamic> HienThiLoi(string message, string error)
        {
            var response = new ResponseAPI<dynamic>
            {
                Status = 400,
                Message = message,
                Content = new { error = error }
            };
            return response;
        }
    }
}
