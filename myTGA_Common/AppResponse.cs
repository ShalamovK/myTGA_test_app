namespace myTGA_Common {
    public class AppResponse {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public AppResponse(bool success) {
            IsSuccess = success;
        }

        public AppResponse(bool success, string message) {
            IsSuccess = success;
            Message = message;
        }
    }
}
