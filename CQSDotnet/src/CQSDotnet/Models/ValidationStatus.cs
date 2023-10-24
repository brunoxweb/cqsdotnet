namespace CQSDotnet.Models
{
    public class ValidationStatus
    {
        public bool IsValid { get; set; }

        public Dictionary<string, string> Errors { get; private set; }

        public ValidationStatus()
        {
            Errors = new Dictionary<string, string>();
            this.IsValid = true;
        }

        public void AddError(string code, string message)
        {
            this.IsValid = false;
            this.Errors.Add(code, message);
        }
    }
}