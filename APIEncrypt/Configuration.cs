namespace APIEncrypt
{
    public class Configuration
    {
        public RandomValuesSection? RandomValues { get; set; }
    }
    public class RandomValuesSection
    {
        public string? KeyAES { get; set; }
        public string? KeyBF { get; set; }
    }
}
