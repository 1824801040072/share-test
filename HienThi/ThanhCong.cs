using WebAPI.Models;

namespace WebAPI.HienThi
{
    public class ThanhCong
    {
        public ResponseAPI<dynamic> HienThiThanhCong(string message, object contents)
        {
            var response = new ResponseAPI<dynamic>
            {
                Status = 200,
                Message = message,
                Content = contents
            };

            return response;
        }
    }
}
