namespace Stactive
{
    public static class StactiveOptionsBuilder
    {
        public static StactiveOptions UseMongoDb(this StactiveOptions options)
        {
            options.UseMongoDb = true;
            return options;
        }
    }
}