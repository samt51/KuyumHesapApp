namespace KuyumHesap.Application.Common.Extensions
{

    public  class HelpersExtension
    {
        private static readonly object _receiptLock = new();
        private static long _lastMillis = 0;
        private static int _counter = 0;
        public static string GenerateUniqueReceiptNumber()
        {
            lock (_receiptLock)
            {
                var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (now == _lastMillis)
                    _counter++;
                else
                {
                    _lastMillis = now;
                    _counter = 0;
                }

                // Format: "WEB-{milliseconds}{counter padded 3}"
                return $"WEB-{now}{_counter:D3}";
            }
        }
    }
}
